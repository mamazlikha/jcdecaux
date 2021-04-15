using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyProxy
{
    public class ProxyCache<T> where T:new()
    {
        protected ObjectCache cache;
        protected DateTimeOffset dt;

        public ProxyCache()
        {
            cache = MemoryCache.Default;
            dt = ObjectCache.InfiniteAbsoluteExpiration;
        }
        

        public T Get(string CacheItem)
        {
            if (cache.Get(CacheItem) == null) // timed out
            {
                var cacheItemPolicy1 = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt.Second),
                };
                T content = (T)Activator.CreateInstance(typeof(T), CacheItem);
                cache.Add(CacheItem,content, cacheItemPolicy1);
                return content;

            }
            return (T)cache.Get(CacheItem);
        }

        public T Get(string CacheItem, double dt_seconds)
        {
            var cacheItemPolicy2 = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt_seconds),
            };
            if (cache.Get(CacheItem) == null)
            {
                T content = (T)Activator.CreateInstance(typeof(T), CacheItem);
                cache.Add(CacheItem, content, cacheItemPolicy2);
                return content;
            }
            return (T)cache.Get(CacheItem);
        }


        public T Get(string CacheItem, DateTimeOffset dt)
        {
            var cacheItemPolicy2 = new CacheItemPolicy
            {
                AbsoluteExpiration = dt.DateTime,

            };
            if (cache.Get(CacheItem) == null)
            {
                T content = (T)Activator.CreateInstance(typeof(T), CacheItem);
                cache.Add(CacheItem, content, cacheItemPolicy2);
                return content;
            }
            return (T)cache.Get(CacheItem);

        }

        public void PrintAllCache()
        {

            DateTime dt = DateTime.Now;

            Console.WriteLine("All key-values at " + dt.Second);
            //loop through all key-value pairs and print them
            foreach (var item in cache)
            {
                Console.WriteLine("cache object key-value: " + item.Key + "-" + item.Value);
            }
        }

    }
}
