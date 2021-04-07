using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    float currenttime;
    float randomtime;

    public override void CreatePanel(ItemFSM Item)
    {
    }

    public override void EnterState(ItemFSM Item)
    {
        if (Item.soundeffect != null)
        {
            Item.soundeffect.UnPause();
        }

        currenttime = Time.time;
        randomtime = Random.Range(Item.a, Item.b);
    }

    public override void UpdateState(ItemFSM Item)
    {

        if (Time.time > currenttime + randomtime)
        {
            Item.TransitionState(Item.brokenstate);
        }
    }
}
