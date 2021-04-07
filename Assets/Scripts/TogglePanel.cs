using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
//toggles mirror panel in Breakdown scene
    public GameObject Panel;
    public void OpenPanel()
    {
        if (!Panel.activeSelf)
        {
            Panel.SetActive(true);
            StartCoroutine(Delay());
        }

    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        Panel.SetActive(false);
    }
}
