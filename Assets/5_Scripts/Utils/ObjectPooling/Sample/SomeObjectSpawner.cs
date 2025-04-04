using UnityEngine;

namespace ObjectPooling
{
    public class SomeObjectSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPoolSettings obj;

        void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject obj = ObjectPool.Spawn(this.obj);
                obj.transform.position = new Vector3(i * 2, 0, 0);
            }
        }
    }
}


