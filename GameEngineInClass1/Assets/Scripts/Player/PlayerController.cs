using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    //public InputAction playerControls;
    public PlayerInputControls playerInputControls;

    float moveX;
    public float speed = 10.0f;
    public float jumpForce = 500.0f;
    bool isGrounded = true;

    Vector2 moveDir;
    private InputAction move, jump, fire;

    //when sliding down flagPole disable controls
    bool isDisabled = false;

    //allow you to shoot fire balls if you pick them up
    bool hasPickedUpFireFlower = false;
    //determines where to shoot out fireballs
    bool isFacingLeft = false;
    //color determines if you pick up power up
    Color white = Color.white; //this the regular player color, so one hit you are dead
    Color orange = Color.orange; //you have fire flower, if hit then you revert to white

    private void Awake()
    {
        //gets movement input direction value
        playerInputControls = new PlayerInputControls();
    }

    private void OnEnable()
    {
        //initializes the inputs from the input system
        move = playerInputControls.Player.Move;
        move.Enable();
        fire = playerInputControls.Player.Fire;
        fire.Enable();
        jump = playerInputControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        
        
    }
    void OnDisable()
    {
        //disables the inputs
        move.Disable();
        jump.Disable();
        fire.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gets access to rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //handle movement from using the value of the move direction 
        //from the input
        
        moveDir = move.ReadValue<Vector2>();

    }

    //this makes the player jump
    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded && !isDisabled)
        {
            Debug.Log("jump");
            isGrounded = false;
            Vector3 jumpF = new Vector3(0, jumpForce, 0);
            rb.AddForce(jumpF);
        }
        

    }

    //if touching the ground allow the player to jump again/or touching something below them allow to jump again
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y < this.transform.position.y && !isGrounded)
        {
            isGrounded = true;
        }
        //if player touch koopa shell kill the player
        else if (collision.gameObject.CompareTag("Shell"))
        {
            this.gameObject.SetActive(false);
        }
        //calculate the distance between the colliding object and this game object
        float distance = Vector3.Distance(collision.transform.position, this.transform.position);
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player touches the enemy collider2D, kill/hurt the player
        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.GetComponent<Enemy>().isHit == false)
        {
            if (!hasPickedUpFireFlower)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                spriteRenderer.color = white;
                hasPickedUpFireFlower = false;
            }

        }
        
    }

    private void FixedUpdate()
    {
        //uses a force to move the player
        if (!isDisabled)
            rb.AddForce(moveDir * speed, 0.0f);
    }

    public void stompJump()
    {
        //the jump force is halfed
        Vector3 jumpF = new Vector3(0, jumpForce*0.5f, 0);
        rb.AddForce(jumpF);
    }

    //gives the player the powerup depending on the id of the pick up
    public void givePowerUp(string id)
    {
        if (id == "FireFlower" && !hasPickedUpFireFlower)
        {
            hasPickedUpFireFlower = true;
            spriteRenderer.color = orange;
        }
    }

    void shootFireBall()
    {

    }
}
