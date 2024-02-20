/*
   * - Name: DragAx.cs
   * - Content: Jack and the Beanstalk Episode 14 - Script where the mother gives Jack an axe
   *
   * - HISTORY
   * 2021-07-15: Initial development
   * 2021-07-16: Fixed file encoding and commented out
   * 2021-07-22: TTS function added
   * 2021-07-27: Fix comment processing
   *
   * <Variable>
   * mg_Jack: Jack
   * mg_Ax: Ax
   * mg_Click: Mission-guided click
   * mb_checkGetAxe: Whether Jack has acquired the ax or not
   * sc: Object to represent fairy tale script
   * vm: Object connection that handles voice TTS
   *
   * <Function>
   * OnTriggerEnter2D(Collider2D cCollideObject): A function that is called only once for the first time when a collision occurs between objects.
   * OnMouseDrag(): Function to move a game object by dragging
   * gotoEpi9Scene(): Function for moving the scene to Epi9
   *
   */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class where mom gives Jack an axe
public class DragAx : MonoBehaviour{
     public GameObject mg_Jack;
     public GameObject mg_Ax;
     public GameObject mg_Click;
     private bool mb_checkGetAxe = false;
     public ScriptControl sc;
     VoiceManager vm;

     //Initial settings
     void Start(){
         mg_Click = GameObject.Find("Click"); //Find the Click game object and store it in the mg_Click variable
         sc = ScriptControl.GetInstance();
         this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     }
     public void OnMouseDrag(){
         Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
         Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
         Destroy(mg_Click); //Remove mission-guided click when dragging the axe
         this.transform.position = v2worldObjPos;
     }
     void OnTriggerEnter2D(Collider2D cCollideObject){
         if (cCollideObject.tag == "Jack" && !mb_checkGetAxe){ //If Jack gets the axe
             SpriteRenderer rend = mg_Jack.GetComponent<SpriteRenderer>();
             rend.flipX = false; //Jack looking at the beanstalk -> symmetrical
             transform.position = mg_Jack.transform.position; //Arrange the ax position to the jack position
             vm.playVoice(1); //Play the 1st script voice
             sc.setNextScript(); //Show the first script
             mb_checkGetAxe = true; //Check that Jack has acquired the axe
         }
     }
}
