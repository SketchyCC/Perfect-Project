using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    //Displays money, but nothing else... 
    public Text text;
    void Start()
    {
        Display(text);
    }

    void Update()
    {
        Display(text);
    }
    public void Display(Text t)
    {
        t.text = "$"+GameManager2.MoneyinWallet.ToString();
    }
}
