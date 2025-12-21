using System.Collections.Generic;
using Member.SYW._01_Scripts;

namespace Member.KYM.Code.Manager.Pooling
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        private Dictionary<string, Pool> _poolDit = new Dictionary<string, Pool>();
        
    }
}
