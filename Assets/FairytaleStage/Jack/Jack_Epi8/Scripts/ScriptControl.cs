/*
   * - Name: ScriptControl.cs
   * - Content: Jack and the Beanstalk Episode 14 - ScriptControl
   *
   * - HISTORY
   * 2021-07-14: Initial development
   * 2021-07-16: Fixed file encoding and commented out
   * 2021-07-27: Fix comment processing
   *
   * <Variable>
   * mg_targetPosition: Specifies the walkPos object in the inspector window and moves the giant to the walkPos position.
   * mb_checkPlayOnce: Variable to check to ensure that the script voice is executed only once
   * sc: Object to represent fairy tale script
   * vm: Object connection that handles voice TTS
   *
   * <Variable>
   * instance: ScriptControl
   * mg_setGameObject: Find and save the game object named Jack_Script
   * mt_setText: Contains the Text component of the mg_setGameObject object.
   * mn_checkCurrentScr: Index of script to display in mt_setText
   * ms_setScriptText: List containing script content equal to the number of scripts
   * mn_setScriptNum: Initial number of scripts: 5
   *
   * <Function>
   * GetInstance(): Check whether instance exists and create it if it does not exist
   * setNextScript(): Shows the next sentence of the script.
   */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will display the script in the Jack_Script window
public class ScriptControl: MonoBehaviour{
     /*Singleton implementation*/
     private static ScriptControl instance; //Declared as static so that the same instance can be shared in multiple places
     private GameObject mg_setGameObject;
     private Text mt_setText;
     private int mn_checkCurrentScr = 0;
     public string[] ms_setScriptText = new string[mn_setScriptNum];
     public const int mn_setScriptNum = 5;
    
     //Initial settings
     void Start(){
         mg_setGameObject = GameObject.Find("Jack_Script");
         mt_setText = mg_setGameObject.GetComponent<Text>();
         mt_setText.text = ms_setScriptText[mn_checkCurrentScr];
     }

     //Function to check whether the instance exists and then create it if it does not exist
     public static ScriptControl GetInstance(){
         if (!instance){ // if instance does not exist
             instance = GameObject.FindObjectOfType(typeof(ScriptControl)) as ScriptControl; // Find an instance of the ScriptControl class
             if (!instance){ // If it doesn't exist even after looking for it, create a new one
                 GameObject obj = new GameObject("ScriptControl"); // Create a new object with the name ScriptControl
                 instance = obj.AddComponent(typeof(ScriptControl)) as ScriptControl; // Add ScriptControl type component to obj
             }
         }
         return instance; // Returns instance.
     }

     //Function to display the next statement of the script
     public void setNextScript(){
         mn_checkCurrentScr++; //Move index to next script
         mt_setText.text = ms_setScriptText[mn_checkCurrentScr]; //Show the next script
     }
}
