/*
 * - Name: BrushYourTeeth_Virus1.cs
 * 
 * - Content: 
 * Virus 1 configuration script.
 * Set how many times it can be touched before dying.
 * Set death animation upon touch.
 *            
 * - Modification History
 * 2021-07-07: Production completed
 * 2021-07-16: File encoding fixed
 * 2021-07-20: Added TTS functionality
 *                  
 * 
 * - Variables 
 * mg_NumberOfVirusLeft: Object for connection to ControlUI.cs
 * man_OnClick: Animation triggered on click
 * man_Virus1_Die: Death animation
 * mn_Virus1_HP: Virus HP configuration variable
 * mb_CheckFlag: Flag to prevent counting while the dying animation is playing
 * vm: Object for handling Voice TTS
 * 
 * - Functions
 * OnMouseDown(): Function triggered when the virus is clicked
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushYourTeeth_Virus1 : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft; // Object for connection to ControlUI.cs

    public Animator man_OnClick; // Animation
    public Animator man_Virus1_Die; // Animation

    private int mn_Virus1_HP = 2; // Number of times the virus can be touched before disappearing

    private bool mb_CheckFlag; // Flag to prevent counting while the dying animation is playing

    VoiceManager vm; // Variable for Voice TTS object connection

    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft"); // Object connection
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>(); // Object connection

        mb_CheckFlag = false; // Initialize as false
    }

    void Update()
    {
    }

    
    private void OnMouseDown()
    {
        if (mn_Virus1_HP == 0) // Configuration for when virus HP reaches 0 and it dies
        {
            if(mb_CheckFlag == false) // Use a flag to ensure the virus only acts once upon dying
            {
                mb_CheckFlag = true;              
                mg_NumberOfVirusLeft.GetComponent<BrushYourTeeth_ControlUI>().v_MinusVirus(); // Decrease the number of remaining viruses
            }
            man_Virus1_Die.SetTrigger("Virus1_Die"); // After death animation
            vm.playVoice(0); // Voice when dying
            Destroy(gameObject, 1f); // Remove the object after 1 second
        }
        else // When touching the virus, reduce its HP
        {
            man_OnClick.SetTrigger("OnClick"); // Trigger animation on click
            mn_Virus1_HP -= 1;
            Debug.Log("Virus 1 Click Successful");
            vm.playVoice(2);
        }
    }
}
