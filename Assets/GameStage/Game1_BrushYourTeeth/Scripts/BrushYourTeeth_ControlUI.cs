/*
 * - Name: BrushYourTeeth_ControlUI.cs
 *
 * - Content: Script to control an object ("NumberOfVirusLeft") that displays the number of viruses remaining
 *
 * - Revision History
 * 2021-07-07: Production completed
 * 2021-07-16: File encoding fixed
 *
 * - Variables
 * mg_NumberOfVirusLeft: Canvas sub-object, object for updating the number of remaining viruses
 * mn_LeftVirus: Variable for storing the number of remaining viruses
 *
 * - Functions
 * v_MinusVirus(): Function to decrease the number of remaining viruses
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrushYourTeeth_ControlUI : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft; // Declaration for object connection

    private int mn_LeftVirus = 10; // Number of remaining viruses, if you modify the number of viruses, you need to change the number of each virus created

    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft"); // Object connection
    }

    void Update()
    {
        this.mg_NumberOfVirusLeft.GetComponent<Text>().text = "Remaining Viruses: " + this.mn_LeftVirus; // Real-time update of the remaining virus count

        if (this.mn_LeftVirus == 0) // When the remaining virus count becomes 0, the game ends
        {
            SceneManager.LoadScene("end_scene");
        }
    }

    /// <summary>
    /// Function to decrease the number of remaining viruses
    /// </summary>
    public void v_MinusVirus()
    {
        this.mn_LeftVirus -= 1; // Decrease the virus count
        Debug.Log("Remaining Virus Count Decreased by 1");
        Debug.Log(this.mn_LeftVirus);
    }
}
