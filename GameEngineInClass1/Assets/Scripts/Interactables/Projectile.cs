using UnityEngine;
using System.Collections;
using UnityEngine.Pool;
using Unity.VisualScripting;

public class Projectile : MonoBehaviour
{
    public IObjectPool<Projectile> Pool
    { get; set; }
    Rigidbody2D rb;
    [SerializeField] private float timeToSelfDestruct = 3.0f;
    [SerializeField] private float speed = 10.0f;
    Vector2 shootingDir = new Vector2(1, 0);


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        StartCoroutine(SelfDestruct());
    }

    public void SetShootDir(Vector2 d)
    {
        shootingDir = d.normalized;
        rb.AddForce(shootingDir * speed,ForceMode2D.Impulse);
    }

 
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.SetActive(false);
        }
        ReturnToPool();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (!collision.gameObject.CompareTag("ground") || !collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }*/
}
