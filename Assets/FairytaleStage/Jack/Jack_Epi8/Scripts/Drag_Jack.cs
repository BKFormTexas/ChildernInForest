/*
  * - Name: Drag_Jack.cs
  * - Content: Jack and the Beanstalk Episode 8 - Jack-drag script to hide Jack behind the closet to avoid the giant.
  *
  * - HISTORY
  * 2021-07-14: Initial development
  * 2021-07-16: Fixed file encoding and commented out
  * 2021-07-22: TTS function added
  * 2021-07-27: Fix comment processing
  * 2021-07-29: Bug fix
  *
  * <Variable>
  * mg_Jack: Jack object
  * sc: Object to represent fairy tale script
  * vm: Object connection that handles voice TTS
  * DragFlag: Drag handling
  *
  * <Function>
  * OnTriggerEnter2D(Collider2D cCollideObject): A function that is called only once for the first time when a collision occurs between objects.
  * OnMouseDrag(): Function to move a game object by dragging
  * ChangeDragFlagTrue(): Drag-allowing function
  * gotoEpi9Scene(): Function for moving the scene to Epi9
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Jack dragging class to hide Jack behind the closet to avoid the giant
public class Drag_Jack: MonoBehaviour{
     public GameObject mg_Jack;
     public ScriptControl sc;
     VoiceManager vm;
     bool DragFlag = false;

     //Initial settings
     void Start(){
         sc = ScriptControl.GetInstance(); // Receive and use Instance return from ScriptControl
         this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     }

     //Function called only once for the first time when a collision occurs between objects
     void OnTriggerEnter2D(Collider2D cCollideObject){ //If a collision occurs between objects
         if(cCollideObject.tag == "Closet"){ //If Jack hides behind the closet
             sc.setNextScript(); //present next script
             vm.playVoice(1); //Run tts corresponding to the following script
             Destroy(this.gameObject); //Get rid of Jack
             Destroy(GameObject.Find("Click").gameObject); //Remove mission arrow
         }
         if(!vm.isPlaying()) { //When tts is finished playing
             Invoke("gotoEpi9Scene", 5f); //Perform gotoEpi9Scene function after 5 seconds
         }
     }

     //Function to move a game object by dragging
     void OnMouseDrag(){
         if(DragFlag == true){ //If drag is allowed
             Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
             Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
             mg_Jack.transform.position = v2worldObjPos;
         }
     }

     //Function for moving scene to Epi9
     void gotoEpi9Scene() {
         SceneManager.LoadScene("Jack_Epi9"); //Load Jack_Epi9 scene
     }

     //Drag allow function
     public void ChangeDragFlagTrue(){
         DragFlag = true;
     }

}
