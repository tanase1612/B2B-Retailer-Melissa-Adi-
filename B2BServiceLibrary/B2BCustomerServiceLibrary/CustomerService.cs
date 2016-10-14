using B2BCustomerServiceLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CustomerService : ICustomerService
    {
        FakeCustomerRepository repository = new FakeCustomerRepository();
         
        public Customer AddCustomer(Customer customer)
        {
            try
            {
                repository.DAL_AddCustomer(customer);
            }
            catch (Exception ex)
            {
                ServiceFault f = new ServiceFault();
                f.OperationName = "AddCustomer";
                f.ExceptopMessage = ex.Message;
                throw new FaultException<ServiceFault>(f);
            }
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                repository.DAL_DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                ServiceFault f = new ServiceFault();
                f.OperationName = "DeleteCustomer";
                f.ExceptopMessage = ex.Message;
                throw new FaultException<ServiceFault>(f);
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return repository.DAL_GetCustomer(id);
            }
            catch (Exception ex)
            {
                ServiceFault f = new ServiceFault();
                f.OperationName = "GetCustomer";
                f.ExceptopMessage = ex.Message;
                throw new FaultException<ServiceFault>(f);
            }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                return repository.DAL_GetCustomers();
            }
            catch (Exception ex)
            {
                ServiceFault f = new ServiceFault();
                f.OperationName = "GetCustomer";
                f.ExceptopMessage = ex.Message;
                throw new FaultException<ServiceFault>(f);
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return repository.DAL_ModifyCustomer(customer);
            }
            catch (Exception ex)
            {
                ServiceFault f = new ServiceFault();
                f.OperationName = "UpdateCustomer";
                f.ExceptopMessage = ex.Message;
                throw new FaultException<ServiceFault>(f);
            }
        }

        public bool ValidateCreditStanding()
        {
            throw new NotImplementedException();
        }
    }
}
