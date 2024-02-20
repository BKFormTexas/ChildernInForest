/*
  * - Name: Jack4_EventController.cs
  *
  * - Content:
  * Jack and the Beanstalk Episode 4 - Event Management Script
  * Script to comprehensively manage game progress events
  *
  * - Update Log -
  * 2021-07-14: Production completed
  * 2021-07-16: Arrow function added and encoding format changed
  * 2021-07-23: Add voice function and write comments
*
  * - Variable
  * Variable for connecting mg_ScriptManager object -> Variable for accessing game director object
  * Variable for connecting mg_Mother object -> Variable for accessing the mother object
  * Variable for connecting mvm_playVoice object -> Variable for accessing VoiceManager object
  * Variable for connecting mg_Bean object -> Variable for connecting bean object
  * mg_GenMotherSpeechBubble Variable related to speech bubble -> Variable for connection with mother speech bubble prefab
  * mg_MotherSpeech speech bubble related variable -> Variable for connection to mother speech bubble prefab
  * mg_GenJackSpeechBubble variable related to speech bubble -> Variable for connection to Jack speech bubble prefab
  * mg_JackSpeech speech bubble related variable -> Variable for connection to Jack speech bubble prefab
  * mb_DontLoopEvent1 Variable for event management -> Flag to avoid repetition of the same event
  * mb_DontLoopEvent2 Variable for event management -> Flag to avoid repetition of the same event
  * mb_EventFlag Variable for event management -> Flag to avoid repetition of the same event
  * mn_EventSequence Variable for event management -> Variable for managing event sequence
  * mb_IsDragBean Variable for event management -> Flag to check whether the bean object is being dragged.
  * mb_StopClickFlag Variable for event management -> Flag to prevent moving to the next event by clicking
  * Variable for managing the mb_BeanToMother event -> Flag to check whether the bean has been passed to the mother.
  * mb_BeanToWindow Variable for event management -> Flag to check whether the bean has been delivered to the window
  * Variable for mb_PlaySound event management -> Flag for sound to be played only once when the scene is first run
  * mg_ArrowToBean Arrow related variable -> Variable pointing to Jack's bean
  * mg_ArrowToMother Arrow-related variable -> Variable pointing to mother
  * mg_ArrowToBean2 Arrow-related variable -> Variable pointing to the mother's bean
  * mg_ArrowToWindow Arrow-related variable -> Arrow variable pointing to the window
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
  * v_NextMotherScript() mother script function -> prints the next mother script
  * v_NoneMotherScript() mother script function -> erases the content of the mother script and sets it so that nothing is output
  *
  *
  */
