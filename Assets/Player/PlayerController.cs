using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float jumpForce = 0;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundChecker;
    public Animator animator;
    private bool onGround;
    private float groundRadius = 1.0f;
    private Rigidbody2D rb;
    private float velocity = 5.0f;
    private float fallForce = 2.5f;
    private float smallJumpForce = 2f;
    private bool jumpRequest = false;
    private float gravityDir = 1.0f;
    [SerializeField] private List<Image> abilities;
    private uint cardsNumber = 0;
    private uint lifes = 5;
    bool gravityAbility = false;
    bool gravityRequest = false;
    Vector3 lastCheckpointPos = Vector3.zero;
    private GameObject[] boxList;
    private bool isLeft = false;
    public Transform attackPoint;
    public float attackRange = 50f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxList = GameObject.FindGameObjectsWithTag("Box");
    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundMask);
        if(jumpRequest && onGround)
        Jump();

        SmoothJump();
        if (gravityAbility && gravityRequest)
        {
            InvertGravity();
            gravityRequest = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (dir.x*gravityDir < 0)
        {
            isLeft = true;
        }else if (dir.x*gravityDir > 0)
        {
            isLeft = false;
        }
        Movement(dir);
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (gravityDir <= -1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -180), Time.deltaTime / 0.1f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime / 0.1f);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("onGround", onGround);
      
       this.gameObject.GetComponent<SpriteRenderer>().flipX = isLeft;
        
       
        if (Input.GetKeyDown("c"))
        {
            foreach (var item in boxList)
            {
                item.GetComponent<BoxScript>().ResetPos();
            }
            rb.position = lastCheckpointPos;
        }
    }

    private void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            // Enemy die
            enemy.GetComponent<EnemyController>().Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Card"))
        {
            PickUpCard(collision.gameObject);
        }

        if (collision.CompareTag("Death"))
        {
            SceneManager.LoadScene("EndingScreen");
        }

        if(collision.)
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("GravityZone") && gravityAbility)
        {
            gravityRequest = true;
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
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
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
        switch (card.GetComponent<CardScript>().cardType)
        {
            case "Box":
                foreach (Image item in abilities)
                {
                    if(item.gameObject.name.Equals("BoxAbility"))
                    item.gameObject.SetActive(true);
                    this.tag = "Weapon";
                }
                break;
            case "Platform":
                foreach (Image item in abilities)
                {
                    if (item.gameObject.name.Equals("PlatformAbility"))
                        item.gameObject.SetActive(true);
                        gravityAbility = true;
                }
                break;
            case "Radioactive":
                foreach (Image item in abilities)
                {
                    if (item.gameObject.name.Equals("RadioactiveAbility"))
                        item.gameObject.SetActive(true);
                }
                break;
            case "Win":
                SceneManager.LoadScene("WinningScreen");
                break;
            default:
                break;
        }

        Destroy(card);
        cardsNumber += 1;
    }

    public uint GetCardsNumber()
    {
        return cardsNumber;
    }
    public void InvertGravity()
    {
        gravityDir *= -1;
    }

    public void AddLifes(uint lifes)
    {
        this.lifes += lifes;
    }
    public void SubstractLifes(uint lifes)
    {
        this.lifes -= lifes;
    }
    public uint GetLifesNumber()
    {
        return lifes;
    }
    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    public void SetCheckpointPos(Vector3 position)
    {
        lastCheckpointPos = position;
    }
}
