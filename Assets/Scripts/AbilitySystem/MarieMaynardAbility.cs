using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/MarieMaynardAbility")] // This allow us to create instances of this as an asset using the create menu in unity.
public class MarieMaynardAbility : Ability
{

    
    public override void Initialize(GameObject obj)
    {

    }

    public override void TriggerAbility()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (GameObject item in boxes)
        {
            item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            item.GetComponent<Rigidbody2D>().mass = 3;
        }
    }
}
