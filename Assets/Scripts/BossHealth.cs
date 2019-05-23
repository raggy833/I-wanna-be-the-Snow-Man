using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

    public int Health;
    public Slider currentHealth;

    private int maxHealth = 200;

	// Use this for initialization
	void Start () {
        Health = maxHealth;
        currentHealth.maxValue = maxHealth;
        currentHealth.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth.value = Health;
        if(Health <= 0) {
            BossDeath();
        }
	}

    public void ResetBossHealth() {
        Health = maxHealth;
    }

    void BossDeath() {
        Destroy(gameObject);
        Debug.Log("boss is dead");
        Debug.Log("Open door for next room");
    }

    void OnTriggerEnter2D(Collider2D col) {
         if(col.tag == "Snowball") {
            Health--;
        }
    }
}
