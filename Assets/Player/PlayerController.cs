using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Range(0, 10)] [SerializeField] private float jumpForce = 0;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundChecker;
    [Range(0, .3f)] [SerializeField] private float movementSmother = .05f;

    private bool onGround;
    private float groundRadius = 1.0f;
    private Rigidbody2D rb;
    private bool isLeft = false;
    private float velocity = 5.0f;
    private float fallForce = 2.5f;
    private float smallJumpForce = 2f;
    private bool jumpRequest = false;
    private bool invertGravity = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        onGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundMask);
        if(jumpRequest && onGround)
        Jump();

        SmoothJump();

        if(invertGravity == true){
            rb.gravityScale *= -1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Movement(dir);
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;

        }

        


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "GravityZone")
        {
            invertGravity = !invertGravity;
        }
    }
    private void Movement(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * velocity, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        jumpRequest = false;
    }
    private void SmoothJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallForce;
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = smallJumpForce;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void Rotation()
    {
        if (rb.gravityScale < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChecker.position, groundRadius);
    }
}
