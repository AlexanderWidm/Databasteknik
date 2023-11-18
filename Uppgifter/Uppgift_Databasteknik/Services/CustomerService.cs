using System.Diagnostics;
using Uppgift_Databasteknik.Entities;
using Uppgift_Databasteknik.Models;
using Uppgift_Databasteknik.Repositories;

namespace Uppgift_Databasteknik.Services;

public class CustomerService
{
    private readonly AddressRepository _addressRepository;
    private readonly CustomerRepository _customerRepository;

    public CustomerService(AddressRepository addressRepository, CustomerRepository customerRepository)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        try
        {
            // check user
            if (!await _customerRepository.ExistsAsync(x => x.Email == form.Email))
            {
                // check address
                AddressEntity addressEntity = await _addressRepository.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);
                addressEntity ??= await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });

                // create user
                CustomerEntity customerEntity = await _customerRepository.CreateAsync(new CustomerEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id });
                if (customerEntity != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
    public async Task<CustomerEntity> GetCustomerByEmailAsync(string customerEmail)
    {
        try
        {
            // Use the GetAsync method from the base class to retrieve a customer by email
            return await _customerRepository.GetAsync(x => x.Email == customerEmail);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }

    public async Task<bool> UpdateCustomerAsync(string customerEmail, CustomerRegistrationForm form)
    {
        try
        {
            // Check if the customer exists
            var existingCustomer = await _customerRepository.GetAsync(x => x.Email == customerEmail);
            if (existingCustomer != null)
            {
                // Update the customer information
                existingCustomer.FirstName = form.FirstName;
                existingCustomer.LastName = form.LastName;
                existingCustomer.Email = form.Email;

                // Check if the address needs to be updated
                if (existingCustomer.Address.StreetName != form.StreetName || existingCustomer.Address.PostalCode != form.PostalCode)
                {
                    // Check if the new address already exists
                    AddressEntity addressEntity = await _addressRepository.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);
                    addressEntity ??= await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });

                    // Update the customer's address
                    existingCustomer.AddressId = addressEntity.Id;
                }

                // Update the customer in the repository
                var updatedCustomer = await _customerRepository.UpdateAsync(existingCustomer);

                // Check if the update was successful
                return updatedCustomer != null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
    public async Task<bool> DeleteAsync(string customerEmail)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(x => x.Email == customerEmail);
            if (customer != null)
            {
                await _addressRepository.RemoveAsync(customer.Address);

                await _customerRepository.RemoveAsync(customer);
            }
                return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
