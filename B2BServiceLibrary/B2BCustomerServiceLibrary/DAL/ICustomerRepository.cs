using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary.DAL
{
   public interface ICustomerRepository
    {
        List<Customer> DAL_GetCustomers();
        Customer DAL_GetCustomer(int id);
        bool DAL_ModifyCustomer(Customer customer);
        Customer DAL_AddCustomer(Customer customer);
        void DAL_DeleteCustomer(int id);
        bool ValidateCreditStanding();
    }
}
