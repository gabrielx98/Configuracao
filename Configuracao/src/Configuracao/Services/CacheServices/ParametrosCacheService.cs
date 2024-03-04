namespace GxpConfiguracao.Services.CacheServices
{
    using System;
    using System.Collections.Concurrent;
    using Interfaces;

    public class ParametrosCacheService : IParametrosCacheService
    {
        private static readonly ConcurrentDictionary<string, CacheEntry> InMemoryCache = new ConcurrentDictionary<string, CacheEntry>();

        private static readonly TimeSpan CacheTime = TimeSpan.FromMinutes(30);

        public ParametrosCacheService()
        {
            InstanceCacheTime = CacheTime;
        }

        protected TimeSpan InstanceCacheTime { get; set; }

        public string ObterValor(string modulo, string chave, bool forceRefresh, Func<string> loadFromDatabase)
        {
            var cacheKey = $"{modulo}/{chave}";

            CacheEntry cacheValue = null;
            if (!forceRefresh && InMemoryCache.ContainsKey(cacheKey))
            {
                var tmp = InMemoryCache[cacheKey];

                if (tmp.LastDatabaseDate >= DateTime.Now.Subtract(InstanceCacheTime))
                {
                    cacheValue = tmp;
                }
                else
                {
                    InMemoryCache.TryRemove(cacheKey, out _);
                }
            }

            if (cacheValue == null)
            {
                var valueFromDb = loadFromDatabase();

                cacheValue = new CacheEntry()
                {
                    Modulo = modulo,
                    Parametro = chave,
                    LastDatabaseDate = DateTime.Now,
                    Value = valueFromDb
                };

                if (InMemoryCache.ContainsKey(cacheKey))
                {
                    InMemoryCache.TryUpdate(cacheKey, cacheValue, InMemoryCache[cacheKey]);
                }
                else
                {
                    InMemoryCache.TryAdd(cacheKey, cacheValue);
                }
            }

            return cacheValue.Value;
        }

        protected class CacheEntry
        {
            public string Modulo { get; set; }

            public string Parametro { get; set; }

            public string Value { get; set; }

            public DateTime LastDatabaseDate { get; set; }
        }
    }
}
