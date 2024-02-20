/*
  * - Name: Jack9_EventController.cs
  * - Writer: Myeonghyun Kim
  *
  * - Content:
  * Jack and the Beanstalk Episode 9 - Event Management Script
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
  * Variable for connecting mg_Sack object -> Variable for accessing the sack object
  * Variable for connecting mvm_playVoice object -> Variable for accessing VoiceManager object
  * mg_GenGiantSpeechBubble Speech bubble related variables -> Variables for managing giant speech bubbles
  * mg_GiantSpeech speech bubble related variable -> Variable for connection to Jack speech bubble prefab
  * mb_DontLoopEvent1 Variable for event management -> Flag to avoid event repetition
  * mb_DontLoopEvent2 Variable for event management -> Flag to avoid event repetition
  * mb_EventFlag Variable for event management -> Flag to avoid event repetition
  * mn_EventSequence Variable for event management -> Variable for managing event sequence
  * mb_SoundFlag Variable for event management -> Flag for sound to be heard only once when the scene is first run
  * mb_StopClickFlag Variable for event management -> Flag to prevent moving to the next event by clicking
  * Variable for managing the IsSackDestroy event -> Flag to check if the sack has been destroyed
  * mg_ArrowToSackLeft Arrow-related variable -> Left arrow variable pointing to the sack
  * mg_ArrowToSackRight arrow related variable -> right arrow variable pointing to the sack
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
using UnityEngine.SceneManagement;



public class Jack9_EventController: MonoBehaviour
{
     #region variable declaration part
     // Variables for object connection
     GameObject mg_GameDirector; // Variable for accessing the game director object
     GameObject mg_Sack; // Variable for accessing the sack object
     VoiceManager mvm_playVoice; // Variable to access VoiceManager object

     // Speech balloon related objects
     GameObject mg_GenGiantSpeechBubble;
     public GameObject mg_GiantSpeech;

     //Variables for event management
     private bool mb_DontLoopEvent1;
     private bool mb_DontLoopEvent2;
     private bool mb_EventFlag; // flag to trigger the event only once
     private int mn_EventSequence; // Variables that manage the order of events
     private bool mb_SoundFlag;
     private bool StopClickFlag; // Flag to prevent moving to the next event by clicking
     private bool IsSackDestroy;

     //Arrow object
     GameObject mg_ArrowToSackLeft;
     GameObject mg_ArrowToSackRight;
     public GameObject mg_ArrowPrefab;
     #endregion

     // Start is called before the first frame update
     void Start()
     {
         //object connection
         this.mg_GameDirector = GameObject.Find("GameDirector");
         this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
         this.mg_Sack = GameObject.Find("Sack");

         //event flag
         mb_DontLoopEvent1 = false;
         mb_DontLoopEvent2 = false;
         StopClickFlag = false;
         IsSackDestroy = false;

         //Event related
         v_ChangeFlagFalse();
         mn_EventSequence = 0;

         //event start
         v_NextMainScript();
     }

     // Update is called once per frame
     void Update()
   {

         if (Input.GetMouseButtonDown(0) && mvm_playVoice.mb_checkSceneReady)
         {
             if (StopClickFlag == false && !(mvm_playVoice.isPlaying()))
             {
                 mn_EventSequence += 1;
             }
             v_ChangeFlagTrue();
         }

         if (mn_EventSequence == 0 && mb_SoundFlag == false && mvm_playVoice.mb_checkSceneReady) // Run basic script when the scene is first run.
         {
             mb_SoundFlag = true;
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 1 && this.mb_EventFlag == true && !(mvm_playVoice.isPlaying()) && mb_SoundFlag == true)
         {
             v_ChangeFlagFalse();
             mb_SoundFlag = false;
             v_NoneMainScript();

             v_GenGiantSpeechBubble();
             v_NextGiantScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 2 && this.mb_EventFlag == true && mb_SoundFlag == false)
         {
             v_ChangeFlagFalse();
             mb_SoundFlag = true;
             v_RemoveGiantSpeechBubble();

             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
             mb_DontLoopEvent1 = true;
         }
         else if (mn_EventSequence == 3 && this.mb_EventFlag == true && mb_DontLoopEvent1 == true)
         {
             v_ChangeFlagFalse();

             v_NextEventScript();
             mg_Sack.GetComponent<Jack9_Sack>().ChangSackFlagTrue();
             StopClickFlag = true;

             mb_DontLoopEvent1 = false;
             mb_DontLoopEvent2 = true;
             mvm_playVoice.playVoice(mn_EventSequence);
             v_GenArrowToSack1();
             v_GenArrowToSack2();
         }
         else if (mn_EventSequence == 3 && IsSackDestroy == true && mb_DontLoopEvent2 == true)
         {
             v_ChangeFlagFalse();
             StopClickFlag = false;
             mb_DontLoopEvent2 = false;

             v_NextMainScript();

             this.mg_GameDirector.GetComponent<Jack9_Gentreasure>().v_GenTreasure();
             mvm_playVoice.playVoice(mn_EventSequence+1);
             v_RemoveArrowToSack1();
             v_RemoveArrowToSack2();
         }
         else if (mn_EventSequence == 4 && IsSackDestroy == true)
         {
             v_ChangeFlagFalse();


             SceneManager.LoadScene("Jack_Epi10");

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
    
     //Giant script function
     private void v_NextGiantScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NextScript(1);
     }
     private void v_NoneGiantScript()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NoneScript(1);
     }
   //Speech bubble creation function
     private void v_GenGiantSpeechBubble()
     {
         mg_GenGiantSpeechBubble = Instantiate(mg_GiantSpeech) as GameObject;
         mg_GenGiantSpeechBubble.transform.position = new Vector3(0, 3.3f, 0);
     }

     //Speech bubble deletion function
     private void v_RemoveGiantSpeechBubble()
     {
         this.mg_GameDirector.GetComponent<ScriptManager>().v_NoneScript(1);
         Destroy(this.mg_GenGiantSpeechBubble);
     }
    
     public void v_IsSackDestroy()
     {
         IsSackDestroy = true;
     }

     public void v_GenArrowToSack1()
     {
         if (mg_ArrowToSackLeft == null)
         {
             mg_ArrowToSackLeft = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToSackLeft.transform.position = new Vector3(-0.87f, -0.57f, 0);
         }
     }
     public void v_GenArrowToSack2()
     {
         if (mg_ArrowToSackRight == null)
         {
             mg_ArrowToSackRight = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToSackRight.transform.position = new Vector3(5, -0.57f, 0);
             mg_ArrowToSackRight.GetComponent<SpriteRenderer>().flipX = true;
         }
     }

     public void v_RemoveArrowToSack1()
     {
         if (mg_ArrowToSackLeft != null)
         {
             Destroy(mg_ArrowToSackLeft);
         }
     }
     public void v_RemoveArrowToSack2()
     {
         if (mg_ArrowToSackRight != null)
         {
             Destroy(mg_ArrowToSackRight);
         }
     }
     #endregion
}
