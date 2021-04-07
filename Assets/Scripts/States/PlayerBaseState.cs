using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{

    public abstract void EnterState(ItemFSM Item);
    public abstract void UpdateState(ItemFSM Item);
    public abstract void CreatePanel(ItemFSM Item);
}
