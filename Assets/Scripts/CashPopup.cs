using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashPopup : MonoBehaviour
{
    Text text;
    float disappearTimer = 1f;
    Color textcolor;
    private void Awake()
    {
        text = transform.GetComponentInChildren<Text>();
        textcolor = text.color;
    }

    private void Update()
    {
        float moveYSpeed = 20f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textcolor.a -= disappearSpeed * Time.deltaTime;
            text.color = textcolor;
            if (textcolor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
