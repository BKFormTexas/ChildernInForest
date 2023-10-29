# Jigsaw puzzle
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

<img src = "https://user-images.githubusercontent.com/73592778/127113392-60f25e99-1183-45b8-a141-358cbbc12c3e.png" width="500" height="220">




     - Complete the puzzle set in the scene by dragging it to the appropriate location.
     - If there are no puzzles left, the game ends with a voice saying ‘Good job!’ and a success page appearing.
    

***


- Puzzle configuration information
   -Sprites
     - Save images and sound effects used in the scene
   -Scripts
     - Drag.cs: Object drag script
     - Puzzle_CheckPuzzle.cs: A script that checks whether all puzzles have been answered and loads the end scene.
     - Puzzle_Matching_Puzzle.cs: Script to match a puzzle
   -Scenes
     - solve_puzzle_scene.unity: Scene file

***

-------------
