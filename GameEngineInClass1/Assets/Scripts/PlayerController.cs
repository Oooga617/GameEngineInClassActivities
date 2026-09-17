using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    //public InputAction playerControls;
    public PlayerInputControls playerInputControls;

    float moveX;
    public float speed = 10.0f;
    public float jumpForce = 500.0f;
    bool isGrounded = true;

    Vector2 moveDir;
    private InputAction move, jump;

    private void Awake()
    {
        playerInputControls = new PlayerInputControls();
    }

    
    private void OnEnable()
    {
        move = playerInputControls.Player.Move;
        move.Enable();
        jump = playerInputControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }
    void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("supposed to jump");
            isGrounded = false;
            Vector3 jumpF = new Vector3(0, jumpForce, 0);
            rb.AddForce(jumpF);
        }*/

        //moveDir = playerControls.ReadValue<Vector2>();
        moveDir = move.ReadValue<Vector2>();

    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("jump");
        isGrounded = false;
        Vector3 jumpF = new Vector3(0, jumpForce, 0);
        rb.AddForce(jumpF);

    }

    private void FixedUpdate()
    {
        /*
        if (moveX != 0.0f)
        {
            Vector3 movement = new Vector3(moveX, 0, 0);
            rb.AddForce(movement*speed*Time.deltaTime,0.0f);
        }*/
        rb.AddForce(moveDir * speed, 0.0f);

        
    }
}
