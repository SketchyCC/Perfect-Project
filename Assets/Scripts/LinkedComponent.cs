using GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedComponent : MonoBehaviour
{
    public int monA, monB;
    public float timeA, timeB;
    public ItemFSM item;
    
    public void LinkedTransition()
    {
        GameEventManager.Raise(new MoneyEarnedEvent(monA, monB));
        StartCoroutine(DelayEnter());
    }
    public IEnumerator DelayEnter()
    {
        yield return new WaitForSeconds(1f);
        item.TransitionState(item.idlestate);
    }

}
