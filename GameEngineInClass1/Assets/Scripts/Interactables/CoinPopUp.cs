using Unity.VisualScripting;
using UnityEngine;

public class CoinPopUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float lifeTime = 0.3f;
    public float pushForce = 5.0f;
    private float despawnTimer = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * pushForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (despawnTimer < lifeTime)
        {
            despawnTimer += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
