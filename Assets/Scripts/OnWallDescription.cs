using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class OnWallDescription : MonoBehaviour
{
    //Item description for bought items
    public string desc1;
    public string desc2;
    public string desc3;
    int itemcount;
    string activedescription;

    private void Awake()
    {
        SetDescription();
    }
    public virtual void OnEnable()
    {
        GameEventManager.AddListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    public virtual void OnDisable()
    {
        GameEventManager.RemoveListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    private void OnMouseOver()
    {
        GameEventManager.Raise(new ItemHoverOver(activedescription));
    }
    private void OnMouseExit()
    {
        GameEventManager.Raise(new ItemHoverExit());
    }
    public void OnItemBoughtEvent(ItemBoughtEvent e)
    {
        SetDescription();
    }
    void SetDescription()
    {
        itemcount = GameManager2.itemsonwall;
        int state = 0;
        if (itemcount <= 4)
        {
            state = 1;
        }
        else if (itemcount < 9 && itemcount >= 5)
        {
            state = 2;
        }
        else if (itemcount ==9)
        {
            state = 3;
        }
        switch (state)
        {
            case (1):
                activedescription = desc1;
                break;
            case (2):
                activedescription = desc2;
                break;
            case (3):
                activedescription = desc3;
                break;
            default:
                break;
        }
    }
}
