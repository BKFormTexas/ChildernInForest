/*
  * - Name: CollideNextScene.cs
  * - Content: Jack and the Beanstalk Episode 2 - Script that moves to the next page when crashing
  * - History -
  * 2021-07-20: Comment written.
  * 2021-07-23: TTS voice output function added.
  * 2021-07-27: Annotation changed based on feedback.
  *
  * - CollideNextScene Member variable
  *
  * string ms_nameNextScene: A variable that stores the name of the next scene specified in the inspector window.
  * bool mb_playOnce = false: This is a variable that checks so that the voice is output only once.
  * VoiceManager mvm_playVoice: A class that prepares and outputs voices.
  *
  * - CollideNextScene Member function
  *
  * OnTriggerEnter2D(): If a collider collision occurs, the scene moves on to the next scene.
  * Start(): Initializes VoiceManager to output voice.
  * Update(): If the voice is ready, output it only once.
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// If the corresponding object collides, it moves on to the next specified scene.
public class CollideNextScene : MonoBehaviour
{
     public string ms_nameNextScene;
     public bool mb_playOnce = false;
     private VoiceManager mvm_playVoice;

     void Start() {
         mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     }

     // Ensure that the voice is output only once.
     void Update() {
         if(mvm_playVoice.mb_checkSceneReady && !mb_playOnce) {
             mvm_playVoice.playVoice(0);
             mb_playOnce = true;
         }
     }

     // This is a function called when a collision occurs. When the audio is finished, move on to the next scene you specify.
     void OnTriggerEnter2D(Collider2D cCollideObject) {
         if(!mvm_playVoice.isPlaying()) {
             SceneManager.LoadScene(ms_nameNextScene);
         }
     }
    
     // This is a function called during a collision. When the audio is finished, move on to the next scene you specify.
     void OnTriggerStay2D(Collider2D cCollideObject) {
         if(!mvm_playVoice.isPlaying()) {
             SceneManager.LoadScene(ms_nameNextScene);
         }
     }
}
