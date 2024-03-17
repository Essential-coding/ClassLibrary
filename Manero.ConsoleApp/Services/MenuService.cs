using Manero.Shared.Interfaces;
using Manero.Shared.Models;
using Manero.Shared.Services;
using System;

namespace Manero.ConsoleApp.Services
{
    public class MenuService
    {
        private static readonly ICustomerService _customerService = new CustomerService();

        public static void RunMenu()
        {
            while (true)
            {


                Console.Clear();

                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Private Customer");
                Console.WriteLine("2. Delete Customer");
                Console.WriteLine("3. Show All Customers");
                Console.WriteLine("4. Show Specific Customer");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        AddPrivateCustomerMenu();
                        break;
                    case "2":
                        DeleteCustomerMenu();
                        break;
                    case "3":
                        ShowAllCustomersMenu();
                        break;
                    case "4":
                        GetSpecificCustomer();
                        break;
                    case "5":
                        ExitApplication();
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please select again.");
                        break;
                }

                Console.WriteLine(); // Add empty line for readability


            }
        }

        public static void AddPrivateCustomerMenu()
        {
            ICustomer customer = new Customer();

            Console.Write("Enter your first name:");
            customer.FirstName = Console.ReadLine()!;

            Console.Write("Enter your last name:");
            customer.LastName = Console.ReadLine()!;

            Console.Write("Enter Phone Number:");
            customer.PhoneNumber = Console.ReadLine()!;

            Console.Write("Enter your email:");
            customer.Email = Console.ReadLine()!;

            Console.Write("Enter your Address:");
            customer.Address = Console.ReadLine()!;

            Console.Write("Enter your City:");
            customer.City = Console.ReadLine()!;

            Console.Write("Enter your Country:");
            customer.Country = Console.ReadLine()!;

            _customerService.AddCustomerToList(customer);
            Console.WriteLine("Customer added successfully.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        public static void GetSpecificCustomer()
        {
            // Ensure _customerService is initialized before use
            if (_customerService == null)
            {
                Console.WriteLine("Customer service is not initialized.");
                return;
            }

            Console.WriteLine("Enter email of specific customer");

            var email = Console.ReadLine();
            if (email != null)
            {
                ICustomer customer = _customerService.GetCustomerFromList(email);
                if (customer != null)
                {
                    Console.WriteLine($"Firstname:{customer.FirstName}\n Lastname:{customer.LastName}\n Email:{customer.Email}\n" +
                        $"Address:{customer.Address}\n City:{customer.City}\n Country:{customer.Country}\n Phone-number:{customer.PhoneNumber}");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }





        public static void DeleteCustomerMenu()
        {
            Console.Write("Enter the email of the customer you want to delete: ");
            string email = Console.ReadLine()!;

            bool success = _customerService.DeleteCustomer(_customerService.GetCustomerFromList(email));
            if (success)
            {
                Console.WriteLine("Customer deleted successfully.\n");
                Console.WriteLine("Press any key to continue");
            }
            else
            {
                Console.WriteLine("Customer with the specified email not found or an error occurred during deletion.");
            }

            Console.ReadKey();
        }

        public static void ShowAllCustomersMenu()
        {
            var customers = _customerService.GetCustomersFromList();

            Console.WriteLine("All Customers:");
            foreach (var customer in customers)
            {
                if (customer is ICustomer p)
                {
                    Console.WriteLine($" Firstname: {p.FirstName}\n Lastname: {p.LastName}\n Email: " +
                        $"{p.Email}\n Phone Number: {p.PhoneNumber}\n Country: {p.Country}\n Address: {p.Address}\n City: {p.City}\n");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void ExitApplication(int exitCode = 4)
        {
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
            Environment.Exit(exitCode);
        }
    }
}
