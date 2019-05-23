using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashControl : MonoBehaviour {

    public float slashSpeed;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        rb.velocity = new Vector3(slashSpeed * transform.localScale.x, 0);
    }
}
