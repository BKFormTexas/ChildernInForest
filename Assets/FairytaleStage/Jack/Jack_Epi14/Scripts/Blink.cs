/*
   * - Name: Blink.cs
   * - Content: Jack and the Beanstalk Episode 14 - Arrow blinking effect script
   *
   * - HISTORY
   * 2021-07-15: Initial development
   * 2021-07-16: Fixed file encoding and commented out
   * 2021-07-27: Fix comment processing
   *
   * <Variable>
   * mf_time: blinking speed
   * mf_timer: Elapsed time
   * mf_waitingTime: Specify a specific desired time
   */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

// Animation class that makes the mission arrow blink
public class Blink: MonoBehaviour{
     float mf_time;
     float mf_timer;
     float mf_waitingTime;
    
     //Initial settings
     void Start(){
         mf_timer = 0.0f;
         mf_waitingTime = 5.0f; //5 seconds later
     }

     /*blinking effect*/
     public void Update(){
         mf_timer += Time.deltaTime;
         if(mf_timer > mf_waitingTime){
             if (mf_time < 0.3f){
                 GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1); //Transparency 1
             }
             else{
                 GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); //Transparency 0
                 if (mf_time > 1f){
                     mf_time = 0;
                 }
             }
             mf_time += Time.deltaTime;
         }
     }
}
