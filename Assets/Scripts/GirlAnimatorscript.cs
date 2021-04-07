using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class GirlAnimatorscript : MonoBehaviour
{
    public Animator anim;
    int itemboughtcount;

    private void Awake()
    {
        anim.SetInteger("State", 0);
    }
    private void OnEnable()
    {
        GameEventManager.AddListener<GameEvent_OpenCatalogue>(OnCatalogueOpen);
        GameEventManager.AddListener<GameEvent_CloseCatalogue>(OnCatalogueClose);
        GameEventManager.AddListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    private void OnDisable()
    {
        GameEventManager.RemoveListener<GameEvent_OpenCatalogue>(OnCatalogueOpen);
        GameEventManager.RemoveListener<GameEvent_CloseCatalogue>(OnCatalogueClose);
        GameEventManager.RemoveListener<ItemBoughtEvent>(OnItemBoughtEvent);
    }
    void OnCatalogueOpen(GameEvent_OpenCatalogue e)
    {
        anim.SetBool("IsReading", true);
    }
    void OnCatalogueClose(GameEvent_CloseCatalogue e)
    {
        anim.SetBool("IsReading",false);
    }
    void OnItemBoughtEvent(ItemBoughtEvent e)
    {
        itemboughtcount++;
        switch (itemboughtcount)
        {
            default:
                break;
            case 3:
                anim.SetInteger("State", 1);
                break;
            case 5:
                anim.SetInteger("State", 2);
                break;
            case 7:
                anim.SetInteger("State", 3);
                break;
            case 9:
                anim.SetInteger("State", 4);
                break;
        }
    }
}
