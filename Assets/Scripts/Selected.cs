using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    public ItemDescription Itemdescription;
    public InstantiateItem BuyItemButton;
    public void SelectedItem()
    {
        BuyItemButton.itemdesc = Itemdescription;
    }
}
