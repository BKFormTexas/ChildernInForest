/*
 * - Name: InitializePuzzle.cs
 * - Content: This is a class for Text-to-Speech, utilizing the Singleton pattern. Since it's a somewhat heavy class, the Singleton pattern is used to allow reuse of a single instance in other object classes.
 * - History -
 * 2021-07-28: First implementation.
 * 2021-07-29: Commenting.
 *
 * - InitializePuzzle Member Variables
 *
 * mf_originWidth, mf_originHeight: Represent the width and height of the puzzle window, where the puzzles exist.
 * mrt_parentSize: Represents the puzzle window size as a RectTransform.
 * mgo_SetPuzzle: Stores the puzzle prefab.
 * mglg_AnsGridSize: Adjusts the size of puzzles in a grid since puzzles exist in a grid inside the window.
 * mglg_ProbGridSize: A component that allows puzzles to exist in a grid format.
 * mspl_slicedPuzzle: Since the SpriteSlice.sliceSprite() function returns a Sprite[], this variable stores the result.
 * mtex2_slicePuzzle: Stores the image to be sliced, which is set in the Inspector window.
 * myArray: An array for randomizing the order of puzzles.
 *
 * - InitializePuzzle Member Functions
 *
 * Awake(): Adjusts grid cell sizes and generates puzzle pieces within the puzzle window based on the window size when the scene starts.
 * setChild(): Generates puzzle game objects inside the puzzle window. It ensures they become child objects of the puzzle window.
 * Author: Choi Daejun
 */
 
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
/// <summary>
/// This class is responsible for initializing the puzzle stage. Puzzle pieces are created in the scene.
/// </summary>
public class InitializePuzzle : MonoBehaviour {
    private float mf_originWidth, mf_originHeight;
    private RectTransform mrt_parentSize;
    public GameObject mgo_SetPuzzle;
    private GridLayoutGroup mglg_AnsGridSize;
    private GridLayoutGroup mglg_ProbGridSize;
    private Sprite[] mspl_slicedPuzzle;
    public Texture2D mtex2_slicePuzzle;
    private int[] myArray;
     /// <summary>
     /// Adjusts the grid cell size according to the window size and creates puzzle pieces according to the grid.
     /// </summary>
    void Awake() {
        int col = 0;
        int row = 0;
        mrt_parentSize = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        mglg_AnsGridSize = transform.GetChild(1).gameObject.GetComponent<GridLayoutGroup>();
        mglg_ProbGridSize = transform.GetChild(2).gameObject.GetComponent<GridLayoutGroup>();

        mf_originWidth = mrt_parentSize.rect.width;
        mf_originHeight = mrt_parentSize.rect.height;

        int nSelectPuzzleRanNum = Random.Range(0,3);
        switch(nSelectPuzzleRanNum) {
            case 0:
                col = 2;
                row = 2;
                break;
            case 1:
                col = 2;
                row = 3;
                break;
            case 2:
                col = 3;
                row = 3;
                break;
        }

        GameObject.Find("CheckPuzzle").GetComponent<Puzzle_CheckPuzzle>().mn_AnswerPuzzle = col * row;

        mspl_slicedPuzzle = SpriteSlice.sliceSprite(col, row, mtex2_slicePuzzle);
        myArray = Enumerable.Range(0, col * row).ToArray();
        Shuffle.ShuffleArray<int>(myArray);

        mglg_AnsGridSize.cellSize = new Vector2((mf_originWidth - 100) / col, (mf_originHeight - 100) / row);
        mglg_ProbGridSize.cellSize = new Vector2((mf_originWidth - 100) / col, (mf_originHeight - 100) / row);
    
        mglg_AnsGridSize.constraintCount = col;
        mglg_ProbGridSize.constraintCount = col;
        setChild(col * row, transform.GetChild(1), true);
        setChild(col * row, transform.GetChild(2), false);
    }

   /// <summary>
     /// This is a function that creates a puzzle piece as a child object of the puzzle window object.
     /// </summary>
     /// <param name="nChild">Just specify how many child objects will be created under the tParent object.</param>
     /// <param name="tParent">Just specify the parent object in which to create the child object.</param>
     /// <param name="bClassifyType">Change object settings depending on whether it is a correct answer puzzle or a player-controlled puzzle.</param>   void setChild(int nChild, Transform tParent, bool bClassifyType) {
        Sprite[] tempSprite = new Sprite[mspl_slicedPuzzle.Length];
        Debug.Log(tempSprite[0]);
        for (int i = 0; i < nChild; i++) {
            GameObject temp = GameObject.Instantiate(mgo_SetPuzzle, tParent);
            temp.GetComponent<Puzzle_Matching_Puzzle>().mn_PuzzleId = i;
            // true is AnswerPuzzle
            if (bClassifyType) {
                temp.GetComponent<Image>().sprite = mspl_slicedPuzzle[i];
                temp.GetComponent<Puzzle_Matching_Puzzle>().mb_classifyWhetherAns = bClassifyType;
                Color tempColor = temp.GetComponent<Image>().color;                          
                tempColor.a = 0.1f;
                temp.GetComponent<Image>().color = tempColor;
            }
            else {
                temp.GetComponent<Puzzle_Matching_Puzzle>().mn_PuzzleId = myArray[i];
                temp.GetComponent<Image>().sprite = mspl_slicedPuzzle[myArray[i]];
            }
        }
    }
}
