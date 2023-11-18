using System.Diagnostics;

namespace Uppgift_Databasteknik.Menus;

public class MainMenu
{
    private readonly CustomerMenu _customerMenu;
    private readonly ProductMenu _productMenu;

    public MainMenu(CustomerMenu customerMenu, ProductMenu productMenu)
    {
        _customerMenu = customerMenu;
        _productMenu = productMenu;
    }

    public async Task StartAsync()
    {
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Customers");
                Console.WriteLine("2. Products");
                Console.WriteLine("3. Orders");
                Console.WriteLine("0. Exit program");
                Console.Write("Choose one option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await _customerMenu.ManageCustomers();
                        break;
                    case "2":
                        await _productMenu.ManageProducts();
                        break;
                    case "3":

                        break;

                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
            while (true);
        }
        catch (Exception ex) { Debug.Write(ex); }
    }
}
