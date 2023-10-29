# Match shapes
***
  - Language: C#
***
  -Update Log
      - 21.07.06: Initial development of code
      - 21.07.08: Ending scene connection and annotation processing
      - 21.07.16: Modified encoding format to UTF8
      - 21.07.19: Text size modified according to resolution change
      - 21.07.23: Added sound effect
      - 21.07.26: BGM added
      - 21.07.27: Fix comment processing
***
  - Running screen and contents

<img src = "https://user-images.githubusercontent.com/73592778/127114807-aec649e1-2afe-4eea-9d35-43291f5f937d.png" width="500" height="220">





     - Complete the empty part by dragging the shape set in the scene to the appropriate location.
     - If there are no shapes left, the game ends with a voice saying ‘Good job!’ and a success page appearing.
    

***


- Shape composition information
   -Sprites
     - Save images and sound effects used in the scene
   -Scripts
     - Drag.cs: Object drag script
     - Shape_CheckShape.cs: A script that checks if all the shapes are aligned and loads the end scene.
     - Shape_Matching_Shape.cs: Script for matching shapes
   -Scenes
     - match_shape_scene.unity: Scene file

***

-------------
