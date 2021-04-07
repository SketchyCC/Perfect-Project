using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenState : PlayerBaseState
{
    float currenttime;
    float randomtime;
    public override void CreatePanel(ItemFSM Item)
    {
        Item.CreatePanel();
    }

    public override void EnterState(ItemFSM Item)
    {
        if (Item.soundeffect != null)
        {
            Item.soundeffect.Pause();
        }
        CreatePanel(Item);
        currenttime = Time.time;
        randomtime = Random.Range(Item.a, Item.b);

    }

    public override void UpdateState(ItemFSM Item)
    {

    }
}
