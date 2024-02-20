/*
  * - Name: Movement_Giant.cs
  * - Content: Jack and the Beanstalk Episode 13 - Giant Movement Script
  *
  * - HISTORY
  * 2021-07-15: Initial development
  * 2021-07-16: Fixed file encoding and commented out
  * 2021-07-22: TTS function added
  * 2021-07-27: Fix comment processing
  *
  * <Variable>
  * v3_target: Specifies the location where the giant must walk
  * mb_checkPlayOnce: Variable to check to ensure that the script voice is executed only once
  * sc: Object to represent fairy tale script
  * vm: Object connection that handles voice TTS
  *
  * <Function>
  * MoveTowards(): Uniform speed movement, input {current position, target position, speed} as parameters
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

//giant movement class
public class MovementGiant: MonoBehaviour{
     public Vector3 v3_target;
     bool mb_checkPlayOnce = false;
     public ScriptControl sc;
     VoiceManager vm;

     //Initial settings
     void Start(){
         sc = ScriptControl.GetInstance();
         this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     }
     void Update(){
          if(vm.mb_checkSceneReady){ //If tts preparation work is completed
             transform.position = Vector3.MoveTowards(transform.position, v3_target, 0.1f); //giant movement
             if(!mb_checkPlayOnce){ //If the script voice has never been played
                 vm.playVoice(0); //Play script voice
                 mb_checkPlayOnce = true; //Check script voice playback
             }
     }

        
     }
}
