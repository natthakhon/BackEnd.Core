using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.MongoService
{
    public class Address
    {
        public string AddressType { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string ZipCode { set; get; }
    }
}
