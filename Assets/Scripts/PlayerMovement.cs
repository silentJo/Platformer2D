using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 250;
    public float jumpForce = 300;
    public float climbSpeed = 150;

    [HideInInspector]
    public bool isInClimbingZone;

    public static PlayerMovement instance;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;
    private ClimbingZone climbingZone;
    private float horizontalMovement;
    private float verticalMovement;
    private bool isJumping;
    private bool isGrounded;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PlayerMovement in the scene.");
            return;
        }
        instance = this;
    }

    void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {

        if (isInClimbingZone)
        {
            if (Input.GetKey("z") || Input.GetKey("s"))
            {
                animator.SetBool("isClimbing", true);
                climbingZone.topCollider.isTrigger = true;
                Vector3 targetVelocity = new Vector2(0, _verticalMovement);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            }
            else
            {
                animator.SetBool("isClimbing", false);
                climbingZone.topCollider.isTrigger = false;
                Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            }
        }
        else
        {
            if (climbingZone != null) climbingZone.topCollider.isTrigger = false;
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            animator.SetBool("isClimbing", false);
        }
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

        if (isGrounded) animator.SetBool("isJumping", isJumping);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f) spriteRenderer.flipX = false;
        else if (_velocity < -0.1f) spriteRenderer.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ClimbingZone"))
        {
            isInClimbingZone = true;
            climbingZone = collision.GetComponent<ClimbingZone>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ClimbingZone"))
        {
            isInClimbingZone = false;
            climbingZone = null;
        }
    }
}