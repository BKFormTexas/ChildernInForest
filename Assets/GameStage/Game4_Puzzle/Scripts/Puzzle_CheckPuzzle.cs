/*
 * - Name: Puzzle_CheckPuzzle.cs
 * - Content: Script to check if all puzzles have been matched and load the end scene
 * 
 * - HISTORY
 * 2021-07-06: Initial development
 * 2021-07-16: Updated file encoding and added comments
 * 2021-07-27: Modified comments
 *
 * <Variables>
 * vm: Object for processing Text-to-Speech (TTS) for voice
 * mb_checkVoice: Variable to check if the script voice has been played once
 * mgo_RemainPuzzle: Reference to the remaining puzzle object
 * mn_AnswerPuzzle: The number of answer puzzles expected, initialized to -1
 * mn_CheckAnswerPuzzle: Counter for the answer puzzles that have been correctly matched, initialized to 0
 *
 * <Functions>
 * v_EndStage(): Load the end scene
 * setAnswerPuzzle(): Increment the counter for correctly matched answer puzzles
 * Author: Lee Yoonkyo
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_CheckPuzzle : MonoBehaviour {
    VoiceManager vm;
    bool mb_checkVoice = false;
    GameObject mgo_RemainPuzzle;
    public int mn_AnswerPuzzle = -1;
    int mn_CheckAnswerPuzzle = 0;

    // Initialization
    void Start() {
        vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        mgo_RemainPuzzle = GameObject.Find("ProblemWindow").gameObject;
    }

    void Update() {
        if (mn_AnswerPuzzle == mn_CheckAnswerPuzzle) {
            // If all puzzles have been matched
            if (!mb_checkVoice) {
                // If the script voice hasn't been played yet
                vm.playVoice(0);
                // Play the script voice
                mb_checkVoice = true;
                // Mark that the script voice has been played
            }
            Destroy(GameObject.Find("arrow"));
            // Remove the arrow object
            Invoke("v_EndStage", 2f);
            // Call the v_Endstage function after 2 seconds
        }
    }

    public void setAnswerPuzzle() {
        mn_CheckAnswerPuzzle++;
    }

    // Function to load the end scene
    void v_EndStage() {
        SceneManager.LoadScene("end_scene");
    }
}
