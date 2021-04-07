using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public ItemFSM item;
    public Minigame() { }
    public Minigame(ItemFSM Item)
    {
        item = Item;
    }
}
