using System.Collections.Generic;

namespace WorldCulture.Core.Cache
{
    public interface ICacheService<T>
    {
        List<T> CheckData(string key);
    }
}