using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float deltaX, deltaY;
    private Rigidbody2D rb;

    public GameObject pauseScreen;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (pauseScreen.activeSelf)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x;
                    deltaY = touchPos.y;
                    break;

                case TouchPhase.Moved:
                    //transform.Translate (new Vector2(deltaX + touch.deltaPosition.x, touchPos.y + deltaY));
                    rb.velocity = (new Vector2(touch.deltaPosition.x, touchPos.y));
                    //Debug.DrawRay(new Vector3(deltaX, deltaY), (new Vector2(touch.deltaPosition.x, touchPos.y)));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }

}
