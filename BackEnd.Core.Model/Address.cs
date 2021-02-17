using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Model
{
    public class Address
    {
        public AddressType AddressType { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public int ZipCode { set; get; }

    }

    public enum AddressType { Home,Business,Billing}
}
