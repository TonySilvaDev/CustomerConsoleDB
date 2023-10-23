using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsoleDB.Repository.IRepository
{
    public interface ICustomerDataProvider
    {
        List<Customer> GetCustomerList();
        List<Customer> GetCustomersListByAgeRange(int startAge, int endAge);
        void SaveCustomer(Customer customer);
        void SaveCustomerList(List<Customer> customerList);
    }
}
