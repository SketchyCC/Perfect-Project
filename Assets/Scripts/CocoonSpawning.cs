using GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoonSpawning : MonoBehaviour
{
    public GameObject prefab;
    float x = 12;
    float y = 7.24f;
    float timeofspawn=10f;
    
    private void Start()
    {
        InvokeRepeating("spawnCocoon", 20f, timeofspawn);
    }

    protected virtual void OnEnable()
    {
        GameEventManager.AddListener < MoneyEarnedEvent > (OnMoneyEarnedEvent);
    }
    protected virtual void OnDisable()
    {
        GameEventManager.RemoveListener<MoneyEarnedEvent>(OnMoneyEarnedEvent);
    }

    public virtual void OnMoneyEarnedEvent(MoneyEarnedEvent e)
    {
        //rope spawning gets faster 
        if (timeofspawn > 1.5)
        {
            timeofspawn -= 0.1f;
        }
    }

    void spawnCocoon()
    {
        //spawns rope of random length
        GameObject cocoonrope = Instantiate(prefab, new Vector2(Random.Range(x, -x), y), Quaternion.identity)as GameObject;
        Rope rope = cocoonrope.GetComponent<Rope>();
        rope.links = Random.Range(3, 9);
    }
}
