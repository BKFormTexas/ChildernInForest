/*
  * - Name: Movement_Jack.cs
  * - Content: Jack and the Beanstalk Episode 13 - Jack Movement Script
  *
  * - HISTORY
  * 2021-07-15: Initial development
  * 2021-07-16: Fixed file encoding and commented out
  * 2021-07-22: TTS function added
  * 2021-07-26: Sound effect added completed
  * 2021-07-27: Fix comment processing
  *
  * <Variable>
  * v3_target: Specifies the location where the object should walk
  * mb_checkPlayOnce: Variable to check to ensure that the script voice is executed only once
  * mb_checkPlayVoice: Variable that checks whether the first script has been played.
  * sc: Object to represent fairy tale script
  * vm: Object connection that handles voice TTS
  * ScreamSound: Jack's scream
  *
  * <Function>
  * PlayScream(): Function to play Jack's scream
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack movement class
public class MovementJack: MonoBehaviour{
     public Vector3 v3_target;
     bool mb_checkPlayOnce = false;
     bool mb_checkPlayVoice = false;
     public ScriptControl sc;
     VoiceManager vm;
     private AudioSource ScreamSound;

     //Initial settings
     void Start(){
         sc = ScriptControl.GetInstance();
         this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
         ScreamSound = GameObject.Find("ScreamSound").GetComponent<AudioSource>();
     Invoke("PlayScream",1f); //Play PlayScream function after 1 second
     }
     void Update(){
         if(vm.mb_checkSceneReady) { //If tts preparation work is completed
             transform.position = Vector3.MoveTowards(transform.position, v3_target, 0.2f); // move jack
             if(!mb_checkPlayOnce) { //If the script voice has never been played
                 vm.playVoice(0); //Play script voice
                 mb_checkPlayOnce = true; //Check script voice playback
             }
             if(!vm.isPlaying() && !mb_checkPlayVoice){ //If the current script voice has ended and the next script voice has never been played
                 sc.setNextScript(); //Show the next script
                 vm.playVoice(1); //Play next script voice
                 mb_checkPlayVoice = true; //Check script voice playback
             }
         }
     }

     // Function to play Jack's scream sound
     void PlayScream(){
         ScreamSound.Play();
     }
}
