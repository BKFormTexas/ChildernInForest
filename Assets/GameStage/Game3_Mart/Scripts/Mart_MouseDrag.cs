/*
 * - Name: Mart_MouseDrag.cs
 * 
 * - Content:
 * Mouse event script for dragging objects. Allows objects to follow the mouse while dragging and return to their original positions when the mouse is released.
 * 
 * - Update Log -
 * 2021-07-09: Completion of writing
 * 2021-07-21: Encoding format modified, and comments rewritten
 *                  
 * - Variables:
 * mv2_mouseDragPosition: A vector to store the mouse position
 * mv2_worldObjectPosition: A vector for converting to the camera's world coordinates
 * 
 * Functions:
 * OnMouseDown(): Called when the object is clicked
 * OnMouseDrag(): Called when the object is dragged
 * OnMouseUp(): Called when the mouse is released from the object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mart_MouseDrag : MonoBehaviour
{
    private SoundManager msm_soundManager;
    private bool PlayOnce;

    void Start()
    {
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        PlayOnce = false;

    }

    void Update()
    {

    }

    /// <summary>
    /// Called when the object is clicked.
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Object touched");
    }

    /// <summary>
    /// Called when the object is dragged.
    /// </summary>
    private void OnMouseDrag()
    {
        Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
        this.transform.position = mv2_worldObjectPosition;
        Debug.Log("Object dragged");
        if (PlayOnce == false)
        {
            msm_soundManager.playSound(0);
            PlayOnce = true;
        }
    }

    /// <summary>
    /// Called when the mouse is released from the object.
    /// </summary>
    private void OnMouseUp()
    {
        Debug.Log("Released from the object");
        if (this.tag == "Mart_Item1")
        {
            this.transform.position = new Vector3(6.1f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item2")
        {
            this.transform.position = new Vector3(9.5f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item3")
        {
            this.transform.position = new Vector3(6.1f, 0, 0);
        }
        if (this.tag == "Mart_Item4")
        {
            this.transform.position = new Vector3(9.5f, 0f, 0);
        }
        if (this.tag == "Mart_Item5")
        {
            this.transform.position = new Vector3(6.1f, -3f, 0);
        }
        if (this.tag == "Mart_Item6")
        {
            this.transform.position = new Vector3(9.5f, -3f, 0);
        }
        PlayOnce = false;
    }
}
