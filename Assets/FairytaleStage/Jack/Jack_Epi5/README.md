# Jack and the Beanstalk - Episode 5
***
  - Production language: C#
***
  -Update Log
      - 21.07.15: Code writing completed
      - 21.07.16: Add direction with arrows during events, connect scenes
      - 21.07.19: Resolution change and script size modification
      - 21.07.26: Added sound effect
      - 21.07.27: Script optimization and modularization of some functions

***
  - Running screen and contents

![Jack and the Beanstalk 5](https://user-images.githubusercontent.com/37494407/126125833-38b505f3-daa7-41d5-bbb1-eb477f2d5a7a.png)

     - This is the first screen of Episode 5.
     - Touch the screen to continue the story.
    
![Jack and the Beanstalk 5 Event 1](https://user-images.githubusercontent.com/37494407/126125854-8ed674fc-032c-4081-903a-6a3ac59c72cf.png)

     - Event screen
     - Arrows indicate what to drag.
    
![Jack and the Beanstalk 5 Event 2](https://user-images.githubusercontent.com/37494407/126125872-dd18864b-59c4-4a2d-8d93-9fb6dbcca20a.png)

     - When dragging an object, the existing arrow disappears and indicates to whom the object should be dragged.

***


- Jack (Episode 5) composition information
   -Image
     - Save images used in the scene
   -Scripts
     - Jack5_EndPoint.cs: Script for bean sprout end point objects, script responsible for handling collisions on objects, etc.
     - Jack5_EventController.cs: Main script, script that sets and processes events
   - Jack_Epi5.unity: Scene file

***

  - Note

1. If you want to edit the lines

     - You can edit it in the inspector window of the GameDirector object.

2. How to launch a script

     - When you connect each script through an object in the main script, Jack5_EventController.cs, and run the v_NextScript() function, the next script appears.

3. How to clear script

     - You can use the v_NoneScript() function.

***
