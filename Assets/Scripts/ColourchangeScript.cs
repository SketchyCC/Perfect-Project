using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class ColourchangeScript : MonoBehaviour
{
    //color change script, originally for general use but I couldn't work out one for both walls and items
    int itemboughtcount=0;
    public SpriteRenderer Backwallcolor;
    public SpriteRenderer Sidewallcolor;
    public SpriteRenderer Floorcolor;

    Color color1 = new Color32(255, 255, 255,255);
    Color color2 = new Color32(217, 189, 164,255);
    Color color3 = new Color32(126, 105, 126,255);
    Color color4 = new Color32(23, 24, 120,255);
    Color color5 = new Color32(0, 0, 39,255);

    Color colorside1 = new Color32(234, 234, 234, 255);
    Color colorside2 = new Color32(196, 167, 143, 255);
    Color colorside3 = new Color32(104, 83, 104, 255);
    Color colorside4 = new Color32(0, 1, 100, 255);
    Color colorside5 = new Color32(0, 0, 18, 255);

    Color colorfloor1 = new Color32(212, 212, 212, 255);
    Color colorfloor2 = new Color32(174, 145, 121, 255);
    Color colorfloor3 = new Color32(84, 63, 84, 255);
    Color colorfloor4 = new Color32(0, 0, 76, 255);
    Color colorfloor5 = new Color32(0, 0, 0, 255);

    private void Awake()
    {
        SetColors(color1,colorside1,colorfloor1);
    }
    public void SetColors(Color colorback,Color colorside, Color colorfloor)
    {
        Backwallcolor.color = colorback;
        Sidewallcolor.color = colorside;
        Floorcolor.color = colorfloor;
    }
    protected virtual void OnEnable()
    {
        GameEventManager.AddListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    protected virtual void OnDisable()
    {
        GameEventManager.RemoveListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    public virtual void OnItemBoughtEvent(ItemBoughtEvent e)
    {
        Debug.Log("Changing colors");
        itemboughtcount++;
        switch (itemboughtcount)
        {
            default:
                break;
            case 3:
                SetColors(color2,colorside2,colorfloor2);
                break;
            case 5:
                SetColors(color3, colorside3, colorfloor3);
                break;
            case 7:
                SetColors(color4, colorside4, colorfloor4);
                break;
            case 9:
                SetColors(color5, colorside5, colorfloor5);
                break;
        }
            
    }

}
