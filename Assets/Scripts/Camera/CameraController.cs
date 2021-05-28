using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public Vector3 boundsMin;
    //public Vector3 boundsMax;

    public int[] roomSize = { 20, 26, 22 };

    public GameObject cameraToMove;
    public int currentRoom = 0;
    public float offsetRoom = 50f;


    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, currentRoom * offsetRoom - roomSize[currentRoom] /2, currentRoom * offsetRoom + roomSize[currentRoom] / 2), 0f, -10f);
    }

    public void PressedRight()
    {
        if(currentRoom <= 1)
        {
            currentRoom = currentRoom + 1;
            transform.position = new Vector2(currentRoom * offsetRoom, 0f);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void PressedLeft()
    {
        if(currentRoom >= 1)
        {
            currentRoom = currentRoom - 1;
            transform.position = new Vector2(currentRoom * offsetRoom, 0f);
        }
    }
}
