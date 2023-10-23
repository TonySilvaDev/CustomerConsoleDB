using CustomerConsoleDB.Data;
using CustomerConsoleDB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsoleDB.Repository
{
    public class FileCustomerDataProvider : ICustomerDataProvider
    {
        public List<Customer> GetCustomerList()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Customer.ToList();
            }
        }

        public List<Customer> GetCustomersListByAgeRange(int startAge, int endAge)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Customer.Where(c => c.Age >= startAge && c.Age <= endAge).ToList();
            }
        }

        public void SaveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void SaveCustomerList(List<Customer> customerList)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Customer.AddRange(customerList);
                context.SaveChanges();
            }
        }
    }
}
