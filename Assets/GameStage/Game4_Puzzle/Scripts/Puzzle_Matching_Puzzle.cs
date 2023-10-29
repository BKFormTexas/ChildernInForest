/*
 * - Name: Puzzle_Matching_Puzzle.cs
 * - Content: Script for matching puzzles
 * 
 * - HISTORY
 * 2021-07-06: Initial development
 * 2021-07-19: Code modification
 * 2021-07-21: Commenting
 * 2021-07-22: Commenting updated
 * 2021-07-29: Null exception handling, logic modification
 *
 * <Variables>
 * mb_classifyWhetherAns: Variable to store the state of the puzzle before matching
 * sNextSprite: Sprite to replace the puzzle after matching
 * mv2_initPos: Variable to store the initial position in case of puzzle matching failure
 * mgo_CheckPuzzle: Variable needed to modify the variables in the script class stored in the CheckPuzzle object
 *
 * <Functions>
 * Input.GetMouseButtonUp(): Returns true when the user releases the mouse button specified. Button 0 is left-click, 1 is right-click, 2 is middle-click.
 * OnTriggerEnter2D(Collider2D cCollideObject): A function called when colliders collide in Unity, specifying what actions to take when they collide.
 * OnBeginDrag(): A function called when dragging the object starts, saving the initial position.
 * OnEndDrag(): A function called when dragging the object ends, returning it to its original position.
 * Author: Lee Yoonkyo
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle_Matching_Puzzle : MonoBehaviour, IBeginDragHandler, IEndDragHandler {
    public bool mb_classifyWhetherAns = false;
    public Sprite sNextSprite;
    public int mn_PuzzleId;
    public Vector2 mv2_initPos;
    Puzzle_CheckPuzzle mgo_CheckPuzzle;

    private void Start() {
        mgo_CheckPuzzle = GameObject.Find("CheckPuzzle").GetComponent<Puzzle_CheckPuzzle>();
    }

    void OnTriggerStay2D(Collider2D cCollideObject) {
        if (Input.GetMouseButtonUp(0)) {
            if (cCollideObject.GetComponent<Puzzle_Matching_Puzzle>() != null) {
                if (cCollideObject.GetComponent<Puzzle_Matching_Puzzle>().mn_PuzzleId == this.mn_PuzzleId) { // If it's the correct match
                    if (mb_classifyWhetherAns) { // If it's an answer puzzle
                        Color tempColor = gameObject.GetComponent<Image>().color; // Change the puzzle piece from blurred to sharp
                        tempColor.a = 1f;
                        gameObject.GetComponent<Image>().color = tempColor;
                        GameObject.Find("CheckPuzzle").GetComponent<Puzzle_CheckPuzzle>().setAnswerPuzzle();
                        gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    } else {
                        Color tempColor = gameObject.GetComponent<Image>().color; // Change the puzzle piece from blurred to sharp
                        tempColor.a = 0f;
                        gameObject.GetComponent<Image>().color = tempColor;
                        gameObject.GetComponent<Drag>().enabled = false;
                        gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
            } // When the mouse button is released
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        mv2_initPos = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.position = mv2_initPos;
    }
}
