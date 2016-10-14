using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary
{

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string CompanyName { set; get;  }
        [DataMember]
        public string EmailAddress { set; get; }
        [DataMember]
        public int PhoneNumber { set; get; }
        [DataMember]
        public int Billing { set;get; }
        [DataMember]
        public string ShippingAddress { set; get; }
    }
}
