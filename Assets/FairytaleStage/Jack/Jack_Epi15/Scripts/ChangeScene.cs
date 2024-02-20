/*
  * - Name: ChangeScene.cs
  * - Content: Jack and the Beanstalk Episode 15 - Jack and the Beanstalk fairy tale replay button and button script to move to the game selection scene
  *
  * - HISTORY
  * 2021-07-20: Initial development
  * 2021-07-27: Fix comment processing
  *
  * <Function>
  * ReStart(): Jack_Epi1 scene load function (story replay button)
  * Select(): select_stage scene load function
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Button script to replay the Jack and the Beanstalk fairy tale and move to the game selection scene
public class ChangeScene: MonoBehaviour{
     //Jack_Epi1 scene load function (story replay button)
     public void ReStart(){
         SceneManager.LoadScene("Jack_Epi1");
     }

     //select_stage scene load function
     public void Select(){
         SceneManager.LoadScene("select_stage_scene");
         var obj = GameObject.Find("BGMmanager");
         if(obj != null) { //Turn off BGM
             Destroy(obj);
         }
     }
}
