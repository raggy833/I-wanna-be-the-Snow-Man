using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public bool triggered;

    private float counter = 1f;
    private float oriCounter = 1f;

    void Awake() {
        triggered = false;
    }
    void Update() {
        if (triggered) {
            counter -= Time.deltaTime;
        }   
        if(counter <= 0) {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.white;
            counter = 0;
        }
    }
    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider) {
        // check we haven't been triggered yet!
        if (!triggered && collider.tag == "Player") {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.red;
            triggered = true;
            counter = oriCounter;
        }
    }
    void Trigger() {
        // Tell the animation controller about our 
        // recent triggering
        GetComponent<Animator>().SetTrigger("Triggered");
        triggered = true;
    }
}
