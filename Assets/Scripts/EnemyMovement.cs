using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool right = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 5 * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (!right)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 5 * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        this.gameObject.GetComponent<SpriteRenderer>().flipX = right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWall"))
        {
            right = !right;
        }
    }
}