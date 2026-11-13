using UnityEngine;
using UnityEngine.Pool;
using System.Collections;



/*
public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField] GameObject goomba, koopa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/


/*namespace Chapter.ObjectPool
{
    public class DroneObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        public IObjectPool<Drone> Pool
        {
            get
            {
                if (_pool == null)
                {
                    _pool = new ObjectPool<Drone>(CreatedPooledItem, OnTakeFromPool,
                        OnReturnedToPool, OnDestroyPoolObject, true, stackDefaultCapacity,
                        maxPoolSize);
                }
                return _pool;
            }
        }
        private IObjectPool<DroneObjectPool> _pool;

        private Drone CreatedPooledItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Drone drone = go.AddComponent<Drone>();

            go.name = "Drone";
            drone.Pool = Pool;
            return drone;
        }
        private void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }
        private void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }
        private void OnDestroyPoolObject (Drone drone)
        {
            Destroy(drone.gameObject);
        }
        public void Spawn()
        {
            var amount = Random.Range(1, 10);
            for (int i = 0; i < amount; ++i)
            {
                var drone = Pool.Get();

                drone.transform.position = Random.insideUnitSphere * 10;
            }
        }
    }

}

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    { 
        public IObjectPool<Drone> Pool { get; set; }
        public float currentHealth;
        [SerializeField]
        private float maxHealth = 100.0f;
        [SerializeField]
        private float timeToSelfDestruct = 3.0f;
        private void Start()
        {
            currentHealth = maxHealth;
        }
        private void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }
        void ReturnToPool()
        {
            Pool.Release(this);
        }
        void ResetDrone()
        {
            currentHealth = maxHealth;
        }
        public void AttackPlayer()
        {
            Debug.Log("Attack player!");
        }
        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0.0f)
            {
                ReturnToPool();
            }
        }
    }

}*/

