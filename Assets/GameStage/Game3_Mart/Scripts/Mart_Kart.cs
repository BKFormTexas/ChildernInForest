/*
 * - Name: Mart_Kart.cs
 * 
 * - Content:
 * Script for the cart object. Checks for collisions, verifies correctness, and handles objects accordingly.
 * If it's the correct answer, it displays 'O' and deletes the object.
 * If it's incorrect, it resets the object's position and displays 'X'.
 * 
 * - Update Log -
 * 2021-07-07: Production completed
 * 2021-07-08: Added functionality to display OX
 * 2021-07-09: Modified variable names
 *                  
 * - Variables:
 * mg_GameDirector: Variable for connecting the GameDirector object
 * mg_ShowOX: Variable for connecting the ShowOX object
 * mg_MartRandomItem: Variable for connecting the Mart_RandomItem object
 * mn_answer: Variable for storing the correct answer
 * mn_LeftTime: Variable for storing the remaining count
 * 
 * Functions:
 * OnTriggerEnter2D(Collider2D cCollidObj): Function that operates when objects collide
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_Kart : MonoBehaviour {
    GameObject mg_GameDirector;
    GameObject mg_ShowOX;
    GameObject mg_MartRandomItem;

    int mn_answer;
    int mn_LeftTime;

    void Start() {
        this.mg_GameDirector = GameObject.Find("GameDirector"); // Connect game objects
        this.mg_ShowOX = GameObject.Find("ShowOX");
        this.mg_MartRandomItem = GameObject.Find("Mart_RandomItem");
    }

    void Update() {
        mn_answer = mg_MartRandomItem.GetComponent<Mart_RandomItem>().n_ReturnAnswer(); // Receive the correct answer in real-time
    }

    /// <summary>
    /// Function that operates when the cart object collides with other objects. 
    /// It uses the 'mn_answer' variable to check if it's the correct answer and handles it accordingly.
    /// </summary>
    /// <param name="cCollidObj">The collided object</param>
    void OnTriggerEnter2D(Collider2D cCollidObj) {
        if (cCollidObj.tag == "Mart_Item1" && mn_answer == 0) {
            Debug.Log("Deleting Mart_Item1");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(0);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item1" && mn_answer != 0) {
            Debug.Log("Incorrect");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item2" && mn_answer == 1) {
            Debug.Log("Deleting Mart_Item2");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(1);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item2" && mn_answer != 1) {
            Debug.Log("Incorrect");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item3" && mn_answer == 2) {
            Debug.Log("Deleting Mart_Item3");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(2);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item3" && mn_answer != 2) {
            Debug.Log("Incorrect");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item4" && mn_answer == 3) {
            Debug.Log("Deleting Mart_Item4");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(3);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item4" && mn_answer != 3) {
            Debug.Log("Incorrect");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item5" && mn_answer == 4) {
            Debug.Log("Deleting Mart_Item5");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(4);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item5" && mn_answer != 4) {
            Debug.Log("Incorrect");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item6" && mn_answer == 5) {
            Debug.Log("Deleting Mart_Item6");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(5);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item6" && mn_answer != 5) {
            Debug.Log("Incorrect");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
    }
}
