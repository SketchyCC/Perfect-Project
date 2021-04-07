using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class ToggleCatalogue : MonoBehaviour
{
    //Open and closes catalogue
    public GameObject Panel;

    public void Open()
    {
        if (Panel != null)
        {
            GameEventManager.Raise(new GameEvent_OpenCatalogue());
            Panel.SetActive(true);
        }
    }

    public void Close()
    {
        if (Panel != null)
        {
            GameEventManager.Raise(new GameEvent_CloseCatalogue());
            Panel.SetActive(false);
        }
    }

    public void TogglePanel()
    {
        if (Panel != null)
        {
            bool active = Panel.activeSelf;
            Panel.SetActive(!active);
        }
    }
}
