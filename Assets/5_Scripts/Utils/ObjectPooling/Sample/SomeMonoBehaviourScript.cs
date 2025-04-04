using UnityEngine;

namespace ObjectPooling
{
    public class SomeMonoBehaviourScript : MonoBehaviour, IPooledObject
    {
        [SerializeField] private ObjectPoolSettings settings;

        public ObjectPoolSettings PoolSettings => settings;
    }
}

