/*
 * - Name: HarpJackCollision.cs
 * - Content: Jack and the Beanstalk Episode 12 - Jack and Harp Drag Script
 * - History -
 * 2021-07-20: Comment added.
 * 2021-07-23: Added TTS (Text-to-Speech) voice output functionality.
 * 2021-07-26: Added sound effects (by Lee Yunkyo).
 * 2021-07-27: Comment modifications based on feedback.
 *
 * - HarpJackCollision Member Variables
 *
 * GameObject mg_talk_Prefab: Variable to store the speech bubble object.
 * bool mb_playOnce = false: Variable to check if the voice should be played only once.
 * VoiceManager mvm_playVoice: Class for preparing and outputting voice.
 * AudioSource HarpSound: Audio source for harp sound effect.
 *
 * - HarpJackCollision Member Functions
 *
 * OnTriggerEnter2D(Collider2D cCollideObject): Function called once when collision occurs between objects.
 * OnMouseDrag(): Function to move the game object by dragging with the mouse.
 * Invoke("changeNextScene", 3f): Function to invoke the specified function ("") after 3 seconds.
 * changeNextScene(): Function to transition to the specified scene ("").
 * Start(): Initializes VoiceManager to output voice and sets up the harp sound effect.
 * Update(): Ensures that the voice is played only once when ready.
 * PlayHarp(): Function to play the harp sound effect.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class implementing the result when the harp and Jack collide.
public class HarpJackCollision : MonoBehaviour
{
    public GameObject mg_talk_Prefab;
    public bool mb_playOnce = false;
    private VoiceManager mvm_playVoice;
    private AudioSource HarpSound; // Harp sound

    // Initialize VoiceManager class.
    void Start()
    {
        mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        HarpSound = GameObject.Find("HarpSound").GetComponent<AudioSource>();
    }

    // If voice is ready through VoiceManager, play the voice only once.
    void Update()
    {
        if (mvm_playVoice.mb_checkSceneReady && !mb_playOnce)
        {
            mvm_playVoice.playVoice(0);
            mb_playOnce = true;
        }
    }

    // When the harp and Jack collide, create a speech bubble object and transition to the next scene after 3 seconds.
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        GameObject g_talk = Instantiate(mg_talk_Prefab) as GameObject;
        PlayHarp();
        Invoke("changeNextScene", 4f);
    }

    void changeNextScene()
    {
        SceneManager.LoadScene("Jack_Epi13");
    }

    void PlayHarp()
    {
        HarpSound.Play();
    }
}
