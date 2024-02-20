/*
  * - Name: ScriptTTS.cs
  * - Content: Jack and the Beanstalk Episode 15 - TTS application script
  *
  * - HISTORY
  * 2021-07-15: Initial development
  * 2021-07-16: Fixed file encoding and commented out
  * 2021-07-27: Fix comment processing
  *
  * <Variable>
  * vm: Object connection that handles voice TTS
  * mb_checkPlayOnce: Variable to check to ensure that the script voice is executed only once
  *
  * <Function>
  * PlayScream(): Function to play Jack's scream
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

// TTS application class to script
public class ScriptTTS: MonoBehaviour{
     VoiceManager vm;
     bool mb_checkPlayOnce = false;

     // initial settings
     void Start(){
         this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     }

     void Update(){
         if(vm.mb_checkSceneReady){ //If tts preparation work is completed
             if(!mb_checkPlayOnce){ //If the script voice has never been played
                 vm.playVoice(0); //Play next script voice
                 mb_checkPlayOnce = true; //Check script voice playback
             }
         }
     }
}
