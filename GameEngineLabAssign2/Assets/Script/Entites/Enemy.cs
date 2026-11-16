using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 25.0f;
    bool isLeft = false;
    Vector2 moveDir = new Vector2(1, 0);
    //this basically determines from the origin to the player on collision how high up in terms of the difference between their y axises should be.
    public float heightLimit = 1.5f;
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isLeft)
        {
            rb.AddForce(moveDir * moveSpeed);
        }
        else
        {
           rb.AddForce(-1*moveDir * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if its not touching the player, go to the other direction
        if (!collision.gameObject.CompareTag("Player"))
        {
            isLeft = !isLeft;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //get the distance between each other on the y axis
            float distance = collision.transform.position.y - this.transform.position.y;
            Debug.Log(distance);
            //if high enough when jumped on / player jumps on them, kill enemy
            if (distance >= heightLimit)
            {
                Destroy(this.gameObject);
            }
            //else kill player
            else
            {
                collision.gameObject.GetComponent<PlayerController>().killPlayer();
            }
        }
    }
}
