using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary.DAL
{
    [DataContract]
    public class FakeOrderRepository
    {

        [DataMember]
        public Status OrderStatus { get; set; }

        [DataContract]
        public enum Status
        {
            [DataMember]
            Requested,
            [DataMember]
            Shipped,
            [DataMember]
            Completed,
            [DataMember]
            Cancelled,
            [DataMember]
            Paid
        }
    }
}
