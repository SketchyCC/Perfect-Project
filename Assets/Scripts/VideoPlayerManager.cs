using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer video;
    public ToggleCatalogue tc;
    public GameObject OpeningButton;
    public GameObject go;
    public GameObject button;
    public void playvideo()
    {
        tc.Open();
        video.Prepare();
        video.Play();
        StartCoroutine(delaydestroy());
        StartCoroutine(TurnOnButton());
    }
    public IEnumerator delaydestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(OpeningButton);
        Destroy(go);
    }
    public IEnumerator TurnOnButton() {
        yield return new WaitForSeconds(12);
        button.SetActive(true);
    }
}
