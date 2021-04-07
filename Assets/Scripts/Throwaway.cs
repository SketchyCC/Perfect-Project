using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class Throwaway : MonoBehaviour
{
    public GameObject go;
    public void AskToThrow()
    {
        GameEventManager.Raise(new ItemThrown(go));
    }

}
