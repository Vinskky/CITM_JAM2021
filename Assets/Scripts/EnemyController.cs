using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    bool right = false;

    private Rigidbody2D rb;
    [SerializeField] private GameObject enemyRoot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (right == true)
        {
           rb.transform.position = new Vector3(rb.transform.position.x + 5 * Time.deltaTime, rb.transform.position.y, rb.transform.position.z);
        }
        else if (right == false)
        {
            rb.transform.position = new Vector3(rb.transform.position.x - 5 * Time.deltaTime, rb.transform.position.y, rb.transform.position.z);
        }

        this.gameObject.GetComponent<SpriteRenderer>().flipX = right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWall"))
        {
            right = !right;
        }

        if (collision.CompareTag("Weapon"))
        {
            Die(enemyRoot);
        }
    }

  

    private void Die(GameObject enemyRoot)
    {
        Destroy(enemyRoot);
    }
}