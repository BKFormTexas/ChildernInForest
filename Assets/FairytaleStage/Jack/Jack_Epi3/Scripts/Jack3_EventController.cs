/*
  * - Name: Jack3_EventController.cs
  *
  * - Content:
  * Jack and the Beanstalk Episode 3 - Event Management Script
  * Script to comprehensively manage game progress events
  *
  * - Update Log -
  * 2021-07-13: Production completed
  * 2021-07-16: Arrow function added and encoding format changed
  * 2021-07-21: Comment change
  * 2021-07-23: Add voice function and write comments
  * 2021-07-28: Simplification of code and modularization of some functions
 * 
 * - Variable 
 * mg_ScriptManager                
 * mg_ArrowToBean                  
 * mg_ArrowToCow                  
 * mg_ArrowToGF                
 * mg_ArrowToJack              
 * mg_ArrowPrefab                
 * mg_GenGFSpeechBubble             
 * mg_GFSpeech                     
 * mg_GenJackSpeechBubble         
 * mg_JackSpeech                   
 * mb_EventFlag                    
 * mn_EventSequence                
 * mg_Cow                         
 * mg_Bean                          
 * mb_BeanToJack                    
 * mb_CowToGF                      
 * mb_PlaySound                     
 * 
 * - Function
 * v_ChangeFlagFalse()            
 * v_ChangeFlagTrue()               
 * v_TurnOnMouseDrag()             
 * v_TurnOFFMouseDrag()            
 * v_NoneScript()                   
 * v_NextMainScript()              
 * v_NextJackScript()             
 * v_NextGFScript()               
 * v_GenArrowToBean()              
 * v_GenArrowToCow()                
 * v_GenArrowToGF()                
 * v_GenArrowToJack()               
 * v_RemoveArrowToGF()            
 * v_RemoveArrowToJack()            
 * v_RemoveArrowToBean()            
 * v_RemoveArrowToCow()             
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that manages overall events
/// </summary>
public class Jack3_EventController: MonoBehaviour
{
     #region variable declaration part

     //Declaration of variables for object connection
     GameObject mg_ScriptManager; // Variable for accessing the game director object
     GameObject mg_Cow; // Variable for small object connection
     GameObject mg_Bean; // Variable for bean object connection
     VoiceManager mvm_playVoice; // Flag to make the voice sound only once when the scene starts

     //Arrow related variables
     GameObject mg_ArrowToBean; // arrow pointing to beans
     GameObject mg_ArrowToCow; // arrow pointing to cow
     GameObject mg_ArrowToGF; // Arrow pointing to grandfather
     GameObject mg_ArrowToJack; // arrow pointing to jack
     public GameObject mg_ArrowPrefab; // Variable for arrow prefab connection

     //Declaration of speech bubble related variables
     GameObject mg_GenGFSpeechBubble; // Variable for manipulating the grandfather speech bubble object
     public GameObject mg_GFSpeech; // Variable for connection to the grandfather speech bubble prefab
     GameObject mg_GenJackSpeechBubble; // Variables for manipulating the Jack speech bubble object
     public GameObject mg_JackSpeech; // Variables for connection to the Jack speech bubble prefab

     // Event related flag declaration
     private bool mb_EventFlag = false; // flag to trigger the event only once
     private int mn_EventSequence = 0; // Variables that manage the order of events
     private bool mb_PlaySound = false; // Flag to make the voice sound only once when the scene is first run
    
     #endregion

     void Start(){
         // The part that connects variables to objects
         this.mg_ScriptManager = GameObject.Find("Jack3_GameDirector");
         this.mg_Cow = GameObject.Find("Jack3_Cow");
         this.mg_Bean = GameObject.Find("Jack3_Bean");
         this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();

         v_TurnOFFMouseDrag(); // Set to prevent dragging even while loading
     }

  void Update(){
         if (Input.GetMouseButtonDown(0) && !(mvm_playVoice.isPlaying()) && mvm_playVoice.mb_checkSceneReady) // When the voice ends and the screen is clicked, move to the next step.
         {
             mn_EventSequence += 1;
             v_ChangeFlagTrue();
         }

         //Arrow effect processing part according to drag state
         if (mg_Cow != null && mn_EventSequence >= 8)
         {
             if (mg_Cow.GetComponent<CharacterMovesWhenDragging>().b_CheckDragging() == true)
             {
                 v_RemoveArrowToCow();
                 v_GenArrowToGF();
                 v_RemoveArrowToBean();
             }
             else if (mg_Bean != null)
             {
                 if (mg_Bean.GetComponent<CharacterMovesWhenDragging>().b_CheckDragging() == true)
                 {
                     v_RemoveArrowToBean();
                     v_GenArrowToJack();
                     v_RemoveArrowToCow();
                 }
                 else if (mn_EventSequence >= 8)
                 {
                     v_RemoveArrowToGF();
                     v_RemoveArrowToJack();
                     if (mg_Cow != null)
                         v_GenArrowToCow();
                     if (mg_Bean != null)
                         v_GenArrowToBean();
                 }
             }
             else if (mn_EventSequence >= 8)
             {
                 v_RemoveArrowToGF();
                 v_RemoveArrowToJack();
                 if (mg_Cow != null)
                     v_GenArrowToCow();
                 if (mg_Bean != null)
                     v_GenArrowToBean();
             }
         }
         else if(mg_Bean != null && mn_EventSequence >= 8)
         {
             if (mg_Bean.GetComponent<CharacterMovesWhenDragging>().b_CheckDragging() == true)
             {
                 v_RemoveArrowToBean();
                 v_GenArrowToJack();
                 v_RemoveArrowToCow();
             }
             else if (mn_EventSequence >= 8)
             {
                 v_RemoveArrowToGF();
                 v_RemoveArrowToJack();
                 if (mg_Cow != null)
                     v_GenArrowToCow();
                 if (mg_Bean != null)
                     v_GenArrowToBean();
             }
         }
      else if(mg_Bean == null && mg_Cow == null)
         {
             SceneManager.LoadScene("Jack_Epi4");
         }

         //Overall event
         if (mn_EventSequence == 0 && mb_PlaySound == false && mvm_playVoice.mb_checkSceneReady) // Run basic script when the scene is first run.
         {
             mb_PlaySound = true;
             mvm_playVoice.playVoice(mn_EventSequence);
             v_NextMainScript();
         }
         if (mn_EventSequence == 1 && this.mb_EventFlag == true){ // Proceed by touching the screen once
             v_ChangeFlagFalse(); // Change the flag value to False to execute the event only once
             v_NoneScript();
             v_NextGFScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 2 && mb_EventFlag == true){ // Proceed by touching the screen twice
             v_ChangeFlagFalse();
             v_NoneScript();
             v_NextJackScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 3 && mb_EventFlag == true){ // Proceed by touching the screen 3 times
             v_ChangeFlagFalse();
             v_NoneScript();
             v_NextGFScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 4 && mb_EventFlag == true){
             v_ChangeFlagFalse();
             v_NoneScript();
             Invoke("v_NextGFScript", 0.1f);
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 5 && mb_EventFlag == true){
             v_ChangeFlagFalse();
             v_NoneScript();
             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 6 && mb_EventFlag == true){
             v_ChangeFlagFalse();
             v_NoneScript();
             v_NextJackScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 7 && mb_EventFlag == true){
             v_ChangeFlagFalse();
             v_NoneScript();
             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
       else if (mn_EventSequence == 8 && mb_EventFlag == true)
         {
             v_ChangeFlagFalse();
             v_NoneScript();
             v_NextMainScript();
             v_TurnOnMouseDrag();
             v_GenArrowToBean();
             v_GenArrowToCow();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
     }
     #region function declaration

     /// <summary>
     /// Flag change function -> Change the Flag value to False to ensure that story-related events are triggered only once.
     /// </summary>
     private void v_ChangeFlagFalse(){
         this.mb_EventFlag = false;
     }
     /// <summary>
     /// Flag change function -> Change the Flag value to True to ensure that story-related events are triggered only once.
     /// </summary>
     private void v_ChangeFlagTrue(){
         this.mb_EventFlag = true;
     }
     /// <summary>
     /// Flag change function -> Activate object drag
     /// </summary>
     private void v_TurnOnMouseDrag() // enable drag
     {
         if (mg_Cow != null)
             this.mg_Cow.GetComponent<CharacterMovesWhenDragging>().v_ChangeDragFlagTrue();
         if (mg_Bean != null)
             this.mg_Bean.GetComponent<CharacterMovesWhenDragging>().v_ChangeDragFlagTrue();
     }
     /// <summary>
     /// Flag change function -> Disable object dragging
     /// </summary>
     private void v_TurnOFFMouseDrag() // lock drag function
     {
         if (mg_Cow != null)
             this.mg_Cow.GetComponent<CharacterMovesWhenDragging>().v_ChangeDragFlagFalse();
         if (mg_Bean != null)
             this.mg_Bean.GetComponent<CharacterMovesWhenDragging>().v_ChangeDragFlagFalse();
     }
     /// <summary>
     /// Script (dialogue) function -> Set all text values to blank so that no script (dialogue) is output, and delete all generated speech bubbles.
     /// </summary>
     private void v_NoneScript()
   {
         if (mg_GenGFSpeechBubble != null)
         {
             mg_ScriptManager.GetComponent<ScriptManager>().v_NoneScript(2);
             Destroy(mg_GenGFSpeechBubble);
         }
         if (mg_GenJackSpeechBubble != null)
         {
             this.mg_ScriptManager.GetComponent<ScriptManager>().v_NoneScript(1);
             Destroy(this.mg_GenJackSpeechBubble);
         }
         mg_ScriptManager.GetComponent<ScriptManager>().v_NoneScript(0);
         mg_ScriptManager.GetComponent<ScriptManager>().v_NoneScript(1);
         mg_ScriptManager.GetComponent<ScriptManager>().v_NoneScript(2);
     }
     /// <summary>
     /// Script (dialogue) function -> Outputs the next script (dialogue) to the main script location.
     /// </summary>
     private void v_NextMainScript(){ // Print the next main script
         mg_ScriptManager.GetComponent<ScriptManager>().v_NextScript(0);
     }
     /// <summary>
     /// Script (dialogue) function -> Prints the following script (dialogue) to the Jack script location and creates a Jack speech bubble.
     /// </summary>
     private void v_NextJackScript(){ // Print next Jack script
         if (mg_GenJackSpeechBubble == null)
         {
             mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
             mg_GenJackSpeechBubble.transform.position = new Vector3(-0.5f, -1, 0);
         }
         mg_ScriptManager.GetComponent<ScriptManager>().v_NextScript(1);
     }
     /// <summary>
     /// Script (dialogue) function -> Prints the following script (dialogue) to the location of the grandfather script and creates a grandfather speech bubble.
     /// </summary>
     private void v_NextGFScript(){ // Print next grandfather script
         if (mg_GenGFSpeechBubble == null)
         {
             mg_GenGFSpeechBubble = Instantiate(mg_GFSpeech) as GameObject;
             mg_GenGFSpeechBubble.transform.position = new Vector3(4, 0.5f, 0);
         }
         mg_ScriptManager.GetComponent<ScriptManager>().v_NextScript(2);
     }
     /// <summary>
     /// Arrow-related functions -> Create an arrow pointing to the bean
     /// </summary>
     public void v_GenArrowToBean() // Generate arrow pointing to bean
     {
         if (mg_ArrowToBean == null)
         {
             mg_ArrowToBean = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToBean.transform.position = new Vector3(3.5f, -2.5f, 0);
         }
     }
     /// <summary>
     /// Arrow-related functions -> Create an arrow pointing to a cow
     /// </summary>
     public void v_GenArrowToCow() // Generate arrow pointing to cow
     {
         if (mg_ArrowToCow == null)
         {
             mg_ArrowToCow = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToCow.transform.position = new Vector3(-3.5f, -1, 0);
             mg_ArrowToCow.GetComponent<SpriteRenderer>().flipX = true;
         }
     }
   /// <summary>
     /// Arrow-related functions -> Create an arrow pointing to grandfather
     /// </summary>
     public void v_GenArrowToGF() // Generate arrow pointing to grandfather
     {
         if (mg_ArrowToGF == null)
         {
             mg_ArrowToGF = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToGF.transform.position = new Vector3(5.5f, 0, 0);
         }
     }
     /// <summary>
     /// Arrow-related functions -> Create an arrow pointing to Jack
     /// </summary>
     public void v_GenArrowToJack() // Generate arrow pointing to Jack
     {
         if (mg_ArrowToJack == null)
         {
             mg_ArrowToJack = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToJack.transform.position = new Vector3(-1.5f, -2, 0);
             mg_ArrowToJack.GetComponent<SpriteRenderer>().flipX = true;
         }
     }
     /// <summary>
     /// Arrow-related functions -> Delete the arrow pointing to grandfather
     /// </summary>
     public void v_RemoveArrowToGF() // Delete the arrow pointing to grandfather
     {
         if(mg_ArrowToGF != null)
         {
             Destroy(mg_ArrowToGF);
         }
     }
     /// <summary>
     /// Arrow-related functions -> Delete the arrow pointing to Jack
     /// </summary>
     public void v_RemoveArrowToJack() // Delete the arrow pointing to Jack
     {
         if (mg_ArrowToJack != null)
         {
             Destroy(mg_ArrowToJack);
         }
     }
     /// <summary>
     /// Arrow-related functions -> Delete the arrow pointing to the bean
     /// </summary>
     public void v_RemoveArrowToBean() // Remove arrow pointing to bean
     {
         if(this.mg_ArrowToBean != null)
         {
             Destroy(this.mg_ArrowToBean);
         }
     }
   /// <summary>
     /// Arrow-related functions -> Delete arrow pointing to cow
     /// </summary>
     public void v_RemoveArrowToCow() // Remove arrow pointing to cow
     {
         if (this.mg_ArrowToCow)
         {
             Destroy(this.mg_ArrowToCow);
         }
     }
     #endregion
}
