using System;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using System.Collections.Generic;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        static void Main(string[] args)
        {
            var cust1 = new CustomerBO()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                //AddressIds = new List<int>() { address.Id, address2.Id }
            };
            bllFacade.CustomerService.Create(cust1);

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                //AddressIds = new List<int>() { address.Id, address2.Id }
            });

            string[] menuItems =
            {
                "List Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;

                    default:

                        break;
                }
                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Bye");
            Console.ReadLine();
        }

        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if(customer!=null)
            {
                Console.WriteLine("FirstName: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("LastName: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                //customer.Address = Console.ReadLine();
                bllFacade.CustomerService.Update(customer);
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
            
        }

        private static CustomerBO FindCustomerById()
        {
            Console.WriteLine("Insert customer id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFacade.CustomerService.Get(id);
        }

        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerById();
            /*if(customerFound != null)
            {
                bllFacade.CustomerService.Delete(customerFound.Id);
                Console.WriteLine("Customer was Deleted");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }*/

            var response = customerFound == null ? "Customer not Found" : "Customer was Deleted";
            Console.WriteLine(response);
            
        }

        private static void AddCustomers()
        {
            Console.WriteLine("FirstName: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("LastName: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = firstName,
                LastName = lastName,
                //Address = address
            });
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList customers");

            foreach (var customer in bllFacade.CustomerService.GetAll())
            {
                //Console.WriteLine($"ID: {customer.Id} \nName: {customer.FullName} \nAddress: {customer.Address}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select action: ");
            Console.WriteLine("");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5)
            {
                Console.WriteLine("You need to select a number between 1-5");
            }

            //Console.WriteLine("Selection: " + selection);
            return selection;
        }
    }
}