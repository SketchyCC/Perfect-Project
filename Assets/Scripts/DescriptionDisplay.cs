using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionDisplay : MonoBehaviour
{
    public Text text;
    public InstantiateItem ItemScript;

    void Update()
    {
        if (ItemScript.itemdesc != null)
        {
            Display(text);
        }
    }
    void Display(Text t)
    {
        t.text=ItemScript.itemdesc.Description;
    }
}
