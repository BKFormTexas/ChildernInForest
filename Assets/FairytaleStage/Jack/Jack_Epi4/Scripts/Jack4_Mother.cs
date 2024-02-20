/*
  * - Name: Jack4_Mother.cs
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

/// <summary>
/// Script for conflict handling of mother object
/// </summary>
public class Jack4_Mother : MonoBehaviour
{
     GameObject mg_EventManager;
     GameObject mg_Bean;

     public Sprite[] MotherImage = new Sprite[2];

     // Start is called before the first frame update
     void Start()
     {
         this.mg_EventManager = GameObject.Find("GameDirector");
         this.mg_Bean = GameObject.Find("Bean");
     }

     /// <summary>
     /// Function to run while a collision is occurring
     /// </summary>
     /// <param name="cCollidObj">Collided object</param>
     void OnTriggerEnter2D(Collider2D cCollidObj)
     {
         Debug.Log("Collision Detected");
         if (cCollidObj.tag == "Bean")
         {
             cCollidObj.gameObject.transform.position = new Vector3(5.2f, -3.5f, 0);
             //Destroy(cCollidObj.gameObject);
             this.mg_EventManager.GetComponent<Jack4_EventController>().v_BeanToMother();
             this.mg_Bean.GetComponent<Jack4_MouseDrag>().v_BeanPositionFlagTrue();
         }
     }
     /// <summary>
     /// Function that changes the image of the mother to an angry image
     /// </summary>
     public void ChangeMotherAngry()
     {
         this.gameObject.GetComponent<SpriteRenderer>().sprite = MotherImage[1];
     }
}
