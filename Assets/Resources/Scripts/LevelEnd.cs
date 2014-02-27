using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    GameController gameController;

    void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameController.LevelComplete();
        }
    }
}
