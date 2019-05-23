using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool doorToBoss;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            if(GameManager.currentRoomNum == 1) {
                gameManager.EnterNextRoom();
                Debug.Log("Enter 2nd room");
            }
            if(doorToBoss) {
                gameManager.EnterBossRoom();
                Debug.Log("Enter boss room");
            }
        }    
    }
}
