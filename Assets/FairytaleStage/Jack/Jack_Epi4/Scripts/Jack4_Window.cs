/*
  * - Name: Jack4_Mother.cs
  * - Writer: Myeonghyun Kim
  *
  * - Content:
  * Jack and the Beanstalk Episode 4 - Mother Object Script
  * Script for object conflict handling between mother and bean
  *
  * * - Update Log -
  * 2021-07-13: Production completed
  * 2021-07-23: Comment change
  *
  * - Variable
  * Variable for connecting mg_EventManager director object
  * mg_Bean Variable for bean object connection
  *
  * - Function
  * OnTriggerEnter2D(Collider2D cCollidObj) collision detection function
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack4_Window : MonoBehaviour
{
     GameObject mg_EventManager;
     GameObject mg_Bean;

     bool CheckFlag;

     // Start is called before the first frame update
     void Start()
     {
         this.mg_EventManager = GameObject.Find("GameDirector");
         this.mg_Bean = GameObject.Find("Bean");

     }

     // Update is called once per frame
     void Update()
     {
         CheckFlag = this.mg_EventManager.GetComponent<Jack4_EventController>().b_CheckBeanToMother();
     }

     /// <summary>
     /// Function to run while a collision is occurring
     /// </summary>
     /// <param name="cCollidObj">Collided object</param>
     void OnTriggerEnter2D(Collider2D cCollidObj)
     {
         Debug.Log("Collision Detected");
         if (cCollidObj.tag == "Bean" && CheckFlag == true)
         {
             Destroy(cCollidObj.gameObject);
             this.mg_EventManager.GetComponent<Jack4_EventController>().v_BeanToWindow();
         }
     }
}
