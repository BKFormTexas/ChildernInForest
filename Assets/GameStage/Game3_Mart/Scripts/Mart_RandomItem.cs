/*
 * - Name: Mart_RandomItem.cs
 * 
 * - Content:
 * Random selection of items to avoid duplication.
 * 
 * - Update Log -
 * 2021-07-07: Writing completed
 * 2021-07-08: Added OX functionality
 * 2021-07-09: Variable name cleanup
 * 2021-07-21: Encoding format modified, and comments rewritten
 *                  
 * - Variables:
 * mg_RandomItem: Variable for connecting to the Mart_RandomItem object
 * mg_GameDirector: Variable for connecting to the GameDirector object
 * mspa_SpriteImage: Array for storing item object images
 * mn_RandomValue: Variable to store the random item value
 * mn_leftTime: Variable to store the remaining number of items
 * mb_ItemFlag: Flag to indicate when the correct answer needs to be changed
 * 
 * Functions:
 * n_n_ReturnAnswer(): Returns the random item's correct answer value.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mart_RandomItem : MonoBehaviour{

    GameObject mg_RandomItem;                                            // Variable for connecting to the Mart_RandomItem object
    GameObject mg_GameDirector;                                          // Variable for connecting to the GameDirector object
    public Sprite[] mspa_SpriteImage = new Sprite[6];                    // Array to store item object images
    int mn_RandomValue;                                                 // Variable to store the random item value
    int mn_leftTime;                                                    // Variable to store the remaining number of items
    bool mb_ItemFlag;                                                   // Flag to indicate when the correct answer needs to be changed

    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");          // Object connections
        this.mg_RandomItem = GameObject.Find("Mart_RandomItem");
        mn_RandomValue = mg_GameDirector.GetComponent<Mart_ControlUI>().n_MartRandomItemValue(); // Store the random value
        this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue]; // Change the item image according to the random value
        mb_ItemFlag = false;                                              // Initialize the flag value to false
    }

    void Update(){
        mb_ItemFlag = mg_GameDirector.GetComponent<Mart_ControlUI>().b_checkFlag(); // Update the real-time flag value for changing the correct answer
        if (mb_ItemFlag == true){           // If the flag value changes
            mn_leftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr(); // Check the remaining number of items
            if(mn_leftTime != 0){           // If there are still items remaining
                mn_RandomValue = mg_GameDirector.GetComponent<Mart_ControlUI>().n_MartRandomItemValue(); // Reassign the random value
                this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue]; // Change the item image according to the random value
                mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagFalse(); // Change the flag value to false
            }
            else if(mn_leftTime == 0){       // If the remaining number of items is 0, clear
                SceneManager.LoadScene("end_scene");
            } 
        }
    }

    /// <summary>
    /// Returns the correct answer value of the random item.
    /// </summary>
    /// <returns>int Correct answer value</returns>
    public int n_ReturnAnswer(){                                                            
        return mn_RandomValue;
    }
}
