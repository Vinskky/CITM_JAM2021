using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool right = false;
    private float damageRadius = 0.5f;
    [SerializeField] private LayerMask damageMask;
    private Rigidbody2D rb;
    [SerializeField]private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(rb.transform.position, damageRadius, damageMask))
        {
            Die();
        }
        if (right == true)
        {
           rb.transform.position = new Vector3(rb.transform.position.x + 5 * Time.deltaTime, rb.transform.position.y, rb.transform.position.z);
        }
        else if (right == false)
        {
            rb.transform.position = new Vector3(rb.transform.position.x - 5 * Time.deltaTime, rb.transform.position.y, rb.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWall"))
        {
            right = !right;
        }
        if (collision.CompareTag("Weapon"))
        {
            Die();
        }
    }

  

    private void Die()
    {
        Destroy(enemy);
    }
}