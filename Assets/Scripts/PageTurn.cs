using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;

public class PageTurn : MonoBehaviour
{
    //pretty clunky page turn script, but it works
    public GameObject[] pages;
    int currentpage = 0;
    public Button ForwardButton;
    public Button BackButton;

    private void Start()
    {
        Debug.Log("Hi");
        BackButton.interactable = false;
        ForwardButton.interactable = true;
    }
    public void TurnPageForward()
    {
        if (currentpage < pages.Length - 1)
        {
            pages[currentpage].SetActive(false);
            pages[currentpage + 1].SetActive(true);
            currentpage++;
        }

        CheckPage();
        GameEventManager.Raise(new GameEvent_PageTurn());
    }
    public void TurnPageBack()
    {
        if (currentpage > 0)
        {
            pages[currentpage].SetActive(false);
            pages[currentpage - 1].SetActive(true);
            currentpage--;
        }

        CheckPage();
        GameEventManager.Raise(new GameEvent_PageTurn());
    }
    void CheckPage()
    {
        Debug.Log(currentpage);
        if (currentpage == 0)
        {
            BackButton.interactable = false;
        }
        else if (currentpage == pages.Length - 1)
        {
            ForwardButton.interactable = false;
        }
        else
        {
            BackButton.interactable = true;
            ForwardButton.interactable = true;
        }
    }
}
