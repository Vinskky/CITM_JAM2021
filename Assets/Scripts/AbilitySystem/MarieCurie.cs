using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/MarieCurie")] // This allow us to create instances of this as an asset using the create menu in unity.

public class MarieCurie : Ability
{
    private GameObject player;
    public override void Initialize(GameObject obj)
    {
        player = obj;
    }

    public override void TriggerAbility()
    {
        player.GetComponent<PlayerController>().SubstractLifes(1);
    }
}
