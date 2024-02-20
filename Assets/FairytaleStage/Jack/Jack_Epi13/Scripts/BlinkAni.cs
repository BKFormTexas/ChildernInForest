/*
 * - Name: BlinkAni.cs
 * - Content: Jack and the Beanstalk Episode 13 - Script for Blinking Arrow Effect
 * 
 * - HISTORY
 * 2021-07-14: Initial development
 * 2021-07-16: File encoding modification and comment processing
 * 2021-07-27: Comment processing modification
 *
 * <Variable>
 * f_blink: Blinking speed          
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animation class for making the mission arrow blink
public class BlinkAni : MonoBehaviour
{
    float f_blink;

    /*Blinking effect*/
    public void Update()
    {
        if (f_blink < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1); // Full opacity
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); // Fully transparent
            if (f_blink > 1f)
            {
                f_blink = 0;
            }
        }
        f_blink += Time.deltaTime;
    }
}
