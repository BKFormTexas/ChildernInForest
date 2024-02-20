/*
  * - Name: DragCharacters.cs
  * - Writer: Ryu Shi-on
  * - Content: Jack and the Beanstalk Episode 2 - Jack and Cow drag script
  * - History -
  * 2021-07-20: Created
  * 2021-07-27: Annotation changed based on feedback.
  *
  * DragCharacters Member Variables
  *
  *null
  *
  * DragCharacters Member Functions
  *
  * OnTriggerEnter2D(): A function that is called only once when a collision occurs between objects.
  * OnMouseDrag(): Function to move a game object by dragging the mouse
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a class that detects when the player clicks and drags a character that appears in the scene.
public class DragCharacters: MonoBehaviour
{
     // When dragging, the character is moved to the mouse position.
     private void OnMouseDrag()
     {
         Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
         Input.mousePosition.y);
         Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
         this.transform.position = v2_checkworldObjPos;
     }
}
