using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFSM : MonoBehaviour
{
    public AudioSource soundeffect;
    private PlayerBaseState currentState;
    public GameObject MinigamePrefab;
    public bool panelcreated=false;

    public int moneya;
    public int moneyb;

    float spawndecrease = 3;

    public float a = 10;
    public float b = 15;

    public readonly IdleState idlestate = new IdleState();
    public readonly BrokenState brokenstate = new BrokenState();

    private void Start()
    {
        TransitionState(idlestate);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);

    }
    public void CreatePanel()
    {
        if (a > spawndecrease && b > spawndecrease) { 
            a -= spawndecrease;
            b -= spawndecrease;
        }
        GameObject newpop = Instantiate(MinigamePrefab) as GameObject;
        newpop.transform.SetParent(GameObject.FindGameObjectWithTag("WallPanel").transform, false);
        LinkedComponent lc = newpop.GetComponent < LinkedComponent >();
        lc.monA = moneya;
        lc.monB = moneyb;
        lc.timeA = a;
        lc.timeB = b;
        lc.item = this;
        panelcreated = true;
    }

}
