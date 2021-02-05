using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Weapon"))
        {
            player.GetComponent<PlayerController>().SetCheckpointPos(this.gameObject.transform.position);
        }
    }
}
