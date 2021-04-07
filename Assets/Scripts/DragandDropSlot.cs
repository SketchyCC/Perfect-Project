using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameEvents;

public class DragandDropSlot : MonoBehaviour,IDropHandler
{
    public GameObject Prefab;
    public GameObject IteminSlot;
    public AudioClip soundeffect;
    public Animator anim;
    float timeondrop;
    float timedelaytoclose;

    LinkedComponent lc;
    private void Start()
    {
        lc = GetComponentInParent<LinkedComponent>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //when item is dropped in slot, 'fixed' animation plays and the panel is destroyed
        if (soundeffect != null)
        {
            GameEventManager.Raise(new ItemSoundOnDestroy(soundeffect));
        }
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        Destroy(IteminSlot);
        anim.SetBool("IsRepaired", true);
        lc.LinkedTransition();
        StartCoroutine(DestroyPanel());
    }
    public IEnumerator DestroyPanel()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(Prefab);
    }
}
