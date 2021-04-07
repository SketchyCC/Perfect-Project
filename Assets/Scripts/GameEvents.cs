using UnityEngine;

namespace GameEvents
{

    //---------------------------------------------------------------------------------------------------
    // sample events without additional arguments

    public class GameEvent_Click : GameEvent { }
    public class GameEvent_CancelAction : GameEvent { }
    public class GameEvent_FinishLevel : GameEvent { }

    //---------------------------------------------------------------------------------------------------

    // sample events with additional arguments. Make sure these implement Validate()

    /// <summary>
    /// A list of the possible simplified Game Engine base events
    /// </summary>

    public class ItemThrown : GameEvent {
        public GameObject Item;
        public ItemThrown(GameObject _item)
        {
            Item = _item;
        }
    }
    public class BDItemDestroyed : GameEvent { }
    public class WebGameOver : GameEvent { }
    public class GameOver : GameEvent { }
    public class ItemBoughtEvent : GameEvent{}
    public class CocoonDestroyed : GameEvent
    {
        public Transform position;
        public CocoonDestroyed(Transform transform)
        {
            position = transform;
        }
    }
    public class MoneyEarnedEvent : GameEvent
    {

        public readonly int moneyA;
        public readonly int moneyB;
        public MoneyEarnedEvent(int a, int b)
        {
            moneyA = a;
            moneyB = b;
        }
    }
    public class GameEvent_OpenCatalogue : GameEvent { }
    public class GameEvent_CloseCatalogue : GameEvent { }
    public class GameEvent_StartGame : GameEvent { }
    public class GameEvent_PageTurn : GameEvent { }
    public class ItemHoverOver : GameEvent
    {
        public string description;
        public ItemHoverOver(string desc)
        {
            description = desc;
        }
    }
    public class ItemHoverExit : GameEvent { }
    public class ItemSoundOnDestroy : GameEvent
    {
        public AudioClip soundeffect;
        public ItemSoundOnDestroy(AudioClip _sound)
        {
            soundeffect = _sound;
        }
    }
  
}