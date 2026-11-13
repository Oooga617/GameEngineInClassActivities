using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] GameObject fireBall;
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;

    public IObjectPool<Projectile> Pool
    { 
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Projectile>(CreatedPooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject,
                    true, stackDefaultCapacity, maxPoolSize);
                
            }
            return _pool;
        }
    }

    private IObjectPool<Projectile> _pool;

    private Projectile CreatedPooledItem()
    {
        GameObject go = Instantiate(fireBall);
        Projectile projectile = go.GetComponent<Projectile>();

        go.name = "Projectile";
        projectile.Pool = Pool;
        return projectile;
    }
    private void OnReturnedToPool(Projectile p)
    {
        p.gameObject.SetActive(false);
    }
    private void OnTakeFromPool(Projectile p)
    {
        p.gameObject.SetActive(true);
    }
    private void OnDestroyPoolObject(Projectile p)
    {
        Destroy(p.gameObject);
    }
    public void Spawn(Transform pos, Vector2 dir)
    {
        var fBall = Pool.Get();
        fBall.SetShootDir(dir);
        fBall.transform.position = pos.position;
        fBall.transform.rotation = pos.rotation;

    }
}
