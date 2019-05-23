using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPos : MonoBehaviour {

    public GameObject ball;
    public float spawnTime = 15f;
    public Transform[] spawnPoints;

    void Start() {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Vector3 itemLocation = new Vector3(10, 1);
        Gizmos.DrawWireCube(transform.position, itemLocation);
    }

    void Spawn() {
        Vector3 itemPosition = new Vector3(Random.Range(-7, 7), 8);
        Instantiate(ball, itemPosition, Quaternion.identity);
    }
}