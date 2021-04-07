using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using UnityEngine.UI;

public class ThrowawayStringDesc : MonoBehaviour
{
    public SceneChange scenechangescript;
    public GameObject self;
    int throwndesccount=0;
    int totalitems = 8;
    int ItemThrowncount = 0;
    public Text description;
    string[] throwndescriptions = { "Disgusting", "Useless", "Garbage","Hideous","Why did I bother","What am I doing wrong?","I hate this", "I...","I just..","I just wanted to fit in...",".......","I'm tired","......"};
    GameObject Item;
    private void OnEnable()
    {
        GameEventManager.AddListener<ItemThrown>(OnItemThrown);
    }
    private void OnDisable()
    {
        GameEventManager.RemoveListener<ItemThrown>(OnItemThrown);
    }
    public void OnItemThrown(ItemThrown e)
    {
        //Item clicked on
        Debug.Log(throwndesccount);
        description.text = throwndescriptions[throwndesccount];
        OpenPanel();
        Item = e.Item;
        if (throwndesccount < throwndescriptions.Length-1)
        {
            throwndesccount += 1;
        }
    }
    void thrownawaycheck()
    {
        if (ItemThrowncount == totalitems)
        {
            scenechangescript.PlayGame();
        }
    }

    void OpenPanel()
    {
        if (self != null)
        {
            self.SetActive(true);
        }
    }
    public void ThrowAway()
    {
        //Item destroyed
        GameEventManager.Raise(new BDItemDestroyed());
        Destroy(Item);
        self.SetActive(false);
        ItemThrowncount += 1;
        thrownawaycheck();
    }
}
