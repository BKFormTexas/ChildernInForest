using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_backControl : MonoBehaviour {
    public string ms_backScene = null;

        void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ra_checkMouseDistance = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D h_hitDistanceCast2D = Physics2D.GetRayIntersection(ra_checkMouseDistance, Mathf.Infinity);

            if (h_hitDistanceCast2D.collider != null && h_hitDistanceCast2D.collider.name == "backController")
            {
                int loadSceneIdx = SceneManager.GetActiveScene().buildIndex;
                loadSceneIdx--;
                SceneManager.LoadScene(loadSceneIdx);
            }
            else if (h_hitDistanceCast2D.collider != null && h_hitDistanceCast2D.collider.name == "homeController")
            {
                SceneManager.LoadScene("select_stage_scene");
                var obj = GameObject.Find("BGMmanager");
                if(obj != null) {
                    Destroy(obj);
                }
            }
        }
    }
}
