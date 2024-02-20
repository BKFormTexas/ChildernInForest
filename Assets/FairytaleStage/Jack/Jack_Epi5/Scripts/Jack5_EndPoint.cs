/*
  * - Name: EndPoint.cs
  * - Content:
  * Jack and the Beanstalk Episode 5 - Beanstalk End Point Object Script
  * Script for handling conflicts between beans and mother object
  *
  * - History -
  * 1. 2021-07-15: Draft written
  *
  * - Variable
  * mg_EventManager Object for connection to director object
  *
  * - Function
  * OnTriggerEnter2D(Collider2D cCollidObj) collision detection function
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jack5_EndPoint: MonoBehaviour
{
     GameObject mg_EventManager;

     // Start is called before the first frame update
     void Start()
     {
         this.mg_EventManager = GameObject.Find("GameDirector");
     }

     /// <summary>
     /// Function that operates when an object collides
     /// </summary>
     /// <param name="cCollidObj">Collid Object</param>
     void OnTriggerEnter2D(Collider2D cCollidObj)
     {
         SceneManager.LoadScene("Jack_Epi6");
     }
}
