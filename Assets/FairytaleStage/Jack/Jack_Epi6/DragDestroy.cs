/*
  * - Name: DragDestroy.cs
  * - Content: Jack and the Beanstalk Episode 1 -
  * - History -
  * 2021-07-21: Written
  * 2021-07-27: Annotation changed based on feedback.
  *
  * - DragDestroy Member variables
  *
  *null
  *
  * - DragDestroy Member functions
  *
  * OnMouseDrag(): This is a function that removes the speech bubble displayed on Jack when dragging.
  * SceneManager.LoadScene(): Function to move to the next scene
  *
  */
 
using System. Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a script added because it was unnatural for Jack's speech bubble to remain floating even when its position was changed by dragging. When the jack is dragged, the speech bubble is set to disappear.
public class DragDestroy : MonoBehaviour {
     // The speech bubble disappears when dragged.
     private void OnMouseDrag()
     {
         Destroy(GameObject.Find("speechBubble"));
         Destroy(GameObject.Find("ScriptCanvas"));
         Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
         Input.mousePosition.y);
         Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
         this.transform.position = v2_checkworldObjPos;
     }
}