using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jack4_EventController: MonoBehaviour
{
     #region variable declaration part

     // Declare variables for object connection
     GameObject mg_ScriptManager; // Variable for accessing the game director object
     GameObject mg_Mother; // Variable to access mother object
     VoiceManager mvm_playVoice; // Variable to access VoiceManager object
     GameObject mg_Bean; // Variable to access bean object
     private SoundManager msm_soundManager; // Variable for accessing the SoundManager object

     // Speech bubble related variables
     GameObject mg_GenMotherSpeechBubble; // Variable for manipulating the mother’s speech bubble object
     public GameObject mg_MotherSpeech; // Variable for connection with mother speech bubble prefab
     GameObject mg_GenJackSpeechBubble; // Variable for manipulating the Jack speech bubble object
     public GameObject mg_JackSpeech; // Variable for connection to Jack speech bubble prefab

     // Variables for event management
     private bool mb_DontLoopEvent1; // Flag to avoid repeating the same event
     private bool mb_DontLoopEvent2; // Flag to avoid repeating the same event
     private bool mb_EventFlag; // Flag to avoid repeating the same event
     private int mn_EventSequence; // Variables that manage the order of events
     private bool mb_IsDragBean; // Flag to check if the bean object is being dragged
     private bool mb_StopClickFlag; // Flag to prevent moving to the next event by clicking
     private bool mb_BeanToMother; //Flag to check if the bean was passed to the mother
     private bool mb_BeanToWindow; //Flag to check if the bean was delivered to the window
     private bool mb_PlaySound; // Flag to make the voice sound only once when the scene is first run
    
     //Arrow related variables
     GameObject mg_ArrowToBean; // Arrow variable pointing to Jack's beans
     GameObject mg_ArrowToMother; // Arrow variable pointing to mother
     GameObject mg_ArrowToBean2; // Arrow variable pointing to mother's beans
     GameObject mg_ArrowToWindow; //Arrow variable pointing to window
     public GameObject mg_ArrowPrefab; // Variable for arrow prefab connection

     #endregion

     void Start()
     {
         //object connection
         this.mg_ScriptManager = GameObject.Find("GameDirector");
         this.mg_Bean = GameObject.Find("Bean");
         this.mg_Mother = GameObject.Find("Mother");
         this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
         msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

         //Initialize event flag to False
         mb_DontLoopEvent1 = false;
         mb_DontLoopEvent2 = false;
         mb_BeanToMother = false;
         mb_StopClickFlag = false;
         mb_BeanToWindow = false;
         mb_PlaySound = false;
         mb_IsDragBean = false;

         // start next event
         mn_EventSequence = 0;
         v_ChangeFlagFalse();
         v_NextMotherScript();
         v_GenMotherSpeechBubble();
         v_TurnOFFMouseDrag(); // Lock mouse drag function while dialogue is in progress
     }
  void Update()
     {
         // Check if object was passed and display arrow
         if (mb_IsDragBean == true && mb_BeanToMother == false)
         {
             v_RemoveArrowToBean();
             v_GenArrowToMom();
         }
         else if (mb_IsDragBean == false && mn_EventSequence == 2 && mb_BeanToMother == false)
         {
             v_GenArrowToBean();

             v_RemoveArrowToMom();
         }
         else if (mb_IsDragBean == true && mb_BeanToMother == true && mn_EventSequence >= 6)
         {
             v_RemoveArrowToBean2();
             v_GenArrowToWindow();
         }
         else if(mb_IsDragBean == false && mb_BeanToMother == true && mn_EventSequence >=6)
         {
             v_GenArrowToBean2();
             v_RemoveArrowToWindow();
         }

         if (Input.GetMouseButtonDown(0) && !(mvm_playVoice.isPlaying()) && mvm_playVoice.mb_checkSceneReady) // Set the next event to proceed when the screen is clicked
         {
             if(mb_StopClickFlag == false)
             {
                 mn_EventSequence += 1;
             }
             v_ChangeFlagTrue();
         }

         // Main event in progress
         if (mn_EventSequence == 0 && mb_PlaySound == false && mvm_playVoice.mb_checkSceneReady) // Run basic script when the scene is first run.
         {
             mb_PlaySound = true;
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 1 && this.mb_EventFlag == true) // When the screen is clicked once, the next event proceeds
         {
             v_ChangeFlagFalse();

             v_RemoveMotherSpeechBubble();

             v_NextMainScript();
             mvm_playVoice.playVoice(mn_EventSequence);
         }
         else if (mn_EventSequence == 2 && this.mb_EventFlag == true && mb_DontLoopEvent1 == false) // If the screen is clicked once, the next event proceeds
         {
             v_ChangeFlagFalse();

             v_NextEventScript();

             v_TurnOnMouseDrag();

             mb_DontLoopEvent1 = true;
             mb_StopClickFlag = true;
             mvm_playVoice.playVoice(mn_EventSequence);
             v_GenArrowToBean();
         }
         else if (mn_EventSequence == 2 && mb_BeanToMother == true && !(mvm_playVoice.isPlaying()) && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_NoneEventScript();

             v_GenJackSpeechBubble();
             v_NextJackScript();
             mvm_playVoice.playVoice(3);
             mb_StopClickFlag = false;
             v_TurnOFFMouseDrag();

             v_RemoveArrowToBean();
             v_RemoveArrowToMom();

         }
         else if (mn_EventSequence == 3 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_RemoveJackSpeechBubble();

             v_NextMainScript();
             mvm_playVoice.playVoice(4);
         }
         else if (mn_EventSequence == 4 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_NoneMainScript();

             v_GenMotherSpeechBubble();
             v_NextMotherScript();
             mvm_playVoice.playVoice(5);

             this.mg_Mother.GetComponent<Jack4_Mother>().ChangeMotherAngry();
         }
       else if (mn_EventSequence == 5 && this.mb_EventFlag == true)
         {
             v_ChangeFlagFalse();

             v_RemoveMotherSpeechBubble();

             v_NextMainScript();
             mvm_playVoice.playVoice(6);
         }
         else if (mn_EventSequence == 6 && this.mb_EventFlag == true && mb_DontLoopEvent2 == false)
         {
             v_ChangeFlagFalse();

             v_NextEventScript();

             v_TurnOnMouseDrag();
             mb_StopClickFlag = false;
             mb_DontLoopEvent2 = true;
             mvm_playVoice.playVoice(7);

             v_GenArrowToBean2();
         }

         if(mb_BeanToWindow == true) // When the bean is delivered to the window, move to the next scene
         {
             if(mb_PlaySound == true)
             {
                 mb_PlaySound = false;
                 msm_soundManager.playSound(1);
             }
             Invoke("NextScene", 1f);
             //SceneManager.LoadScene("Jack_Epi5");
         }
     }

     #region function declaration

     /// <summary>
     /// Flag change function
     /// </summary>
     private void v_ChangeFlagFalse() // Flag value True
     {
         this.mb_EventFlag = false;
     }
     private void v_ChangeFlagTrue() // Flag value False
     {
         this.mb_EventFlag = true;
     }

     /// <summary>
     /// Script-related functions
     /// </summary>
     private void v_NextMainScript() // Print the next main script
     {
         this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NextScript();
     }
     private void v_NoneMainScript() // Clears the contents of the main script so that nothing is output.
     {
         this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NoneScript();
     }
     private void v_NextEventScript() // Print the next event script
     {
         this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NextScript();
     }
     private void v_NoneEventScript() // Clears the event script contents so that nothing is output
     {
         this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NoneScript();
     }
     private void v_NextJackScript() // Print the next Jack script
     {
         this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NextScript();
     }
     private void v_NoneJackScript() // Deletes the Jack script contents so that nothing is output
     {
         this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NoneScript();
     }
     private void v_NextMotherScript() // print next mother script
     {
         this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NextScript();
     }
     private void v_NoneMotherScript() // Erase the contents of the mother script so that nothing is output
     {
         this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NoneScript();
     }

    /// <summary>
     /// Speech bubble related functions
     /// </summary>
     private void v_GenMotherSpeechBubble()
     {
         mg_GenMotherSpeechBubble = Instantiate(mg_MotherSpeech) as GameObject;
         mg_GenMotherSpeechBubble.transform.position = new Vector3(1, 1, 0);
     }
     private void v_GenJackSpeechBubble()
     {
         mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
         mg_GenJackSpeechBubble.transform.position = new Vector3(-2, -1, 0);
     }

     //Speech bubble deletion function
     private void v_RemoveMotherSpeechBubble()
     {
         this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NoneScript();
         Destroy(this.mg_GenMotherSpeechBubble);
     }
     private void v_RemoveJackSpeechBubble()
     {
         this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NoneScript();
         Destroy(this.mg_GenJackSpeechBubble);
     }

     //Enable dragging
     private void v_TurnOnMouseDrag()
     {
         this.mg_Bean.GetComponent<Jack4_MouseDrag>().v_ChangeFlagTrue();
     }

     //Disable dragging
     private void v_TurnOFFMouseDrag()
     {
         this.mg_Bean.GetComponent<Jack4_MouseDrag>().v_ChangeFlagFalse();
     }

     public void v_BeanToMother()
     {
         this.mb_BeanToMother = true;
     }

     public bool b_CheckBeanToMother()
     {
         return mb_BeanToMother;
     }

     public void v_BeanToWindow()
     {
         this.mb_BeanToWindow = true;
     }

     public void v_GenArrowToBean()
     {
         if (mg_ArrowToBean == null)
         {
             mg_ArrowToBean = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToBean.transform.position = new Vector3(-2, -3.5f, 0);
             mg_ArrowToBean.GetComponent<SpriteRenderer>().flipX = true;
         }
     }
     public void v_GenArrowToMom()
     {
         if (mg_ArrowToMother == null)
         {
             mg_ArrowToMother = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToMother.transform.position = new Vector3(3, 0.5f, 0);
             mg_ArrowToMother.GetComponent<SpriteRenderer>().flipX = false;
         }
     }
     public void v_GenArrowToBean2()
     {
         if (mg_ArrowToBean2 == null)
         {
             mg_ArrowToBean2 = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToBean2.transform.position = new Vector3(3.5f, -2.7f, 0);
             mg_ArrowToBean2.GetComponent<SpriteRenderer>().flipX = false;
         }
     }
  public void v_GenArrowToWindow()
     {
         if (mg_ArrowToWindow == null)
         {
             mg_ArrowToWindow = Instantiate(mg_ArrowPrefab) as GameObject;
             mg_ArrowToWindow.transform.position = new Vector3(4.8f, 4, 0);
             mg_ArrowToWindow.GetComponent<SpriteRenderer>().flipX = false;
         }
     }

     public void v_RemoveArrowToBean()
     {
         if (mg_ArrowToBean != null)
         {
             Destroy(mg_ArrowToBean);
         }
     }
     public void v_RemoveArrowToMom()
     {
         if (mg_ArrowToMother != null)
         {
             Destroy(mg_ArrowToMother);
         }
     }
     public void v_RemoveArrowToBean2()
     {
         if (mg_ArrowToBean2 != null)
         {
             Destroy(mg_ArrowToBean2);
         }
     }
     public void v_RemoveArrowToWindow()
     {
         if (mg_ArrowToWindow != null)
         {
             Destroy(mg_ArrowToWindow);
         }
     }

     public void DragFalgTrue()
     {
         mb_IsDragBean = true;
     }

     public void DragFalgFalse()
     {
         mb_IsDragBean = false;
     }

     public void NextScene()
     {
         SceneManager.LoadScene("Jack_Epi5");
     }
     #endregion
}
