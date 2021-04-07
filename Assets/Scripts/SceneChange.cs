using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameEvents;

public class SceneChange : MonoBehaviour
{
    public Animator sceneanimation;
    public Animator Canvasanimation;
    public float TransitionTime;
    public string scenename;
    public void changescene()
    {
        GoToScene(scenename);
    }
    public void GoToScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void PlayGame()
    {
        //pretty bad name, it ended up being used for general scene changes
        StartCoroutine(PlayGameTransition());
    }

    public IEnumerator PlayGameTransition()
    {
        sceneanimation.SetTrigger("Start");
        if (Canvasanimation != null)
        {
            Canvasanimation.SetTrigger("Start");
        }
        yield return new WaitForSeconds(TransitionTime);
        GoToScene(scenename);
    }

    public void PlayGameDelay()//used in ending.
    {
        StartCoroutine(GameDelay());
    }
    public IEnumerator GameDelay()
    {
        yield return new WaitForSeconds(6f);
        PlayGame();
    }
}
