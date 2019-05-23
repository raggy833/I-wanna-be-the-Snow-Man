using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float counter = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter -= Time.deltaTime;
        if(counter < 0) {
            Destroy(gameObject);
        }
	}
}
