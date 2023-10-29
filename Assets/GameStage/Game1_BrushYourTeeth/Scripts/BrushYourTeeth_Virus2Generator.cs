/*
 * - Name: BrushYourTeeth_Virus2Generator.cs
 * 
 * - Content: 
 * Script for automatic generation of Virus 2.
 * Set the number of viruses to be created.
 * Set where viruses will be generated.
 *            
 * - Modification History
 * 2021-07-07: Production completed
 * 2021-07-16: File encoding fixed
 *                  
 * 
 * - Variables 
 * mg_Virus2_Prefab: Object for prefab connection
 * mf_span: Generation interval for Virus 2 (modify to change the generation interval in seconds)
 * mf_delta: Time tracking variable
 * mn_virus2_cnt: Variable for counting the total generated viruses
 * ma2f_Virus2Position: 2D array for storing virus generation positions
 * 
 * n_i: Variable for loop count
 * n_j: Same as n_i
 * 
 * n_Virus2PositionX: X position of Virus 2
 * n_Virus2PositionY: Y position of Virus 2
 * 
 * g_GenerateVirus2: Virus 2 object generated using the prefab
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushYourTeeth_Virus2Generator : MonoBehaviour
{
    public GameObject mg_Virus2_Prefab;

    float mf_span = 4.0f; // Modify this part to change the generation interval of Virus 2 (in seconds)

    float mf_delta = 0;
    int mn_virus2_cnt = 1;

    float[,] ma2f_Virus2Position = new float[5, 2];

    void Start()
    {
        while (true) // Loop for setting virus generation positions
        {
            for (int n_i = 0; n_i < 5; n_i++) // Store the positions where viruses will be generated in the ma2f_Virus2Position array
            {
                int n_Virus2PositionX = Random.Range(-4, 4);
                float n_Virus2PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus2Position[n_i, 0] = n_Virus2PositionX;
                ma2f_Virus2Position[n_i, 1] = n_Virus2PositionY;
            }
            for (int n_i = 0; n_i < 4; n_i++) // Loop to ensure viruses are not generated at the same location
            {
                for (int n_j = 1; n_j < 5; n_j++)
                {
                    if (n_i == n_j)
                    {
                        n_j++;
                    }
                    if (Mathf.Abs(ma2f_Virus2Position[n_i, 0]) == Mathf.Abs(ma2f_Virus2Position[n_j, 0]) && (Mathf.Abs(ma2f_Virus2Position[n_i, 1]) - Mathf.Abs(ma2f_Virus2Position[n_j, 1]) < 0.8) && (Mathf.Abs(ma2f_Virus2Position[n_i, 1]) - Mathf.Abs(ma2f_Virus2Position[n_j, 1]) > -0.8))
                    {
                        int n_Virus2PositionX = Random.Range(-4, 4);
                        float n_Virus2PositionY = Random.Range(-0.6f, -3.3f);

                        ma2f_Virus2Position[n_j, 0] = n_Virus2PositionX;
                        ma2f_Virus2Position[n_j, 1] = n_Virus2PositionY;
                        n_i = 0;
                        continue;
                    }
                }
            }
            break;
        }
        GameObject g_GenerateVirus2 = Instantiate(mg_Virus2_Prefab) as GameObject; // Generate the first Virus 2
        g_GenerateVirus2.transform.position = new Vector3(ma2f_Virus2Position[0, 0], ma2f_Virus2Position[0, 1], 0);
        Debug.Log("Position of generated Virus 2 1st: " + ma2f_Virus2Position[0, 0] + " " + ma2f_Virus2Position[0, 1]);
    }

    void Update()
    {
        this.mf_delta += Time.deltaTime;

        if (this.mf_delta > this.mf_span && mn_virus2_cnt < 5) // Modify the number of Virus 2 to be created here (5)
        {
            this.mf_delta = 0;
            GameObject g_GenerateVirus2 = Instantiate(mg_Virus2_Prefab) as GameObject;
            g_GenerateVirus2.transform.position = new Vector3(ma2f_Virus2Position[mn_virus2_cnt, 0], ma2f_Virus2Position[mn_virus2_cnt, 1], 0);
            Debug.Log("Virus 2 " + (mn_virus2_cnt + 1) + "th position: " + ma2f_Virus2Position[mn_virus2_cnt, 0] + " " + ma2f_Virus2Position[mn_virus2_cnt, 1]); // Generate Virus 2 from 2 onwards
            mn_virus2_cnt++;
        }

    }
}
