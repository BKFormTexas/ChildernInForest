/*
  * - Name: Jack4_MouseDrag.cs
  * - Writer: Myeonghyun Kim
  *
  * - Content
  * Jack and the Beanstalk Episode 4 - Mouse event script
  * Modify the object so that it moves when the mouse is dragged.
  * When you release the mouse, the object moves to its original position.
  *
  * - Update Log -
  * 2021-07-13: Completed
  * 2021-07-23: Annotation changed
  *
  * - Variable
  * mv2_mouseDragPosition A vector that stores the mouse position.
  * mv2_worldObjectPosition Vector for conversion to camera world coordinates
  * mb_flag Flag to activate dragging at the desired time
  * - Function()
  * OnMouseDrag() When an object is dragged
  * When releasing the OnMouseUp() object
  * v_ChangeFlagTrue() Flag value True
  * v_ChangeFlagTrue() Flag value False
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Script that handles mouse operation related events
/// </summary>
public class Jack4_MouseDrag : MonoBehaviour
{
     private bool mb_flag;
     private bool mb_BeanPositionFlag;
     private SoundManager msm_soundManager;
     GameObject mg_ScriptManager;
     private bool PlayOnce;

     // Start is called before the first frame update
     void Start()
     {
         mb_BeanPositionFlag = false;
         msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
         this.mg_ScriptManager = GameObject.Find("GameDirector");
         PlayOnce = false;
     }

     /// <summary>
     /// When an object is dragged, the object moves according to the mouse position.
     /// </summary>
     private void OnMouseDrag()
     {
         if (mb_flag == true)
         {
             Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
             Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
             this.transform.position = mv2_worldObjectPosition;
             Debug.Log("Drag object");
             if (PlayOnce == false)
             {
                 msm_soundManager.playSound(0);
                 PlayOnce = true;
             }
         }

         if(this.tag == "Bean")
         {
             this.mg_ScriptManager.GetComponent<Jack4_EventController>().DragFalgTrue();
         }
     }

     //Set the mouse to return to its original position when you release it
     private void OnMouseUp()
     {
         Debug.Log("Removed from object");
         if (this.tag == "Bean")
         {
             if(mb_BeanPositionFlag == false)
             {
                 this.transform.position = new Vector3(-3, -4.5f, 0);
             }
             else
             {
                 this.transform.position = new Vector3(5.2f, -3.5f, 0);
             }
             this.mg_ScriptManager.GetComponent<Jack4_EventController>().DragFalgFalse();
             if(mb_flag == true)
             {
                 msm_soundManager.playSound(2);
             }
         }
         PlayOnce = false;
     }

     public void v_ChangeFlagTrue()
     {
         mb_flag = true;
     }
     public void v_ChangeFlagFalse()
     {
         mb_flag = false;
     }

     public void v_BeanPositionFlagTrue()
     {
         mb_BeanPositionFlag = true;
     }
}
