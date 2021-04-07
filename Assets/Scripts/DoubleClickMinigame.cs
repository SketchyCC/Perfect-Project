using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClickMinigame : MonoBehaviour
{
    public GameObject Panel;
    public Animator anim;
    LinkedComponent lc;
    int clicked = 0;
    private void Start()
    {
        lc=GetComponentInParent<LinkedComponent>();
    }
    public void onclick()
    {
        clicked++;
        checkclick();
    }
    void checkclick()
    {
        if (clicked == 2)
        {
            anim.SetBool("IsRepaired", true);
            lc.LinkedTransition();
            StartCoroutine(DestroyPanel());
        }
    }
    public IEnumerator DestroyPanel()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(Panel);
    }
}
