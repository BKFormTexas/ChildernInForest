/*
   * - Name: Movement_Giant.cs
   * - Content: Jack and the Beanstalk Episode 8 - A class where a giant moves to chase after Jack/
   *
   * - HISTORY
   * 2021-07-14: Initial development
   * 2021-07-16: Fixed file encoding and commented out
   * 2021-07-22: TTS function added
   * 2021-07-27: Fix comment processing
   * 2021-07-29: Bug fix
   *
   * <Variable>
   * mg_targetPosition: Specifies the walkPos object in the inspector window and moves the giant to the walkPos position.
   * mg_Jack: Jack
   * mb_checkPlayOnce: Variable to check to ensure that the script voice is executed only once
   * mb_JackFlag: Variable that allows Jack to be found only once in the Update function
   * sc: Object to represent fairy tale script
   * vm: Object connection that handles voice TTS
   *
   * <Function>
   * MoveTowards(): Uniform speed movement, input {current position, target position, speed} as parameters
   */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that moves the giant to chase after Jack
public class Movement_Giant : MonoBehaviour{
   public GameObject mg_targetPosition;
   GameObject mg_Jack;
   bool mb_checkPlayOnce = false;
   public ScriptControl sc;
   VoiceManager vm;
   bool mb_JackFlag = false;

   //Initial settings
   void Start(){
     sc = ScriptControl.GetInstance();
     this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     mg_Jack = GameObject.Find("Jack");
   }
  
   void Update(){
     if(vm.mb_checkSceneReady){ //If tts preparation work is completed
       transform.position = Vector3.MoveTowards(gameObject.transform.position, mg_targetPosition.transform.position, 0.1f); //giant movement
       if(!mb_checkPlayOnce){ //If the script voice has never been played
         vm.playVoice(0); //Play script voice
         mb_checkPlayOnce = true; //Check script voice playback
       }
       else if (!vm.isPlaying() && mb_JackFlag == false){
         mg_Jack.GetComponent<Drag_Jack>().ChangeDragFlagTrue();
         mb_JackFlag = true;
       }
     }
   }
}
