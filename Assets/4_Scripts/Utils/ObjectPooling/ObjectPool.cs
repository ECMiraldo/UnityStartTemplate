using UnityEngine.Pool;
using UnityUtils;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using System.Collections.Generic;

namespace ObjectPooling
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        private SerializedDictionary<ObjectPoolSettings, IObjectPool<GameObject>> pools = new();

        private void Start()
        {
            CreatePools();
        }
        private void CreatePools()
        {
            var allPoolSettings = Resources.LoadAll<ObjectPoolSettings>("ObjectPooling");
            foreach (ObjectPoolSettings poolSettings in allPoolSettings)
            {
                IObjectPool<GameObject> pool;
                pool = new ObjectPool<GameObject>(
                    poolSettings.Create,
                    poolSettings.OnGet,
                    poolSettings.OnRelease,
                    poolSettings.OnDestroyPoolObject,
                    true,
                    poolSettings.defaultCapacity,
                    poolSettings.maxCapacity
                );
                pools.Add(poolSettings, pool);
            }
        }

        public static GameObject Spawn(ObjectPoolSettings settings) => instance.pools[settings]?.Get();
        public static void ReturnToPool(GameObject go)
        {
            if (go.TryGetComponent(out IPooledObject pooledObject))
            {
                instance.pools[pooledObject.PoolSettings]?.Release(go);
            }
        }
    }
}

