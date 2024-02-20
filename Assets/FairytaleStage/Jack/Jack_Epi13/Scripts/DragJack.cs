/*
  * - Name: Movement_Giant.cs
  * - Content: Jack and the Beanstalk Episode 13 - Script to drag Jack to the door to avoid the giant
  *
  * - HISTORY
  * 2021-07-14: Initial development
  * 2021-07-16: Fixed file encoding and commented out
  * 2021-07-27: Fix comment processing
  *
  * <Function>
  * OnTriggerEnter2D(Collider2D cCollideObject): A function that is called only once for the first time when a collision occurs between objects.
  * OnMouseDrag(): Function to move a game object by dragging
  *
  */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Function to drag Jack to the door to avoid the giant
public class DragJack : MonoBehaviour
{
    // Function called once when collision occurs between objects
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        if (cCollideObject.tag == "Jack")
        {
            // If the collision object's tag is Jack
            OnMouseDrag(); // Enable dragging for Jack
        }
        else if (cCollideObject.tag == "Door")
        {
            // If the collision object's tag is Door
            SceneManager.LoadScene("Jack_Epi14"); // Move to the next scene Epi14
        }
    }

    // Function to move the game object by dragging
    void OnMouseDrag()
    {
        Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
        this.transform.position = v2worldObjPos;
    }
}
