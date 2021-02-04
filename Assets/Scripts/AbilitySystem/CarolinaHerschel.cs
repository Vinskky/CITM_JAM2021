using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/CarolinaHerschel")] // This allow us to create instances of this as an asset using the create menu in unity.
public class CarolinaHerschel : Ability
{

    private GameObject[] platforms;
    public bool moving = false;
    public override void Initialize(GameObject obj)
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    public override void TriggerAbility()
    {
        foreach (GameObject item in platforms)
        {
            if (moving) 
            { 
                item.GetComponent<Animator>().SetBool("Move", false);
                item.SetActive(false);
                moving = false;
            } else 
            { 
                item.GetComponent<Animator>().SetBool("Move", true);
                item.SetActive(true);
                moving = true;
            }

        }

    }
}
