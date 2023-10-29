# Teeth brushing game
***
  - Language: C#
***
  -Update Log
      - 21.07.06: Code writing completed
      - 21.07.08: Ending scene connection
      - 21.07.09: Reset variable name
      - 21.07.16: Modified encoding format to UTF8
      - 21.07.19: Text size modified according to resolution change
      - 21.07.20: Added voice when germs die through TTS

***
  - Running screen and contents

![Teeth brushing game](https://user-images.githubusercontent.com/37494407/126113014-5b812c1d-37aa-4323-a4a3-49449a50ebe0.png)


     - This is a game where bacteria are randomly generated at the location of the teeth, and when you touch them a certain number of times, the bacteria are eradicated.
     - The game is cleared when the remaining number of bacteria is reduced to 0.
    

***


- BrushYourTeeth Configuration Information
   -Animation
     - Virus[1,2]_Attack.anim: Animation that operates when touching a germ.
     - Virus[1,2]_Die.anim: Animation when a germ dies.
     - Virus[1,2]_Idle.anim: Normal animation
     - Virus1_Prefab.controller: Virus1 animation operation connection
     - Virus2.controller: Virus2 animation operation connection
   -Image
     - Save images used in the scene
   -Scripts
     - BrushYourTeeth_Virus[1,2].cs: Script related to germ settings
     - BrushYourTeeth_Virus[1,2]Generator.cs: Germ generation script
     - BrushYourTeeth_ControlUI.cs: Guide UI setup script
   - clean_teeth_scene.unity: Scene file

***

  - Note

    - ※Caution: If the total number of remaining bacteria is reduced, the number of each bacteria generated must be changed separately.


1. If you want to reduce the number of remaining bacteria

     - Change the value of mn_LeftVirus variable in BrushYourTeeth_ControlUI.cs

2. If you want to change how many times you touch to eradicate bacteria

     - Change the mn_Virus[1,2]_HP variable value in BrushYourTeeth_Virus[1,2].cs

3. If you want to change the bacterial production cycle

     - Change the mf_span variable value in BrushYourTeeth_Virus[1,2]Generator.cs (unit: seconds)

4. If you want to change the number of bacteria generated

     - Change the if statement number in the update statement of BrushYourTeeth_Virus[1,2]Generator.cs

***
