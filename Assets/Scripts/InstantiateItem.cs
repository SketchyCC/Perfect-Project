using GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateItem : MonoBehaviour
{
    public ItemDescription itemdesc;
    public GameObject PopupPrefab;


    public void BuyItem()
    {
        if (itemdesc != null)
        {
            if(itemdesc.isbought == false) { 
                if (GameManager2.MoneyinWallet >= itemdesc.Price)
                {
                    GameObject go=Instantiate(itemdesc.Prefab);
                    GameManager2.MoneyinWallet-= itemdesc.Price;
                    itemdesc.isbought = true;
                    itemdesc.Description = "Bought!";
                    GameEventManager.Raise(new ItemBoughtEvent());
                }
                else
                {
                    Createpopup("Not enough cash");
                }
            }
            else
            {
                Createpopup("Already bought");
            }

        }
    }

    public void Createpopup(string textpopup)
    {
        GameObject cashpopup = Instantiate(PopupPrefab)as GameObject;
        cashpopup.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Text text = cashpopup.GetComponentInChildren<Text>();
        text.text = textpopup;
    }
}
