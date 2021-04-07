using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class WebTrigger : MonoBehaviour
{
    private bool isQuitting = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            StartCoroutine(DelayDestroy());
        }

    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(transform.parent.gameObject);
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if (!isQuitting)
        {
            GameEventManager.Raise(new CocoonDestroyed(transform));
        }
    }
}
