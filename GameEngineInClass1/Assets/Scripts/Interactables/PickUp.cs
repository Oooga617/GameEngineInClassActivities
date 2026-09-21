using JetBrains.Annotations;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //make them move around or make them static.
    public bool isMoving = false;
    bool isLeft = false;
    public float moveSpeed = 10.0f;
    Rigidbody2D rb;
    public string id = "FireFlower";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 moveDir = new Vector3(1, 0, 0);
            if (isLeft)
            {
                rb.AddForce(moveDir * moveSpeed);
            }
            else
            {
                rb.AddForce((-1*moveDir) * moveSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("is hitting: " + collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().givePowerUp(id);
            Destroy(this.gameObject);
        }
    }
}
