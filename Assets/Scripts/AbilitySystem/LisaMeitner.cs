using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/LisaMeitner")] // This allow us to create instances of this as an asset using the create menu in unity.

public class LisaMeitner : Ability
{
    private GameObject player;
    public override void Initialize(GameObject obj)
    {
        player = obj;
    }

    public override void TriggerAbility()
    {
        
    }
}
