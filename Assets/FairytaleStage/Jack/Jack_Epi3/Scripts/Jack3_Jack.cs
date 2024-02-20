/*
  * - Name: Jack3_Jack.cs
  *
  * - Content:
  * Jack and the Beanstalk Episode 3 - Jack object script
  * Script for handling object collisions between Jack and Kong
  *
  * * - Update Log -
  * 2021-07-13: Production completed
  * 2021-07-23: Comment change
  *
  * - Function
  * OnTriggerEnter2D(Collider2D cCollidObj) collision detection function
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack3_Jack : MonoBehaviour
{
     /// <summary>
     /// Function to operate when object collides
     /// </summary>
     /// <param name="cCollidObj">Collided object</param>
     void OnTriggerEnter2D(Collider2D cCollidObj)
     {
         //Debug.Log("Collision Detected");
         if (cCollidObj.tag == "Jack3_Bean") // If Jack and the bean object collide
         {
             Destroy(cCollidObj.gameObject); // Delete collided object
         }
     }
}
