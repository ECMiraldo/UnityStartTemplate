using UnityEngine;

namespace ObjectPooling
{
    [CreateAssetMenu(menuName = "ObjectPoolSettings")]
    public class ObjectPoolSettings : ScriptableObject
    {
        [field: SerializeField] public GameObject prefab { get; protected set; }
        [field: SerializeField] public int defaultCapacity { get; protected set; }
        [field: SerializeField] public int maxCapacity { get; protected set; }


        public virtual GameObject Create() => Instantiate(prefab);
        public virtual void OnGet(GameObject f) => f.gameObject.SetActive(true);
        public virtual void OnRelease(GameObject f) => f.gameObject.SetActive(false);
        public virtual void OnDestroyPoolObject(GameObject f) => Destroy(f.gameObject);
    }
}

