using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;
namespace TextImportUser163
{
    public class RedisOperation
    {
        public ServiceStack.Redis.IRedisClient Client
        {
            get;
            private set;
        }
        public RedisOperation()
        {
            Client = new ServiceStack.Redis.RedisClient("127.0.0.1", 6379);
        }
        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
