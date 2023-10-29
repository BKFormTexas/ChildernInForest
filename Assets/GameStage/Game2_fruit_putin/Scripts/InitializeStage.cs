/*
 * - Name: InitializeStage.cs
 * - Content: The InitializeStage class is responsible for generating a predefined number of Fruit prefabs in random positions and keeping track of the count. It also handles transitioning to the end scene when the player successfully puts all fruits in the basket.
 * - Where the code is applied: /Assets/fruit_putin/Scenes/put_fruits_scene -> StageControl
 * - History -
 * 2021-07-19: Production completed
 * 2021-07-20: Commented
 * 2021-07-27: Updated comments based on feedback.
 *
 * - InitializeStage Member Variables 
 *
 * mg_instanceFruit: This allows controlling the VoiceManager to play the appropriate voice for Fruit prefabs.
 * mn_countFruits: An ID variable representing the type of Fruit prefabs.
 * msa_changeSpritesImg: Stores the initial positions of Fruit prefabs.
 * mb_stopUpdating: A variable to determine if Fruit prefabs are being dragged.
 * mt_putFruitSize: A variable representing the number of fruits not yet placed in the basket in the current scene.
 * mlg_fruitList: A list object that holds information about objects of fruits created in the scene.
 * 
 * - InitializeStage Member Functions
 *
 * Start(): When this empty game object is created, it generates Fruit prefabs at random positions a specified number of times (mn_countFruits).
 * Update(): Continuously counts the number of created Fruit prefabs and displays it on the UI.
 * v_changeEndingScene(): If the player has put all fruits in the basket, the game ends, and it transitions to a prepared end_scene.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This class generates fruits and randomly positions them for the PutFruits stage, counts the number of fruits, and updates the UI.
public class InitializeStage : MonoBehaviour {
    public GameObject mg_instanceFruit;
    public int mn_countFruits = 10;
    public Sprite[] msa_changeSpritesImg = new Sprite[5];
    private bool mb_stopUpdating = true;
    private TextMesh mtm_putFruitSize;
    private List<GameObject> mlg_fruitList = new List<GameObject>();

    // When the fruitPutIn stage starts, randomly initialize the positions of fruits.
    void Start() {
        mtm_putFruitSize = GameObject.Find("PutFruitsSize").GetComponent<TextMesh>() as TextMesh;
        mtm_putFruitSize.text = mn_countFruits.ToString();

        for (int i = 0; i < mn_countFruits; i++) {
            GameObject fruit = Instantiate(mg_instanceFruit);
            fruit.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            int tempNum = Random.Range(0, 5);
            fruit.GetComponent<SpriteRenderer>().sprite = msa_changeSpritesImg[tempNum];
            ControlFruit temp = fruit.GetComponent(typeof(ControlFruit)) as ControlFruit;
            temp.setFruitId(tempNum * 2);
            mlg_fruitList.Add(fruit);
        }
    }

    // Check the size of fruits and update the number displayed on the text object to mn_countFruits.
    void Update() {
        int n_countFruits = 10;

        for (int i = 0; i < mn_countFruits; i++) {
            if (mlg_fruitList[i] == null) {
                n_countFruits--;
            }
        }

        mtm_putFruitSize.text = n_countFruits.ToString();

        if (n_countFruits == 0 && mb_stopUpdating) {
            mb_stopUpdating = false;
            // When 2 seconds have passed, call the v_changeEndingScene function.
            Invoke("v_changeEndingScene", 2f);
        }
    }
    
    // When the scene is completed, change this scene to the ending scene.
    void v_changeEndingScene() {
        SceneManager.LoadScene("end_scene");
    }
}
