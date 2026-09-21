using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected Rigidbody2D rb;
    public bool isLeft = false;
    public float moveSpeed = 2.0f;
    public bool isHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveEnemy();
    }

    virtual public void moveEnemy()
    {
        Debug.Log("supposed to move");
        Vector3 moveDir = new Vector3(1, 0, 0);
        if (isLeft && !isHit)
        {
            rb.AddForce(moveDir * moveSpeed);
        }
        else if (!isLeft && !isHit)
        {
            rb.AddForce((-1 * moveDir) * moveSpeed);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionInteraction(collision);
        
    }

    virtual public void collisionInteraction(Collision2D collision)
    {
        float distance;
        //if colliding with anything that isnt player or the ground switch direction
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("ground") || !collision.gameObject.CompareTag("PickUp"))
        Debug.Log("supposed to switch");
        isLeft = !isLeft;

        if (collision.gameObject.CompareTag("Player"))
        {
            //calculate the distance between the colliding object and this game object
            distance = Vector3.Distance(collision.transform.position, this.transform.position);
            Debug.Log(distance);

            //if the player is jumped on head play the function to dictate their behavior
            if (distance > 1.4f && collision.transform.position.y > this.transform.position.y)
            {
                Debug.Log("supposed to stomp enemy");
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                //makes player jump/bounce
                player.stompJump();
                getJumpedOn();
            }
        }
        


        
        

    }

    virtual public void getJumpedOn()
    {

    }
}
