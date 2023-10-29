# Add fruit
***
  - Language: C#
***
  -Update Log
      - 21.07.06: Code writing completed
      - 21.07.08: Ending scene connection
      - 21.07.16: Modified encoding format to UTF8
      - 21.07.19: Text size modified according to resolution change
      - 21.07.20: When clicking on each fruit, the corresponding fruit's voice is output.
      - 21.07.26: Sound effect output when clicking on each fruit.
***
  - Running screen and contents

<img src = "https://user-images.githubusercontent.com/69896751/126114122-93dd17d5-abb3-4f2f-aa98-6c48316fa167.png" width="500" height="220">


     - Place the fruit in the basket by dragging the fruit set in the scene to the basket.
     - If there are no fruits left, the game ends.
    

***


- FruitPutIn configuration information
   -Image
     - Save images used in the scene
   -Scripts
     - ControlFruit.cs: Interaction script for fruit created in the scene.
     - InitializeStage: Script that creates fruit in the scene.
   -Prefab
     - Fruit.prefab: A file that generalizes the settings of fruit objects.
     - target_basket.prefab: A file that generalizes the settings of the basket object that will contain fruit.
   - fruit_putin.unity: scene file

***

  - Note

    - ※Caution: If you increase the type of fruit, you must apply the sprite image file of the fruit in the inspector window of the object with InitializeStage as a component, and in order to output the fruit's voice accordingly, the inspector window of the VoiceManager object existing in the scene. You need to add one more to the list.


1. To increase or decrease the number of fruits set in the scene:

     - Change the value of mn_countFruits in the inspector window of the object to which the scene's InitializeStage class is applied.

***
