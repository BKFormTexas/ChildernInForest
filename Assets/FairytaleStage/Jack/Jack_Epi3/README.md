# Jack and the Beanstalk - Episode 3
***
  - Language: C#
***
  -Update Log
      - 21.07.13: Code writing completed
      - 21.07.16: Add direction with arrows during events, connect scenes
      - 21.07.19: Resolution change and script size modification
      - 21.07.26: Added sound effect
      - 21.07.28: Script optimization and modularization of some functions
***
  - Running screen and contents

![Jack and the Beanstalk episode 3](https://user-images.githubusercontent.com/37494407/126118568-05882a3c-5841-4e20-9f0b-4c33d248caa7.png)


     - This is the first screen of Episode 3.
     - Touch the screen to continue the story.
    
![Jack and the Beanstalk episode 3 event 1](https://user-images.githubusercontent.com/37494407/126121823-e65947b9-6944-4ca1-a09d-18888a2e80ce.png)

     - Event screen
     - Arrows indicate what to drag.
    
  ![Jack and the Beanstalk episode 3 event 2](https://user-images.githubusercontent.com/37494407/126121935-bcfb0c8b-bf70-4b31-b10e-069c00c66072.png)

     - When dragging an object, the existing arrow disappears and indicates to whom the object should be dragged.
    
    
    

***


- Jack (Episode 3) composition information
   -Image
     - Save images used in the scene
   -Scripts
     - Jack3_Bean.cs: Script for bean object, set to return to original position when dragging is released
     - Jack3_Cow.cs: Script for cow objects, set to return to original position when dragging is released
     - Jack3_EventController.cs: Main script, script that sets and processes events
     - Jack3_GrandFather.cs: Script for the grandfather object, script responsible for handling collisions on the grandfather object, etc.
     - Jack3_Jack.cs: Script for Jack, script responsible for handling collisions on Jack objects, etc.
   - Jack_Epi3.unity: Scene file

***

  - Note

1. If you want to edit the lines

     - Write the dialogue in the ms_ScriptText variable in Jack3_ㅁㅁㅁㅁScript.cs. The separator between lines is @, so write @ at the end of the sentence.
     - You can enter and set ㅁㅁㅁㅁ according to the subject of the script.

2. How to launch a script

     - When you connect each script through an object in the main script, Jack3_EventController.cs, and run the v_NextScript() function, the next script appears.

3. How to delete a conversation

     - You can use the v_NoneScript() function.

***
