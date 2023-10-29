/*
 * - Name: ControlFruit.cs
 * - Content: The ControlFruit class is used to control the Fruit prefab. When users drag the Fruit, it follows their movement, and it contains an ID for TTS voice output.
 * - Where the code is applied: /Assets/fruit_putin/Prefab/Fruit
 * - History -
 * 2021-07-19: Production completed
 * 2021-07-20: Commented
 * 2021-07-23: Added SoundManager.
 * 2021-07-27: Updated comments based on feedback.
 * 2021-07-28: Exception handling added for cases where mvm_voiceManager is null upon immediate destruction.
 *
 * - ControlFruit Member Variables 
 *
 * mvm_voiceManager: This class allows TTS voice output corresponding to the Fruit prefab.
 * mn_fruitId: An ID variable representing the type of Fruit prefab.
 * mv2_remembPos: Stores the initial position of the Fruit prefab.
 * mb_checkClickOnce: Determines whether the Fruit prefab is being dragged.
 * msm_soundManager: Manages sound effects.
 * 
 * - ControlFruit Member Functions
 *
 * Start(): Executed when the Fruit game object is created, initializes the VoiceManager instance.
 * Update(): Continuously moves the object back to its initial position when it's created in the scene. This is done to create the illusion that the fruit character is forcibly caught by the player.
 * OnMouseDrag(): Called when the player drags the fruit. It outputs the name of the fruit as voice.
 * OnMouseUp(): Executed when the player releases the drag, it sets mb_checkClickOnce to true to ensure the voice is output only once.
 * OnTriggerEnter2D(Collider2D cCollideObject): Called when Unity's collider component is given. It is invoked when collisions occur and defines what actions to take when that happens. In this case, it makes the Fruit prefab disappear upon collision, and outputs English voice corresponding to the type of fruit.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script class that controls the state and actions of the Fruit prefab.
public class ControlFruit : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    private SoundManager msm_soundManager;
    public int mn_fruitId;
    private Vector2 mv2_remembPos;
    private bool mb_checkClickOnce = false;

    // Initialize the VoiceManager class and store the initial position (for going back).
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        mv2_remembPos = gameObject.transform.position;
    }
    
    // Move back to the initialized position. This is to gradually return to the initial position, as if the fruit character is being caught by the player.
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_remembPos, 2f * Time.deltaTime);
    }

    // Called when dragging, outputs the name of the fruit as voice. Includes a flag to prevent repeated voice output during dragging.
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            mvm_voiceManager.playVoice(mn_fruitId); // Output Korean voice
            msm_soundManager.playSound(0);
            mb_checkClickOnce = true;
        }
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }

    // When called during dragging, it is repeatedly called, leading to continuous voice output. This exception handling is added to prevent that.
    void OnMouseUp() {
        msm_soundManager.playSound(1);
        msm_soundManager.playSound(2);
        mb_checkClickOnce = false;
    }

    // The PutFruits_initializeStage class assigns the type of fruit for all these Fruit prefabs by using this function to set the mn_fruitId member variable.
    public void setFruitId(int nId) {
        mn_fruitId = nId;
    }

    // Called when Fruit and Basket collide, this function handles actions to take upon collision, such as making the Fruit disappear and playing the corresponding English voice.
    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if (cCollideObject.tag == "PutFruitInBasket") {
            if(mvm_voiceManager != null)
                mvm_voiceManager.playVoice(mn_fruitId+1); // English
            Destroy(this.gameObject);
        }
    }
}
