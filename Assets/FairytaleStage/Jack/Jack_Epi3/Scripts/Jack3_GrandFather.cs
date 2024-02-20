/*
  * - Name: Jack3_GFScript.cs
  *
  * - Content:
  * Jack and the Beanstalk Episode 3 - Grandpa Object Script
  * Script for object collision handling between grandfather and cow
  *
  * * - Update Log -
  * 2021-07-13: Production completed
  * 2021-07-23: Comment change
  *
  * - Variable
  *
  * - Function
  * OnTriggerEnter2D(Collider2D cCollidObj) collision detection function
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack3_GrandFather: MonoBehaviour
{
     /// <summary>
     /// Function to operate when object collides
     /// </summary>
     /// <param name="cCollidObj">Collided object</param>
     void OnTriggerEnter2D(Collider2D cCollidObj)
     {
         //Debug.Log("Collision Detected");
         if (cCollidObj.tag == "Jack3_Cow") // When the grandfather object and the minor object collide
         {
             Destroy(cCollidObj.gameObject); // Delete collided object
         }
     }
}
