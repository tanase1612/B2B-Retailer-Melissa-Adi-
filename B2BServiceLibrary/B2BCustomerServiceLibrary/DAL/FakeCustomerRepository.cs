using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary.DAL
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        FakeOrderRepository orders = new FakeOrderRepository();

        List<Customer> customers = new List<Customer>
        {
            new Customer {Id = 11,CompanyName = "AB",EmailAddress="AB@gmail.DK", Billing=1235, PhoneNumber=12345, ShippingAddress="asdasd"  },
            new Customer {Id = 21,CompanyName = "BB",EmailAddress="BB@gmail.DK", Billing=1236, PhoneNumber=12345, ShippingAddress="asdasd"  },
            new Customer {Id = 31,CompanyName = "CC",EmailAddress="CC@gmail.DK", Billing=1237, PhoneNumber=12345, ShippingAddress="asdasd"  }

        };
        private int _nextId = 1;

        public Customer DAL_AddCustomer(Customer customer)
        {
            customer.Id = _nextId++;
            customers.Add(customer);
            return customer;
        }

        public void DAL_DeleteCustomer(int id)
        {
            customers.RemoveAll(p => p.Id == id);
        }

        public Customer DAL_GetCustomer(int id)
        {
            return customers.Find(c => c.Id == id);
        }

        public List<Customer> DAL_GetCustomers()
        {
            return customers;
        }

        public bool DAL_ModifyCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }
            int index = customers.FindIndex(p => p.Id == customer.Id);
            if (index == -1)
            {
                return false;
            }
            customers.RemoveAt(index);
            customers.Add(customer);
            return true;
        }

        public bool ValidateCreditStanding()
        {
            //assume the customer just make a order
            orders.OrderStatus = FakeOrderRepository.Status.Requested;
            switch (orders.OrderStatus)
            {
                case FakeOrderRepository.Status.Requested:
                case FakeOrderRepository.Status.Shipped: return false; ;
                case FakeOrderRepository.Status.Cancelled:
                case FakeOrderRepository.Status.Completed:
                case FakeOrderRepository.Status.Paid:
                default: return true;
            }
        }
    }
}
