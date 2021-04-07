using GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    //it's 2 because I messed up the first one and broke some of the code... 
    public static int itemsonwall = 0;
    public static int totalitems = 9;
    public static int MoneyinWallet = 0;
    SceneChange scenechangescript;

    private void Awake()
    {
        MoneyinWallet = 0;
        itemsonwall = 0;
    }
    private void Start()
    {
        scenechangescript = GetComponent<SceneChange>();
    }

    public void GiveCash()
    {
        //used for debug button
        MoneyinWallet += 100;
    }
    public void EarnMoney(int a, int b)
    {
        int moneyearned = Random.Range(a, b);
        MoneyinWallet += moneyearned;
    }
    public virtual void OnMoneyEarnedEvent(MoneyEarnedEvent e)
    {
        EarnMoney(e.moneyA, e.moneyB);
    }
    public virtual void OnItemBoughtEvent(ItemBoughtEvent e)
    {
        itemsonwall += 1;
    }
    public virtual void OnWebGameOver(WebGameOver e)
    {
        if (itemsonwall == totalitems)
        {
            GameEventManager.Raise(new GameOver());
            scenechangescript.PlayGame();
        }
    }

    protected virtual void OnEnable()
    {
        GameEventManager.AddListener<MoneyEarnedEvent>(OnMoneyEarnedEvent);
        GameEventManager.AddListener<ItemBoughtEvent>(OnItemBoughtEvent);
        GameEventManager.AddListener<WebGameOver>(OnWebGameOver);
    }

    protected virtual void OnDisable()
    {
        GameEventManager.RemoveListener<MoneyEarnedEvent>(OnMoneyEarnedEvent);
        GameEventManager.RemoveListener<ItemBoughtEvent>(OnItemBoughtEvent);
        GameEventManager.RemoveListener<WebGameOver>(OnWebGameOver);
    }
    
}
