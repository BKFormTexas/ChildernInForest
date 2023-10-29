/*
  * - Name : Shape_Matching_Shape.cs
  * - Content : Shape matching script
  * 
  * - HISTORY
  * 2021-07-06 : Initial development
  * 2021-07-19 : Code modification
  * 2021-07-21 : Commenting
  * 2021-07-22 : Commenting modification
  *
  * <Variables>
  * mb_classifyWhetherAns : Variable to store the state before shape matching
  * sNextSprite : Sprite to replace after shape matching
  * mv2_initPos : Variable to store the position to return to after a failed shape match
  * 
  * <Functions>
  * Input.GetMouseButtonUp() : Returns true when the user releases the given mouse button. Button 0 is for left-click, 1 is for right-click, and 2 is for middle-click.
  * OnTriggerEnter2D(Collider2D cCollideObject) : A function called when Unity's collider component is provided. It is used to specify what actions to take when colliders collide.
  */
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape_Matching_Shape : MonoBehaviour {
    Vector2 mv2_initPos;
    public bool mb_classifyWhetherAns = false;
    public Sprite sNextSprite; 

    // Initialization
    void Start() {
        mv2_initPos = this.transform.position; // Store the initial position (for returning the shape to its original position if it fails to match)
    }

    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_initPos, 10f * Time.deltaTime); // Return the shape to its initial position if it fails to match.
    }

    void OnTriggerStay2D(Collider2D cCollideObject) {
        if (Input.GetMouseButtonUp(0)) { // Attempt to match the shape (after dragging and checking for a match)
            if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]) { // If it's the correct answer
                if (mb_classifyWhetherAns) {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sNextSprite; // Replace the shape with the correct one
                } else {
                    Destroy(this.gameObject); // Destroy the shape if it's the correct answer
                }
            }
        }
    }
}
