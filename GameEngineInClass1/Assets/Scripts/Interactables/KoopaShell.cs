using Unity.VisualScripting;
using UnityEngine;

public class KoopaShell : MonoBehaviour
{
    bool isLeft = false;
    public float shellSpeed = 6.0f;
    Rigidbody2D rb;
    Vector3 moveDir = new Vector3(1, 0, 0);
    GameManager gameManager;
    PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindWithTag("gm").GetComponent<GameManager>();
    }

    //set the direction of the shell
    public void setDir(bool left)
    {
        isLeft = left;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLeft)
        {
            rb.AddForce(moveDir * shellSpeed);
        }
        else if (!isLeft)
        {
            rb.AddForce((-1 * moveDir) * shellSpeed);
        }
    }

    //kill player and enemies when moving
    //otherwise go to the other direction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            //dont destroy the player game Object or it will cause an error with the camera follow script
            if (!collision.gameObject.CompareTag("Player"))
                Destroy(collision.gameObject);
            else
                player.playerDeath();


        }
        
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("ground") || !collision.gameObject.CompareTag("PickUp"))
        {
            isLeft = !isLeft;
        }
    }
}
