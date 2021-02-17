using BackEnd.Core.MongoService.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Core.Api.Connection
{
    public class MongoDbConnection : IMongoDbConnection
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
