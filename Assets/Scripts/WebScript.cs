using GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebScript : MonoBehaviour
{
    public SpriteRenderer[] sprite;
    int imagecount;
    int maximages = 5;
    Color color;
    float alpha = 0.00001f;
    private void Start()
    {
        imagecount = 0;
        color.r = 255;
        color.g = 255;
        color.b = 255;
        color.a = 0;
        for(int i = 0; i < sprite.Length; i++)
        {
            sprite[i].color = color;
        }
    }
    protected virtual void OnEnable()
    {
        GameEventManager.AddListener<ItemBoughtEvent>(OnItemBoughtEvent);
        GameEventManager.AddListener<MoneyEarnedEvent>(OnMoneyEarnedEvent);
    }
    protected virtual void OnDisable()
    {
        GameEventManager.RemoveListener<MoneyEarnedEvent>(OnMoneyEarnedEvent);
        GameEventManager.RemoveListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    public virtual void OnMoneyEarnedEvent(MoneyEarnedEvent e)
    {
        alpha += 0.00001f;
        if (color.a >= 0.05f)
        {
            color.a -= 0.05f;
        }

    }
    public virtual void OnItemBoughtEvent(ItemBoughtEvent e)
    {
        //decreases web's opacity, increases speed of opacity increase
        //buying items reset the current web image's opacity to 0
        color.a = 0;

        sprite[imagecount].color = color;
        if (imagecount < sprite.Length-1)
        {
            Color colortemp;
            colortemp.r = 255;
            colortemp.g = 255;
            colortemp.b = 255;
            colortemp.a = 0;
            sprite[imagecount + 1].color = colortemp;
        }
        alpha += 0.00001f;
    }

    private void FixedUpdate()
    {
        changeAlphaAll();
    }
    
    void changeAlpha(int imageno)
    {
        color.a += alpha;
        if (color.a >= 1)
        {
            color.a = 1;
        }
        sprite[imageno].color = color;
    }

    void changeAlphaAll()
    {
        if (imagecount < sprite.Length - 1)
        {
            if (sprite[imagecount].color.a < 1)
            {
                changeAlpha(imagecount);
            }
            else { imagecount++; color.a = 0; }
        }
        else if (imagecount == sprite.Length - 1)
        {
            if (sprite[imagecount].color.a < 1)
            {
                changeAlpha(imagecount);
            }
        }
        else if (imagecount >= sprite.Length)
        {
            imagecount = sprite.Length - 1;
        }
        if (sprite[maximages-1].color.a >= 1)
        {
            GameEventManager.Raise(new WebGameOver());
        }
    }

    public void WebSpeedUp()
    {
        //debug button to speed up web stage
        if (imagecount < 4)
        {
            Color colortemp = new Color(1, 1, 1, 1);
            sprite[imagecount].color=colortemp;
            imagecount++;
        }
        else if (imagecount >= 4)
        {
            Color colortemp = new Color(1, 1, 1, 1);
            sprite[imagecount].color = colortemp;
        }

    }
}
