/*
 * - Name: Mart_ControlOX.cs
 * - Writer: Kim Myunghyun
 * 
 * - Content: 
 * Script to display O or X based on the answer.
 * 
 * - Update Log -
 * 2021-07-08: Production completed
 * 2021-07-09: Code cleanup
 * 2021-07-20: Modified encoding format and updated comments
 * 2021-07-21: Added voice functionality for correct or incorrect answers
 *                  
 * - Variables: 
 * mg_O: Variable to link the O prefab
 * mg_X: Variable to link the X prefab
 * vm: Variable for connecting the TTS (Text-to-Speech) object
 * 
 * Functions:
 * v_ShowO(): Function to display O
 * v_ShowX(): Function to display X
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_ControlOX : MonoBehaviour {
    public GameObject mg_O;
    public GameObject mg_X;
    VoiceManager vm;

    void Start() {
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>(); // Connect the TTS object
    }

    void Update() {

    }

    /// <summary>
    /// Function to display O
    /// Destroy(show, n): You can change the delay for displaying and removing the image by modifying 'n'.
    /// </summary>
    public void v_ShowO() {
        GameObject show = Instantiate(mg_O) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("Creating the mg_O image");
        vm.playVoice(0); // Activate TTS
        Destroy(show, 1); // You can change the delay for displaying and removing the image by modifying this part
        Debug.Log("Removing the mg_O image");
    }

    /// <summary>
    /// Function to display X
    /// Destroy(show, n): You can change the delay for displaying and removing the image by modifying 'n'.
    /// </summary>
    public void v_ShowX() {
        GameObject show = Instantiate(mg_X) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("Creating the mg_X image");
        vm.playVoice(1); // Activate TTS
        Destroy(show, 1); // You can change the delay for displaying and removing the image by modifying this part
        Debug.Log("Removing the mg_X image");
    }
}
