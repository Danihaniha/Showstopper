using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 worldPoint = cam.ScreenToWorldPoint(Input.touches[0].position);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if(hit.collider == null)
            {
                RemoveFocus();
                return;
            }

            if (hit.collider.GetComponent<ItemPickup>() != null)
            {
                var interactable = hit.collider.GetComponent<ItemPickup>();
                SetFocus(interactable);
                interactable.Interact();
                
                Debug.Log("You interacted with " + hit.collider.name);
            }
        }

        void SetFocus(Interactable newFocus)
        {
            if(newFocus != focus)
            {
                if(focus != null)
                    focus.OnDefocused();

                focus = newFocus;
                
            }
            newFocus.OnFocused();
        }

        void RemoveFocus()
        {
            if (focus != null)
                focus.OnDefocused();

            focus = null;
        }
    }
}
