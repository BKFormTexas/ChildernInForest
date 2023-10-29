# Jack and the Beanstalk - Episode 9
***
  - Production language: C#
***
  -Update Log
      - 21.07.15: Code writing completed
      - 21.07.16: Add direction with arrows during events, connect scenes
      - 21.07.19: Resolution change and script size modification
      - 21.07.26: Added sound effect

***
  - Running screen and contents

![Jack and the Beanstalk 9](https://user-images.githubusercontent.com/37494407/126127261-baad404f-935f-4ebd-9fb0-9407cc9741c5.png)

     - This is the first screen of Episode 9.
     - Touch the screen to continue the story.

***


- Jack (Episode 9) composition information
   -Image
     - Save images used in the scene
   -Scripts
     - Jack9_Blink.cs: Script that creates a twinkling effect, applied to arrows
     - Jack9_EventController.cs: Main script, script that sets and processes events
     - Jack9_Gentreasure.cs: Script that generates treasures
     - Jack9_GiantScript.cs: Giant dialogue script, set the script and enable the next script to operate through the function.
     - Jack9_MainScript.cs: Main dialogue script, set the script and enable the next script to operate through the function.
     - Jack9_MissionScript.cs: Event script, set the script and enable the next script to operate through the function.
     - Jack9_Sack.cs: A script for the sack object and a script that sets sack-related events.
   - Jack_Epi9.unity: Scene file

***

  - Note

1. If you want to edit the lines

     - Write the dialogue in the ms_ScriptText variable in Jack9_ㅁㅁㅁㅁScript.cs. The separator between lines is @, so write @ at the end of the sentence.
     - You can enter and set ㅁㅁㅁㅁ according to the subject of the script.

2. How to launch a script

     - When you connect each script through an object in the main script, Jack9_EventController.cs, and run the v_NextScript() function, the next script appears.

3. How to clear script

     - You can use the v_NoneScript() function.

***
