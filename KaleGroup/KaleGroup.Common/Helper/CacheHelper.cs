using Microsoft.Extensions.Caching.Memory;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Common.Helper
{

    public class CacheHelper: ICacheHelper
    {
        private readonly IMemoryCache _memCache;
        public CacheHelper(IMemoryCache memCache)
        {
            _memCache = memCache;
          
        }
        public void SetCache(string cacheKey, List<T> list)
        {
            if (!_memCache.TryGetValue(cacheKey, out list))
            {
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMonths(1),
                    Priority = CacheItemPriority.Normal
                };
                _memCache.Set(cacheKey, list, cacheExpOptions);
            }
        }

        public  void DeleteCache(string cacheKey)
        {
            _memCache.Remove( cacheKey);            
        }

        public bool  CheckCache(string cacheKey)
        {
            var checkCache = _memCache.Get(cacheKey);

            return checkCache == null ? false :true;
        }
    }

    public interface ICacheHelper
    {
        void SetCache(string cacheKey, List<T> list);
        void DeleteCache(string cacheKey);
        bool CheckCache(string cacheKey);
    }
}

