using GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject self;
    public Rigidbody2D hook;
    public GameObject[] linkPrefab;
    public int links = 5;
    int monA = 3;
    int monB = 6;

    private void Start()
    {
        GenerateRope();
    }


    void GenerateRope()
    {
        //Generates rope by randomly selecting from an array of link prefabs
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < links; i++)
        {
            int a = Random.Range(0, linkPrefab.Length-1);
            GameObject link = Instantiate(linkPrefab[a], transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            previousRB = link.GetComponent<Rigidbody2D>();
        }
    }

    private void OnDestroy()
    {
        GameEventManager.Raise(new MoneyEarnedEvent(monA,monB));
    }
}
