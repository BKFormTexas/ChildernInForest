/*
  * - Name: Drag.cs
  * - Content: Drag script
  * 
  * - HISTORY
  * 2021-07-06: Initial development
  * 2021-07-19: Code modification
  * 2021-07-21: Commenting
  * 2021-07-22: Commenting modification
  * 2021-07-29: Adapted for UI drag instead of object drag
  *
  * <Variables>
  * auSource: Sound played when clicking the mouse
  * uiCamera: Main camera object
  * mb_ClassifyPuzzle: Boolean variable to prevent dragging of puzzles on the answer board
  *
  * <Functions>
  *
  * 2021-07-29: OnDrag(): Event function for UI objects. Since our UI canvas is aligned with the main camera, we need to use ScreenToWorldPoint() function of the main camera object to convert Input.mousePosition.
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
  AudioSource auSource;
  Camera uiCamera;
  bool mb_ClassifyPuzzle;
  SoundManager soundManager;

  // Initialization
  void Start() {
    mb_ClassifyPuzzle = gameObject.GetComponent<Puzzle_Matching_Puzzle>().mb_classifyWhetherAns;
    auSource = GetComponent<AudioSource>();
    soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    uiCamera = Camera.main;
  } 
 
  public void OnDrag(PointerEventData eventData) {
    if (!mb_ClassifyPuzzle) {
      var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100.0f); // You should set the z-value to Plane Distance!!
      transform.position = uiCamera.ScreenToWorldPoint(screenPoint); // Once you perform coordinate transformation, you're done!
    }
  }

  public void OnBeginDrag(PointerEventData eventData) {
      soundManager.playSound(0);
  }

  public void OnEndDrag(PointerEventData eventData) {
      soundManager.playSound(1);
  }
}
