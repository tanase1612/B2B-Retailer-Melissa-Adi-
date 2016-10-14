using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace B2BCustomerServiceLibrary
{
    [DataContract]
    public class ServiceFault
    {
        [DataMember]
        public string OperationName;

        [DataMember]
        public string ExceptopMessage;
    }
}
