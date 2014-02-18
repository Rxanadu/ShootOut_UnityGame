using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    Camera mapCamera;
    bool gamePaused;

	// Use this for initialization
	void Start () {
        mapCamera = GetComponent<Camera>();
        gamePaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(2)) {
            gamePaused = !gamePaused;
        }

        //pause game
        if (gamePaused) {
            mapCamera.depth = Camera.main.depth + 1;
        }
        if (!gamePaused) {
            mapCamera.depth = Camera.main.depth - 1;
        }
	}
}
