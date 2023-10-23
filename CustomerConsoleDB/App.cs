using CustomerConsoleDB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerConsoleDB
{
    public class App
    {
        private readonly ICustomerDataProvider _data;

        public App(ICustomerDataProvider data)
        {
            _data = data;
        }

        public void GetCustomerList()
        {
            var customerList = _data.GetCustomerList();

            Console.WriteLine("############## Customers older than 30 years ##############");
            var customersOlderThan30 = customerList.Where(c => c.Age > 30).ToList();
            if (customersOlderThan30.Count > 0)
            {
                foreach (var customer in customersOlderThan30)
                {
                    Console.WriteLine($"{customer.Name}, {customer.Age}, {customer.Email}");
                }
            }
            else
            {
                Console.WriteLine("No customer older than 30");
            }
            Console.WriteLine("\n");

            Console.WriteLine("############## Customers whose names contains the string 'Doe' ##############");
            var customerContainsDoe = customerList.Where(c => c.Name.Contains("Doe")).ToList();
            if (customerContainsDoe.Count > 0)
            {
                foreach (var customer in customerContainsDoe)
                {
                    Console.WriteLine($"{customer.Name}, {customer.Age}, {customer.Email}");
                }
            }
            else
            {
                Console.WriteLine("No name contains 'Doe'");
            }
            Console.WriteLine("\n");

            Console.WriteLine("############## Serialize list of customers to json ##############");
            var serializeCustomerList = JsonSerializer.Serialize(customerList);
            Console.WriteLine(serializeCustomerList);
            Console.WriteLine("\n");

            Console.WriteLine("############## Deserialize json to list of customer objects ##############");
            var deserializeCustomerList = JsonSerializer.Deserialize<List<Customer>>(serializeCustomerList);
            foreach (var customer in deserializeCustomerList)
            {
                Console.WriteLine($"{customer.Name}, {customer.Age}, {customer.Email}");
            }
            Console.WriteLine("\n");
        }

        public void GetCustomersListByAgeRange()
        {
            Console.WriteLine("############## Customer list by age range ##############");
            int startAge = 25;
            int endAge = 50;
            Console.WriteLine($"Start age: {startAge} | End age: {endAge}");
            if (startAge > endAge)
            {
                Console.WriteLine("Start age must be less than end age");
            }
            else
            {
                var customersByAgeRange = _data.GetCustomersListByAgeRange(startAge, endAge);
                foreach (var customer in customersByAgeRange)
                {
                    Console.WriteLine($"{customer.Name}, {customer.Age}, {customer.Email}");
                }
            }
            Console.WriteLine("\n");
        }

        public void SaveCustomer()
        {
            Console.WriteLine("############## Save customer ##############");
            Customer customer = new Customer()
            {
                Name = "Julio",
                Age = 55,
                Email = "julio@testmail.com"
            };

            _data.SaveCustomer(customer);

            Console.WriteLine($"Added 1 customer");
            Console.WriteLine("\n");
        }

        public void SaveCustomerList()
        {
            Console.WriteLine("############## Populate customer list ##############");
            List<Customer> customerList = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Maria",
                    Age = 33,
                    Email = "maria@testmail.com"
                },
                new Customer()
                {
                    Name = "Sofia",
                    Age = 23,
                    Email = "sofia@testmail.com"
                },
                new Customer()
                {
                    Name = "Micaela",
                    Age = 30,
                    Email = "micaela@testmail.com"
                },
                new Customer()
                {
                    Name = "Doe",
                    Age = 40,
                    Email = "doe@testmail.com"
                },
                new Customer()
                {
                    Name = "Andres",
                    Age = 45,
                    Email = "andres@testmail.com"
                },
                new Customer()
                {
                    Name = "Felipe",
                    Age = 48,
                    Email = "felipe@testmail.com"
                },
                new Customer()
                {
                    Name = "Fernanda",
                    Age = 23,
                    Email = "fernanda@testmail.com"
                },
                new Customer()
                {
                    Name = "Carlos",
                    Age = 28,
                    Email = "carlos@testmail.com"
                }
            };

            _data.SaveCustomerList(customerList);

            Console.WriteLine($"Added {customerList.Count} customers");
            Console.WriteLine("\n");
        }
    }
}
