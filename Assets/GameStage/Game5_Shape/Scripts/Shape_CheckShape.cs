/*
  * - Name: Shape_CheckShape.cs
  * - Content: Script to check if all shapes have been matched and load the end scene
  * 
  * - HISTORY
  * 2021-07-06: Initial development
  * 2021-07-19: File encoding modification and commenting
  * 2021-07-27: Commenting modification
  *
  * <Variables>
  * vm: Object for processing Text-to-Speech (TTS) for voice
  * mb_checkVoice: Variable to check if the script voice has been played once
  *
  * <Function>
  * v_EndStage(): Load the end scene
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape_CheckShape : MonoBehaviour{
    VoiceManager vm;
    bool mb_checkVoice = false;

    // Initialization
    void Start(){
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    void Update(){
        if(transform.childCount <= 4){          // When all shapes are matched
            if(!mb_checkVoice){                 // If the script voice hasn't been played yet
                vm.playVoice(0);                // Play the script voice
                mb_checkVoice = true;           // Mark that the script voice has been played
            }
            Destroy(transform.Find("arrow"));   // Remove the arrow object
            Invoke("v_EndStage", 2f);           // Call the v_Endstage function after 2 seconds
        }
    }

    // Function to load the end scene
    void v_EndStage(){
        SceneManager.LoadScene("end_scene"); 
    }
}
