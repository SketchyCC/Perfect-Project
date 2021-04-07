using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class MirrorScript : MonoBehaviour
{
    public GameObject[] MirrorPanel=new GameObject[5];
    int activepanel=0;
    int itemboughtcount = 0;

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        MirrorPanel[activepanel].SetActive(false);
    }
    public void OpenMirror()
    {
        if (MirrorPanel[activepanel].activeSelf == false)
        {
            if (activepanel > 0)
            {
                MirrorPanel[activepanel - 1].SetActive(false);
            }
            MirrorPanel[activepanel].SetActive(true);
            StartCoroutine(Delay());
        }
    }
    void OnItemBoughtEvent(ItemBoughtEvent e)
    {
        itemboughtcount++;
        //opens mirror for every scene/color change

        switch (itemboughtcount)
        {
            default:
                break;
            case 3:
                activepanel = 1;
                OpenMirror();
                break;
            case 5:
                activepanel = 2;
                OpenMirror();
                break;
            case 7:
                activepanel = 3;
                OpenMirror();
                break;
            case 9:
                activepanel = 4;
                OpenMirror();
                break;
        }
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
