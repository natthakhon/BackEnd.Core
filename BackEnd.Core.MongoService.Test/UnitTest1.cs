using BackEnd.Core.MongoService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Core.MongoService.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConnect2Mongo()
        {
            CustomerService customerService = new CustomerService("mongodb+srv://gone:gone@sandbox.ldbdr.mongodb.net?retryWrites=true&w=majority"
                    , "MyShop");

            var c = customerService.GetByCustomerId("1");
            Assert.AreEqual(c.CustomerId, "1");
        }


    }
}
