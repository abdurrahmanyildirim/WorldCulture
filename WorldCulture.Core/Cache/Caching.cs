using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Core.Cache
{
    public class CacheManager<T>:ICacheService<T>
    {
        //TODO: Admin panelden sonra yappılacak
        private readonly IMemoryCache _memoryCache;

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<T> CheckData(string key)
        {
            if (_memoryCache.TryGetValue(key, out List<T> list))
            {
                return list;
            }
            else
            {
                return null;
            }
        }

    }
}
