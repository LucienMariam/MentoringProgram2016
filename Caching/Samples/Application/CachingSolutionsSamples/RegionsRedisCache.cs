using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NorthwindLibrary;
using StackExchange.Redis;

namespace CachingSolutionsSamples
{
    internal class RegionsRedisCache: IRegionsCahce
    {
        private ConnectionMultiplexer redisConnection;
        string prefix = "Cache_Regions";
        DataContractSerializer serializer = new DataContractSerializer(
            typeof(IEnumerable<Region>));

        public RegionsRedisCache(string hostName)
        {
            redisConnection = ConnectionMultiplexer.Connect(hostName);
        }

        public IEnumerable<Region> Get(string forUser)
        {
            var db = redisConnection.GetDatabase();
            byte[] s = db.StringGet(prefix + forUser);
            if (s == null)
                return null;

            return (IEnumerable<Region>)serializer
                .ReadObject(new MemoryStream(s));

        }

        public void Set(string forUser, IEnumerable<Region> categories)
        {
            var db = redisConnection.GetDatabase();
            var key = prefix + forUser;

            if (categories == null)
            {
                db.StringSet(key, RedisValue.Null);
            }
            else
            {
                var stream = new MemoryStream();
                serializer.WriteObject(stream, categories);
                db.StringSet(key, stream.ToArray());
            }
        }
    }
}
