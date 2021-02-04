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
    private float gravityDir = 1;
    private bool invertGravity = false;
    public List<string> cards;
    private int cardsNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        cards = new List<string>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        onGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundMask);
        if(jumpRequest && onGround)
        Jump();

        SmoothJump();

        if(invertGravity)
        {
            gravityDir *= -1;
            invertGravity = false;
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

        if (gravityDir <= -1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -180), Time.deltaTime / 0.1f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime / 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Card")){
            PickUpCard(collision.gameObject);

            cardsNumber++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("GravityZone"))
        {
            invertGravity = true;
            
        }
    }
    private void Movement(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * velocity, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(gravityDir * Vector2.up*jumpForce,ForceMode2D.Impulse);
        jumpRequest = false;
    }
    private void SmoothJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = gravityDir * fallForce;
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = gravityDir * smallJumpForce;
        }
        else
        {
            rb.gravityScale = gravityDir * 1f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChecker.position, groundRadius);
    }

    private void PickUpCard(GameObject card)
    {
        Destroy(card);
    }

    public int GetCardsNumber()
    {
        return cardsNumber;
    }
}