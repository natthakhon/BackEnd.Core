using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Model
{
    public class Customer
    {
        public string CustomerId { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public DateTime BOD { set; get; }
        public Gender Gender { set; get; }
        public List<Address> Addresses { set; get; }
    }

    public enum Gender { Male,Female,Neither}
}
