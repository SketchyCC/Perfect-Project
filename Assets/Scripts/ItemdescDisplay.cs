using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;

public class ItemdescDisplay : MonoBehaviour
{
    public Text text;
    public GameObject descriptionbox;
    private void Awake()
    {
        descriptionbox.SetActive(false);
    }
    private void OnEnable()
    {
        GameEventManager.AddListener<ItemHoverOver>(OnItemHoverOver);
        GameEventManager.AddListener<ItemHoverExit>(OnItemHoverExit);
    }
    private void OnDisable()
    {
        GameEventManager.RemoveListener<ItemHoverOver>(OnItemHoverOver);
        GameEventManager.RemoveListener<ItemHoverExit>(OnItemHoverExit);
    }

    void OnItemHoverOver(ItemHoverOver e)
    {
        descriptionbox.SetActive(true);
        text.text = e.description;
    }
    void OnItemHoverExit(ItemHoverExit e)
    {
        descriptionbox.SetActive(false);
    }
}
