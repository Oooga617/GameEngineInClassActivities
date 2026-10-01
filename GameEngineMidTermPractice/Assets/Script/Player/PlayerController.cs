using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    public float jumpForce = 25.0f;
    private float moveX;
    Rigidbody2D rb;
    bool hasJumped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && hasJumped == false)
        {
            Debug.Log("supposed to jump");
            hasJumped = true;
            rb.AddForce(Vector2.up * jumpForce);
            hasJumped = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveX != 0)
        {
            Vector2 force = new Vector2(moveX * moveSpeed, 0);
            rb.AddForce(force);
        }
       

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && hasJumped == true)
        {
            hasJumped = false;
        }
    }
}
