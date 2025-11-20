using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float move_speed = 5f;
    private Vector2 input;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRend;

    [Header("Salto")]
    [SerializeField]
    private float forceJump = 5f;
    private int saltosMaximos = 2;
    private int saltosDisponibles;
    private bool isGround = true;

    private InputSystem_Actions inputActions;
    private Vector3 initialPosition;

    private Animator anim;  
    public PlayerSoundController soundController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        anim= GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            saltosDisponibles = saltosMaximos;
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LevelManager.Instance.PlayerDied();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;

        }
        

    }
    // Update is called once per frame
    void Update()
    {
        // RUN / IDLE
        anim.SetFloat("speed", Mathf.Abs(input.x));

        // JUMP
        anim.SetBool("isJumping", !isGround);

        // FLIP DEL PERSONAJE
        if (input.x > 0)
        {
            spriteRend.flipX = false;
        }
        else if (input.x < 0)
        {
            spriteRend.flipX = true;
        }

    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OffMove;
        inputActions.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OffMove;
        inputActions.Player.Jump.canceled -= Jump;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();
    }

    private void OffMove(InputAction.CallbackContext ctx)
    {
        input = Vector2.zero;
    }

    private void FixedUpdate()
    {

        float newVelocityX = input.x * move_speed;

        float currentVelocityY = rb.linearVelocity.y;

        rb.linearVelocity = new Vector2(newVelocityX, currentVelocityY);
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (saltosDisponibles > 0)
        {
            rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            saltosDisponibles -= 1;
            soundController.playJump();

            isGround = false; //Activar la animación
        }
    }

    private void ResetPlayer()
    {
        gameObject.transform.position = initialPosition;
    }

    

}
