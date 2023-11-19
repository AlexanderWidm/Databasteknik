using System.Diagnostics;
using Uppgift_Databasteknik.Models;
using Uppgift_Databasteknik.Services;

namespace Uppgift_Databasteknik.Menus;

public class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("Customers");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Show all Customers");
        Console.WriteLine("3. Find one Customer");
        Console.WriteLine("4. Update Customer");
        Console.WriteLine("5. Remove Customer");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await CreateAsync();
                break;
            case "2":
                await ListAllAsync();
                break;
            case "3":
                await GetCustomerAsync();
                break;
            case "4":
                await UpdateCustomerAsync();
                break;
            case "5":
                await DeleteCustomerAsync();
                break;
        }
    }

    public async Task CreateAsync()
    {
        var form = new CustomerRegistrationForm();

        Console.Clear();
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Write("Street Name: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("Postal Code (xxx xx): ");
        form.PostalCode = Console.ReadLine()!;

        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
            Console.WriteLine("Customer was created successfully.");
        else
            Console.WriteLine("Unable to create customer");
        Console.ReadKey();
    }

    public async Task ListAllAsync()
    {
        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>");
            Console.WriteLine($"{customer.Address.StreetName} {customer.Address.PostalCode} {customer.Address.City}");
            Console.ReadKey();
        }
    }

    public async Task GetCustomerAsync()
    {
        Console.Clear();
        Console.Write("Enter Customer Email to retrieve: ");
        var customerEmail = Console.ReadLine();

        if (!string.IsNullOrEmpty(customerEmail))
        {
            var customer = await _customerService.GetCustomerByEmailAsync(customerEmail);

            if (customer != null)
            {
                Console.WriteLine($"Customer found:\n{customer.FirstName} {customer.LastName} <{customer.Email}>\n");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Customer Email.");
        }
        Console.ReadKey();
    }
    public async Task UpdateCustomerAsync()
    {
        Console.Clear();
        Console.Write("Enter Customer Email to update: ");
        var customerEmail = Console.ReadLine();

        if (!string.IsNullOrEmpty(customerEmail))
        {
            var existingCustomer = await _customerService.GetCustomerByEmailAsync(customerEmail);

            if (existingCustomer != null)
            {
                var form = new CustomerRegistrationForm();

                Console.Write($"First Name (Press Enter to keep existing value: {existingCustomer.FirstName}");
                form.FirstName = Console.ReadLine() ?? existingCustomer.FirstName;

                Console.Write($"Last Name (Press Enter to keep existing value: {existingCustomer.LastName}");
                form.LastName = Console.ReadLine() ?? existingCustomer.LastName;

                Console.Write($"Email (Press Enter to keep existing value: {existingCustomer.Email}): ", existingCustomer.Email);
                form.Email = Console.ReadLine() ?? existingCustomer.Email;

                Console.Write("Street Name (Press Enter to keep existing value: {0}): ", existingCustomer.Address.StreetName);
                form.StreetName = Console.ReadLine() ?? existingCustomer.Address.StreetName;

                Console.Write("Postal Code (Press Enter to keep existing value: {0}): ", existingCustomer.Address.PostalCode);
                form.PostalCode = Console.ReadLine() ?? existingCustomer.Address.PostalCode;

                Console.Write("City (Press Enter to keep existing value: {0}): ", existingCustomer.Address.City);
                form.City = Console.ReadLine() ?? existingCustomer.Address.City;

                var result = await _customerService.UpdateCustomerAsync(customerEmail, form);
                if (result)
                    Console.WriteLine("Customer was updated successfully.");
                else
                    Console.WriteLine("Unable to update customer");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Customer Email.");
        }
        Console.ReadKey();
    }
    public async Task DeleteCustomerAsync()
    {
        Console.Clear();
        Console.Write("Enter Customer Email to delete: ");
        var customerEmail = Console.ReadLine();

        if (!string.IsNullOrEmpty(customerEmail))
        {
            var result = await _customerService.DeleteAsync(customerEmail);
            if (result)
                Console.WriteLine("Customer was deleted successfully.");
            else
                Console.WriteLine("Unable to delete customer");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Customer Email.");
        }
        Console.ReadKey();
    }
}
