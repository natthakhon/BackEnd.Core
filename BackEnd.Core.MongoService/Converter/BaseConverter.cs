using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.MongoService.Converter
{
    public abstract class BaseConverter<T,TM> where TM : BaseMongoModel 
    {
        public abstract T Convert(TM tm);
    }
}
