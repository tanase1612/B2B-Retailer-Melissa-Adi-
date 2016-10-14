using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary
{
    [ServiceContract]
   public interface ICustomerService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<Customer> GetCustomers();

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        Customer GetCustomer(int id);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        bool UpdateCustomer(Customer customer);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        Customer AddCustomer(Customer custmer);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DeleteCustomer(int id);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        bool ValidateCreditStanding();
    }
}
