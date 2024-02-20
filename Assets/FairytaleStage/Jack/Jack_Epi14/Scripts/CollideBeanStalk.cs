/*
   * - Name: CollideBeanStalk.cs
   * - Content: Jack and the Beanstalk Episode 14 - Cutting down the beanstalk with an axe script
   *
   * - HISTORY
   * 2021-07-15: Initial development
   * 2021-07-16: Fixed file encoding and commented out
   * 2021-07-26: Sound effect added completed
   * 2021-07-27: Fix comment processing
   *
   * <Variable>
   * mg_Click: Mission-guided click
   * mg_Giant: Giant
   * mn_checkAxing: Number of ax strikes
   * mb_checkEnd: Check whether Epi14 content is finished
   * GiantSound: The sound made by a giant falling
   * AxSound: The sound of an ax cutting
   * sc: Object to represent fairy tale script
   * vm: Object connection that handles voice TTS
   *
   * <Function>
   * How to access a child object: transform.GetChild(index) -> The index starts from 0 at the top.
   * OnTriggerEnter2D(Collider2D cCollideObject): A function that is called only once for the first time when a collision occurs between objects.
   * gotoEpi15Scene(): Function to move to Epi15 scene
   * PlayGiant(): Function to play giant scream sound
   */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Chopping beanstalk class with an axe
public class CollideBeanStalk : MonoBehaviour{
     private GameObject mg_Click;
     private GameObject mg_Giant;
     private int mn_checkAxing = 0;
     private bool mb_checkEnd = false;
     private AudioSource GiantSound;
     private AudioSource AxSound;
    
     private ScriptControl sc;
     VoiceManager vm;

     //Initial settings
     void Start(){
         mg_Click = GameObject.Find("Click (1)"); //Click (1) Find the game object and save it in the mg_Click variable
         GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject; // Get the child object from the parent object's script and store it in the g_initBean object.
         g_initBean.SetActive(true); //Activate g_initBean object

         GiantSound = GameObject.Find("GiantSound").GetComponent<AudioSource>();
         AxSound = GameObject.Find("AxSound").GetComponent<AudioSource>();

         sc = ScriptControl.GetInstance(); // Receive and use Instance return
         this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
     }

     void Update(){
         float temp = 0f;
         if(mn_checkAxing > 8) {
             //giant fall.. to y: -1
             if (!mb_checkEnd){ //If Epi14 content is in progress
                 Destroy(mg_Click); //Remove mg_Click object
                 mg_Giant.transform.position = Vector2.MoveTowards(mg_Giant.transform.position, new Vector2(2f, 0.3f), 2f * Time.deltaTime);
                 temp = Mathf.Abs(mg_Giant.transform.position.y - 0.3f);
                 PlayGiant(); //Play giant shout
                 if( temp <= 0.1f && !mb_checkEnd) {
                 Destroy(mg_Giant); //Remove mg_Giant object
                     Invoke("gotoEpi15Scene", 3.5f); //Perform gotoEpi15Scene function after 1 second
                     mb_checkEnd = true; //End of Epi14 content
                 }
             }
         }
         else if(mn_checkAxing == 8) { //If the beanstalk is cut down
             mg_Giant = transform.Find("giant").gameObject; //Find mg_Giant object
             mg_Giant.SetActive(true); //Activate mg_Giant object
             sc.setNextScript(); //Load the second script
             vm.playVoice(2); //Play 2nd script voice
             mn_checkAxing++; //Add number of ax strikes
         }
     }

     //Function that changes the appearance of the beanstalk while cutting with an ax
     void OnTriggerExit2D(Collider2D cCheckCollidedObject) {
         if(mn_checkAxing < 8) {
             GameObject g_axedBean = transform.GetChild(mn_checkAxing).gameObject; // Get the child object from the parent object's script and store it in the g_axedBean object.
             g_axedBean.SetActive(false); //Disable g_axedBean object
             mn_checkAxing++; //Add number of ax strikes
             AxSound.Play(); //Play ax sound effect
             GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject; //Get the child object from the parent object's script and store it in the g_initBean object.
             g_initBean.SetActive(true); //Activate g_initBean object
         }
     }

     //Function to move to Epi15 scene
     void gotoEpi15Scene() {
         SceneManager.LoadScene("Jack_Epi15"); //Load Jack_Epi15 scene
     }

     //Function to play giant scream sound
     void PlayGiant(){
         GiantSound.Play();
     }
}
