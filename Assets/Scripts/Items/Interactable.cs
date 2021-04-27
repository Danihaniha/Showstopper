using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 0.5f;


    bool isFocus = false;
    //bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overwritten.
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isFocus) //&& !hasInteracted)
        {
            Interact();
            //hasInteracted = true;
        }
    }
    public void OnFocused()
    {
        isFocus = true;
        //hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        //hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
