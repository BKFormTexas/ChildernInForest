/*
 * - Name: BrushYourTeeth_Virus1Generator.cs
 * 
 * - Content: 
 * Script for automatic generation of Virus 1.
 * Set the number of viruses to be created.
 * Set where viruses will be generated.
 *            
 * - Modification History
 * 2021-07-07: Production completed
 * 2021-07-16: File encoding fixed
 *                  
 * 
 * - Variables 
 * mg_Virus1_Prefab: Object for prefab connection
 * mf_span: Generation interval for Virus 1 (modify to change the generation interval in seconds)
 * mf_delta: Time tracking variable
 * mn_virus1_cnt: Variable for counting the total generated viruses
 * ma2f_Virus1Position: 2D array for storing virus generation positions
 * 
 * n_i: Variable for loop count
 * n_j: Same as n_i
 * 
 * n_Virus1PositionX: X position of Virus 1
 * n_Virus1PositionY: Y position of Virus 1
 * 
 * g_GenerateVirus1: Virus 1 object generated using the prefab
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushYourTeeth_Virus1Generator : MonoBehaviour
{
    public GameObject mg_Virus1_Prefab;

    float mf_span = 3.0f; // Modify this part to change the generation interval of Virus 1 (in seconds)

    float mf_delta = 0;
    int mn_virus1_cnt = 1;

    float[,] ma2f_Virus1Position = new float[5, 2];

    void Start()
    {
        while (true) // Loop for setting virus generation positions
        {
            for (int n_i = 0; n_i < 5; n_i++) // Store the positions where viruses will be generated in the ma2f_Virus1Position array
            {
                int n_Virus1PositionX = Random.Range(-4, 4);
                float f_Virus1PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus1Position[n_i, 0] = n_Virus1PositionX;
                ma2f_Virus1Position[n_i, 1] = f_Virus1PositionY;
            }

            for (int n_i = 0; n_i < 4; n_i++) // Loop to ensure viruses are not generated at the same location
            {
                for (int n_j = 1; n_j < 5; n_j++)
                {
                    if (n_i == n_j)
                    {
                        n_j++;
                    }
                    if (Mathf.Abs(ma2f_Virus1Position[n_i, 0]) == Mathf.Abs(ma2f_Virus1Position[n_j, 0]) && (Mathf.Abs(ma2f_Virus1Position[n_i, 1]) - Mathf.Abs(ma2f_Virus1Position[n_j, 1]) < 0.8) && (Mathf.Abs(ma2f_Virus1Position[n_i, 1]) - Mathf.Abs(ma2f_Virus1Position[n_j, 1]) > -0.8))
                    {
                        int n_Virus1PositionX = Random.Range(-4, 4);
                        float f_Virus1PositionY = Random.Range(-0.6f, -3.3f);

                        ma2f_Virus1Position[n_j, 0] = n_Virus1PositionX;
                        ma2f_Virus1Position[n_j, 1] = f_Virus1PositionY;
                        n_i = 0;
                        continue;
                    }
                }
            }
            break;  
        }
        GameObject g_GenerateVirus1 = Instantiate(mg_Virus1_Prefab) as GameObject;

        g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[0, 0], ma2f_Virus1Position[0, 1], 0); // Generate the first Virus 1
        Debug.Log("Position of generated Virus 1 1st: " + ma2f_Virus1Position[0, 0] + " " + ma2f_Virus1Position[0, 1]);
    }

    void Update()
    {
        this.mf_delta += Time.deltaTime;

        if (this.mf_delta > this.mf_span && mn_virus1_cnt < 5) // Modify the number of Virus 1 to be created here (5)
        {
            this.mf_delta = 0;
            GameObject g_GenerateVirus1 = Instantiate(mg_Virus1_Prefab) as GameObject;
            g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[mn_virus1_cnt, 0], ma2f_Virus1Position[mn_virus1_cnt, 1], 0);
            Debug.Log("Virus 1 " + (mn_virus1_cnt+1) + "th position: " + ma2f_Virus1Position[mn_virus1_cnt, 0] + " " + ma2f_Virus1Position[mn_virus1_cnt, 1]); // Generate Virus 1 from 2 onwards
            mn_virus1_cnt++;
        }
    }
}
