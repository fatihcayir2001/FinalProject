using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Cross_Cutting_Concerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);  //bunu yazmamizin nedeni cache de varsa cachedfen getirce zyoksa db den
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
