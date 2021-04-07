using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class Cocoonanimation : MonoBehaviour
{
    public GameObject Anim;
    private void OnEnable()
    {
        GameEventManager.AddListener<CocoonDestroyed>(OnCocoonDestroyed);
    }
    private void OnDisable()
    {
        GameEventManager.RemoveListener<CocoonDestroyed>(OnCocoonDestroyed);
    }
    void OnCocoonDestroyed(CocoonDestroyed e)
    {
        Vector3 vec=e.position.position;
        GameObject DestroyedAnim = Instantiate(Anim, vec, Quaternion.identity) as GameObject;
        StartCoroutine(DestroyObj(DestroyedAnim));
    }
    public IEnumerator DestroyObj(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }
}
