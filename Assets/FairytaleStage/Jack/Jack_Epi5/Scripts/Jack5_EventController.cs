/*
  * - Name: Jack5_EventController.cs
  * - Writer: Myeonghyun Kim
  *
  * - Content:
  * Jack and the Beanstalk Episode 5 - Event Management Script
  * Script to comprehensively manage game progress events
  *
  * - Update Log -
  * 1. 2021-07-14: Production completed
  * 2. 2021-07-16: Arrow function added and encoding format changed
  * 3. 2021-07-23: Add voice function and write comments
  * 4. 2021-07-27: Cleaning up duplicate scripts
  *
  * - Variable
  * Variable for connecting mg_GameDirector object -> Variable for accessing the game director object
  * Variable for connecting mg_Jack object -> Variable for accessing Jack object
  * Variable for connecting mvm_playVoice object -> Variable for accessing VoiceManager object
  * mg_GenJackSpeechBubble variable related to speech bubble -> Variable for connection to Jack speech bubble prefab
  * mg_JackSpeech speech bubble related variable -> Variable for connection to Jack speech bubble prefab
  * mb_EventFlag Variable for event management -> Flag to avoid repetition of the same event
  * mn_EventSequence Variable for event management -> Variable for managing event sequence
  * mb_SoundFlag Variable for event management -> Flag for sound to be heard only once when the scene is first run
  * mb_StopClickFlag Variable for event management -> Flag to prevent moving to the next event by clicking
  * mg_ArrowToJack Arrow-related variables -> Variable pointing to Jack
  * mg_ArrowToEndPoint Arrow-related variable -> Variable pointing to the end point
  * mg_ArrowPrefab Arrow related variable -> Variable for connecting arrow prefab
  *
  * - Function
  * v_ChangeFlagFalse() Flag change function -> set to False
  * v_ChangeFlagTrue() Flag change function -> set to True
  * v_NextMainScript() main script function -> prints the next main script
  * v_NoneMainScript() main script function -> erases the contents of the main script so that nothing is output
  * v_NextEventScript() event script function -> outputs the next event script
  * v_NoneEventScript() event script function -> erases the event script contents and sets nothing to be output
  * v_NextJackScript() Jack script function -> Prints the next Jack script
  * v_NoneJackScript() Jack script function -> Deletes the contents of the Jack script so that nothing is output.
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jack5_EventController: MonoBehaviour
{
     #region variable declaration part
     //Declaration of variables for object connection
     GameObject mg_GameDirector; // Variable for accessing the game director object
     GameObject mg_Jack; // Variable to access Jack object
     VoiceManager mvm_playVoice; // Variable to access VoiceManager object

     // Speech bubble related variables
     GameObject mg_GenJackSpeechBubble; // Variable for connection to Jack speech bubble prefab
     public GameObject mg_JackSpeech; // Variable for connection to Jack speech bubble prefab

     // Variables for event management
     private bool mb_EventFlag; // flag to trigger the event only once
     private int mn_EventSequence = 0; // Variables that manage the order of events
     private bool mb_SoundFlag; // Flag to make the sound come out only once
     private bool StopClickFlag; // Flag to prevent moving to the next event by clicking

     //Arrow related variables
     GameObject mg_ArrowToJack; // Variable pointing to Jack
     GameObject mg_ArrowToEndPoint; // Variable pointing to the end point
     public GameObject mg_ArrowPrefab; // Variable for arrow prefab connection
     #endregion

     // Start is called before the first frame update
     void Start()
     {
         //object connection
         this.mg_GameDirector = GameObject.Find("GameDirector");
         this.mg_Jack = GameObject.Find("Jack");
         this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();

         //event flag
         StopClickFlag = false;
         mb_SoundFlag = false;
         v_ChangeFlagFalse();

         //drag prohibition function
         v_TurnOFFMouseDrag();
     }

     // Update is called once per frame
     void Update()
     {
         // Set to move to the next event when clicked
         if (Input.GetMouseButtonDown(0) && !(mvm_playVoice.isPlaying()) && mvm_playVoice.mb_checkSceneReady)
         {
             if (StopClickFlag == false)
             {
                 mn_EventSequence += 1;
             }
             v_ChangeFlagTrue();
         }
       // overall event
         if(mn_EventSequence == 0 && mb_SoundFlag == false && mvm_playVoice.mb_checkSceneReady) // When the scene is first run
         {
             v_NextMainScript();
             mb_SoundFlag = true;
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 1 && this.mb_EventFlag == true) // The screen is touched once and moves on to the next event
         {
             v_ChangeFlagFalse();

             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 2 && this.mb_EventFlag == true) // The screen is touched twice and moves to the next event.
         {
             v_ChangeFlagFalse();

             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 3 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_NoneMainScript();

             v_GenJackSpeechBubble();
             v_NextJackScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 4 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_NextJackScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 5 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_RemoveJackSpeechBubble();

             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 6 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_TurnOnMouseDrag();

             v_NextEventScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }

         // If the jack moves to an incorrect place during the moving event, it returns to its original position.
         if (this.mg_Jack.GetComponent<CharacterMovesWhenDragging>().b_CheckMouseUp() == true)
         {
             mg_Jack.transform.position = new Vector3(-6.22f, -3.69f, 0);
         }

         // Arrow effect appears according to the drag state
         if (mg_Jack.GetComponent<CharacterMovesWhenDragging>().b_CheckDragging() == false && mn_EventSequence >= 6)
         {
             v_GenArrowToJack();
             v_RemoveArrowToEndPoint();
         }
         else if (mg_Jack.GetComponent<CharacterMovesWhenDragging>().b_CheckDragging() == true && mn_EventSequence >= 6)
         {
             v_RemoveArrowToJack();
             v_GenArrowToEndPoint();
         }
     }

  #region function declaration
     //Flag change function
     private void v_ChangeFlagFalse()
     {
         this.mb_EventFlag = false;
     }
     private void v_ChangeFlagTrue()
     {
         this.mb_EventFlag = true;
     }

     //main script function
     private void v_NextMainScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NextScript(0);
     }
     private void v_NoneMainScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NoneScript(0);
     }

     //Event script function
     private void v_NextEventScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NextScript(0);
     }
     private void v_NoneEventScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NoneScript(0);
     }
    
     //Jack script function
     private void v_NextJackScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NextScript(1);
     }
     private void v_NoneJackScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NoneScript(1);
     }

     //Speech bubble creation function
     private void v_GenJackSpeechBubble()
     {
         mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
         mg_GenJackSpeechBubble.transform.position = new Vector3(-3, -1, 0);
     }

     //Speech bubble deletion function
     private void v_RemoveJackSpeechBubble()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NoneScript(1);
         Destroy(this.mg_GenJackSpeechBubble);
     }

     //Enable dragging
     private void v_TurnOnMouseDrag()
     {
         this.mg_Jack.GetComponent<CharacterMovesWhenDragging>().v_ChangeDragFlagTrue();
     }

     //Disable dragging
     private void v_TurnOFFMouseDrag()
     {
         this.mg_Jack.GetComponent<CharacterMovesWhenDragging>().v_ChangeDragFlagFalse();
     }

     public void v_GenArrowToJack()
     {
         if (mg_ArrowToJack == null)
         {
             mg_ArrowToJack = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToJack.transform.position = new Vector3(-4.8f, -2.5f, 0);
             mg_ArrowToJack.GetComponent<SpriteRenderer>().flipX = true;
         }
     }
     public void v_GenArrowToEndPoint()
     {
         if (mg_ArrowToEndPoint == null)
         {
             mg_ArrowToEndPoint = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToEndPoint.transform.position = new Vector3(3.1f, 3.6f, 0);
             mg_ArrowToEndPoint.GetComponent<SpriteRenderer>().flipX = false;
             mg_ArrowToEndPoint.GetComponent<SpriteRenderer>().flipY = true;
         }
     }
public void v_RemoveArrowToJack()
     {
         if (mg_ArrowToJack != null)
         {
             Destroy(mg_ArrowToJack);
         }
     }
     public void v_RemoveArrowToEndPoint()
     {
         if (mg_ArrowToEndPoint != null)
         {
             Destroy(mg_ArrowToEndPoint);
         }
     }
     #endregion
}
