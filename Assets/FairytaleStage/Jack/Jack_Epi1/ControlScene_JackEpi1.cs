/*
 * - Name: ControlScene_JackEpi1.cs
 * - Content: Jack and the Beanstalk Episode 1 -
 *
 * - History -
 * 2021-07-20: Comment added.
 * 2021-07-23: Added TTS (Text-to-Speech) voice output functionality.
 * 2021-07-27: Comment modifications based on feedback.
 *
 * - ControlScene_JackEpi1 Member Variables
 *
 * ms_LoadScene: Variable to store the next scene by allowing input in the Inspector window.
 * mb_PlayOnce = false: Variable to check if the voice should be played only once.
 * mvm_PlayVoice: Class for preparing and outputting voice.
 *
 * - ControlScene_JackEpi1 Member Functions
 *
 * GetMouseButtonUp(0): Function that calls the clickedMouse function on left-click.
 * SceneManager.LoadScene(""): Function to move to the next scene.
 * Start(): Initializes VoiceManager to output voice.
 * Update(): Ensures that the voice is played only once when ready.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class for transitioning from the first scene of Jack and the Beanstalk to the next scene.
public class ControlScene_JackEpi1 : MonoBehaviour {
    public string ms_LoadScene;
    public bool mb_PlayOnce = false;
    private VoiceManager mvm_PlayVoice;

    void Start() {
        mvm_PlayVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    // Detects left-click by the player in the scene and calls the clickedMouse function.
    void Update() {
        if(mvm_PlayVoice.mb_checkSceneReady && !mb_PlayOnce) {
            mvm_PlayVoice.playVoice(0);
            mb_PlayOnce = true;
        }
        if(!mvm_PlayVoice.isPlaying()) {
            if (Input.GetMouseButtonUp(0)) {
                clickedMouse();
            }
        }

    }

    // When this function is called, it transitions to the next scene.
    void clickedMouse() {
        SceneManager.LoadScene(ms_LoadScene);
    }
}
