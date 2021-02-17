using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.MongoService.Connection
{
    public interface IMongoDbConnection
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        //List<string> Collections { get; set; }
    }


}
