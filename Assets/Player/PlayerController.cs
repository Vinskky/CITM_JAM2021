using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 600.0f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundChecker;
    [Range(0, .3f)] [SerializeField] private float movementSmother = .05f;

    private bool onGround;
    private float groundRadius = .2f;
    private Rigidbody2D rb;
    private bool isLeft = false;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        onGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundMask);

        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Movement(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Movement(true);
        }
    }

    private void Movement(bool isLeft)
    {
        int direction = 1;
        if (isLeft)
        {
            direction = -1;
        }
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(direction * 5.0f, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmother);
    }
}
