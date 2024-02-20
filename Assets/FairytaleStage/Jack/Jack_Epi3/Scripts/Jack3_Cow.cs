/*
  * - Name: Jack3_Cow.cs
  * - Content
  * Small object script
  * Set to return to original position when dragging is released
  *
  * - History
  * 1. 2021-07-28: Draft written
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Set to return to the original position when the drag is released
/// </summary>
public class Jack3_Cow : MonoBehaviour
{
     // Update is called once per frame
     void Update()
     {
         if(this.GetComponent<CharacterMovesWhenDragging>().b_CheckMouseUp() == true)
         {
             this.transform.position = new Vector3(-6.7f, -3.26f, 0);
         }
     }
}
