using System;
using System.Collections.Generic;
using System.Text;
using Model = BackEnd.Core.Model;
using Mongo = BackEnd.Core.MongoService;

namespace BackEnd.Core.MongoService.Converter
{
    public class CustomerConverter : BaseConverter<Model.Customer, Mongo.Customer>
    {
        public override Model.Customer Convert(Customer tm)
        {
            List<Model.Address> addresses = new List<Model.Address>();
            tm.Addresses.ForEach(p =>
            {
                addresses.Add(new Model.Address()
                {
                    Address1 = p.Address1,
                    Address2 = p.Address2,
                    ZipCode = int.Parse(p.ZipCode),
                    AddressType = Enum.Parse<Model.AddressType>(p.AddressType)
                });
            });

            return new Model.Customer()
            {
                CustomerId = tm.CustomerId,
                BOD = DateTime.Parse(tm.BOD),
                Gender = Enum.Parse<Model.Gender>(tm.Gender),
                Name = tm.Name,
                LastName = tm.LastName,
                Addresses = addresses
            };        
        }
    }
}
