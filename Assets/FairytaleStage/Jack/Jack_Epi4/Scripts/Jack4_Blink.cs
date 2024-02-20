/*
  * - Name: Jack4_Blink.cs
  *
  * - Content:
  * Script that gives a sparkling effect
  *
  * -Update Log-
  * 2021-07-16: Production completed
  * 2021-07-21: Comment change
  *
  * - Variable
  * f_time: Variable for time measurement
  *
  * -Function()
  * v_StartBlink(): Function that provides a sparkling effect
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack4_Blink : MonoBehaviour
{
     float f_time;

     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         v_StartBlink();
     }

     /// <summary>
     /// Function that provides a sparkling effect
     /// </summary>
     public void v_StartBlink()
     {
         if (f_time < 0.5f)
         {
             GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
         }
         else
         {
             GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
             if (f_time > 1f)
                 f_time = 0;
         }
         f_time += Time.deltaTime;
     }
}
