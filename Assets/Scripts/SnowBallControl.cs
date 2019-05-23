using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallControl : MonoBehaviour {

    public float ballSpeed;
    public GameObject snowBallEffect;
    public static bool ballhit;
    public AudioClip ballHitSE;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(ballSpeed * transform.localScale.x, 0);
	}
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy" || col.tag == "Floor") {
            Instantiate(snowBallEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(ballHitSE, transform.position);
            Destroy(gameObject);
        }
    }
}
