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
            Client = new ServiceStack.Redis.RedisClient("192.168.113.8", 6379);
        }
        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
