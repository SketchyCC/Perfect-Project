using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class ItemColour : MonoBehaviour
{
    public SpriteRenderer spriterender;
    Color[] colors= new Color[5];

    [Header("Colors")]
    public float r1;
    public float g1;
    public float b1;

    public float r2;
    public float g2;
    public float b2;

    public float r3;
    public float g3;
    public float b3;

    public float r4;
    public float g4;
    public float b4;

    public float r5;
    public float g5;
    public float b5;

    //color rgb values were individually calibrated so they go well with other objects in the scene, at least i hope they do

    private void Awake()
    {
        colors[0] = new Color(r1/255f, g1/255f, b1/255f, 1);
        colors[1] = new Color(r2 / 255f, g2 / 255f, b2 / 255f, 1);
        colors[2] = new Color(r3 / 255f, g3 / 255f, b3 / 255f, 1);
        colors[3] = new Color(r4 / 255f, g4 / 255f, b4 / 255f, 1);
        colors[4] = new Color(r5 / 255f, g5 / 255f, b5 / 255f, 1);
        CheckColor();
    }
    void CheckColor()
    {
        int itemboughtcount = GameManager2.itemsonwall;
        switch (itemboughtcount)
        {
            default:
                break;
            case 0:
                SetColor(colors[0]);
                break;
            case 1:
                SetColor(colors[0]);
                break;
            case 3:
                SetColor(colors[1]);
                break;
            case 5:
                SetColor(colors[2]);
                break;
            case 7:
                SetColor(colors[3]);
                break;
            case 9:
                SetColor(colors[4]);
                break;
        }
    }
    void SetColor(Color color)
    {
        spriterender.color = color;
    }
    void OnItemBoughtEvent (ItemBoughtEvent e)
    {
        CheckColor();
    }

    private void OnEnable()
    {
        GameEventManager.AddListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    private void OnDisable()
    {
        GameEventManager.RemoveListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
}
