﻿using CustomerConsoleDB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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