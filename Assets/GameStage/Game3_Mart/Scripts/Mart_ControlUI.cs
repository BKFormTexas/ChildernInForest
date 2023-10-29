/*
 * - Name: Mart_ControlUI.cs
 * 
 * - Content:
 * Script for managing remaining items in an array, determining the correct answer randomly based on this array, and using a flag to keep track of item changes.
 * 
 * - Update Log -
 * 2021-07-08: Production completed
 * 2021-07-09: Code cleanup
 * 2021-07-20: Modified encoding format and updated comments
 *                  
 * - Variables:
 * mba_MarketRandomItemArr: Array for managing the correctness of each item
 * mn_RandomValue: Variable for storing the correct answer
 * mb_ChangeItemFlag: Flag to check if the item has changed
 * n_i: Counter for loops
 * 
 * Functions:
 * v_MartCheckRandomItemArr(): Function to mark the 'num' element as a correct answer in the array
 * n_MartRandomItemValue(): Function to set a random value for items that have never been the correct answer, based on the correctness array
 * n_HowManyleftArr(): Function to return how many correct answers are left for the game to be completed
 * v_ChangeFlagTrue(): Function to set 'mb_ChangeItemFlag' to True
 * v_ChangeFlagFalse(): Function to set 'mb_ChangeItemFlag' to False
 * b_checkFlag(): Function to return the value of 'mb_ChangeItemFlag'
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_ControlUI : MonoBehaviour {
    private bool[] mba_MarketRandomItemArr = new bool[6]; // Array for managing correctness
    private int mn_RandomValue;
    private bool mb_ChangeItemFlag;
    
    void Start() {
        mb_ChangeItemFlag = false; // Initialize the flag to False
   
        for (int n_i = 0; n_i < 6; n_i++) { // Initialize the correctness array to False
            mba_MarketRandomItemArr[n_i] = false;
        }
    }

    void Update() {

    }

    /// <summary>
    /// Function to mark the 'num' element as a correct answer in the array
    /// </summary>
    /// <param name="num">The 'num' element in the correctness array is set to True</param>
    public void v_MartCheckRandomItemArr(int num) {
        mba_MarketRandomItemArr[num] = true;
        Debug.Log("Setting True for element " + num + " in the array");
    }

    /// <summary>
    /// Function to set a random value for items that have never been the correct answer, based on the correctness array
    /// </summary>
    /// <returns>int: A random value</returns>
    public int n_MartRandomItemValue() {
        while (true) {
            mn_RandomValue = Random.Range(0, 6);
            if (mba_MarketRandomItemArr[mn_RandomValue] == false) {
                break;
            }
        }
        return mn_RandomValue;
    }

    /// <summary>
    /// Function to return how many correct answers are left for the game to be completed
    /// </summary>
    /// <returns>int: Number of remaining correct answers</returns>
    public int n_HowManyleftArr() {
        int n_left = 0;
        for (int n_i = 0; n_i < 6; n_i++) {
            if (mba_MarketRandomItemArr[n_i] == true) {
                Debug.Log("Value of element " + n_i + " is true");
            }
            if (mba_MarketRandomItemArr[n_i] == false) {
                Debug.Log("Value of element " + n_i + " is false");
                n_left += 1;
            }
        }
        Debug.Log("Remaining items: " + n_left);
        return n_left;
    }

    /// <summary>
    /// Function to set 'mb_ChangeItemFlag' to True
    /// </summary>
    public void v_ChangeFlagTrue() {
        mb_ChangeItemFlag = true;
        Debug.Log("Flag set to True");
    }

    /// <summary>
    /// Function to set 'mb_ChangeItemFlag' to False
    /// </summary>
    public void v_ChangeFlagFalse() {
        mb_ChangeItemFlag = false;
        Debug.Log("Flag set to False");
    }

    /// <summary>
    /// Function to return the value of 'mb_ChangeItemFlag'
    /// </summary>
    /// <returns>Flag value</returns>
    public bool b_checkFlag() {
        return mb_ChangeItemFlag;
    }
}
