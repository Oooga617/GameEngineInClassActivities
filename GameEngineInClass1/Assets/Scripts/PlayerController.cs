using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float moveX;
    public float speed = 10.0f;
    public float jumpForce = 500.0f;
    bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("supposed to jump");
            isGrounded = false;
            Vector3 jumpF = new Vector3(0, jumpForce, 0);
            rb.AddForce(jumpF);
        }

    }

    private void FixedUpdate()
    {
        if (moveX != 0.0f)
        {
            Vector3 movement = new Vector3(moveX, 0, 0);
            rb.AddForce(movement*speed*Time.deltaTime,0.0f);
        }

        
    }
}
