using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebDragandDrop : MonoBehaviour
{
    private bool selected;
    private bool walltouched;
    Vector2 previousGrabPos;
    float speedlimiter = 0.4f;

    void Update()
    {
        if (selected == true)
        {
            GrabObject();
        }
        if (Input.GetMouseButtonUp(0) && selected == true)
        {
            DropObject();
            selected = false;
        }
    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            selected = true;


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetType()==typeof(BoxCollider2D)) {

            selected = false;
        }

    }
    void GrabObject()
    {
        previousGrabPos = transform.position;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }

    void DropObject()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 throwVector = (Vector2)transform.position - previousGrabPos;
        float speed = throwVector.magnitude / Time.deltaTime;
        Vector2 throwVelocity = speed * speedlimiter * throwVector.normalized;
        rb.velocity = throwVelocity;

    }
}
