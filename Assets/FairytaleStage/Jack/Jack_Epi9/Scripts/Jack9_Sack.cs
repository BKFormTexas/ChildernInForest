/*
  * - Name: Jack9_Sack.cs
  * - Content: Jack and the Beanstalk Episode 9 - Sack event related script
  * If you click on the bag multiple times, the bag explodes.
  *
  *
  *
  *
  * -Writing record-
  * 2021-07-15: Production completed
  *
  *
  *
  *
  * - Variable
  * mn_SackTouchCount: Number of touches required to explode
  *
  *-Function
  * OnMouseDown(): Function that operates when clicked
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Jack9_Sack : MonoBehaviour
{
     int mn_SackTouchCount;
     GameObjectEventController;
     private bool TouchSackFlag;
     private SoundManager msm_soundManager;
     private bool mb_PlayOnce;

     // Start is called before the first frame update
     void Start()
     {
         this.EventController = GameObject.Find("GameDirector");
         msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
         TouchSackFlag = false;
         mb_PlayOnce = false;
         mn_SackTouchCount = 5;
     }

     // Update is called once per frame
     void Update()
     {
         if(mn_SackTouchCount <= 0)
         {
             if(mb_PlayOnce == false)
             {
                 msm_soundManager.playSound(1);
                 mb_PlayOnce = true;
             }
             Destroy(gameObject);
             this.EventController.GetComponent<Jack9_EventController>().v_IsSackDestroy();
         }
     }

     private void OnMouseDown()
     {
         if (TouchSackFlag == true)
         {
             mn_SackTouchCount -= 1;
             msm_soundManager.playSound(0);
         }
     }

     public void ChangSackFlagTrue()
     {
         TouchSackFlag = true;
     }
}
