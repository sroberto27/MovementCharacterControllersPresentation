using UnityEngine;

public class CattoMovement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask ground;
    public float moveInput;
    public float cattoSpeed;
    public float cattoJumpForce;

    private Rigidbody2D cattoRigidbody2D;
    private Animator cattoAnimator;

    private bool cattoIsFacingRight = true;
    private bool cattoIsJumping = false;
    private bool cattoIsGrounded = false;

    void Start()
    {
        cattoRigidbody2D = GetComponent<Rigidbody2D>();
        cattoAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        cattoIsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

        moveInput = Input.GetAxis("Horizontal");

        if (cattoIsGrounded)
        {
            cattoAnimator.SetFloat("Velocity", Mathf.Abs(moveInput));
        }

        if (Input.GetButtonDown ("Jump") && cattoIsGrounded)
        {
            cattoIsJumping = true;
            cattoAnimator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && cattoIsGrounded)
        {
            cattoAnimator.SetBool("Crouch", true);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            cattoAnimator.SetBool("Crouch", false);
        }
    }

    private void FixedUpdate()
    {
        cattoRigidbody2D.velocity = new Vector2(moveInput * cattoSpeed, cattoRigidbody2D.velocity.y);

        if (cattoIsFacingRight == false && moveInput > 0)
        {
            FlipCatto();
        }
        else if (cattoIsFacingRight == true && moveInput < 0)
        {
            FlipCatto();
        }

        if (cattoIsJumping)
        {
            cattoRigidbody2D.AddForce(new Vector2(0f, cattoJumpForce));

            cattoIsJumping = false;
        }
    }

    private void FlipCatto()
    {
        cattoIsFacingRight = !cattoIsFacingRight;
        
        Vector3 cattoScale = transform.localScale;
        cattoScale.x *= -1;

        transform.localScale = cattoScale;
    }
}
