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
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomersListByAgeRange(int startAge, int endAge)
        {
            throw new NotImplementedException();
        }

        public void SaveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void SaveCustomerList(List<Customer> customerList)
        {
            throw new NotImplementedException();
        }
    }
}
