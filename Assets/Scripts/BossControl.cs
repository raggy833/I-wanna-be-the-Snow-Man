using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    // SerializeField means that it will expose the variable below so even if it's private, you can still edit is from the inspector
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    // static trigger for the location of the player
    public Transform oriPos;
    public float moveSpeed = 2f;
    public float startActionTimer = 10f;
    public GameObject Slash;
    public Transform[] SlashPos;
    public GameObject BigFire;
    public Transform FirePos;
    public GameObject fallFire;
    public Transform[] fallFirePos;

    private float actionTimer;
    private bool attacking;
    private int moveChoice = 1;
    private Animator anim;
    private bool isAlive = true;

    void Start() {
        gameObject.transform.position = oriPos.position;
        anim = GetComponent<Animator>();
        actionTimer = startActionTimer;
        attacking = false;
        // Will use this after learning about Coroutines
        // StartCoroutine(MoveChooser());
    }

    void Update() {
        Debug.Log(moveChoice);
        if(moveChoice > 3) {
            moveChoice = 1;
        }
        if (moveChoice == 1 && !attacking) {
            Move1();
        }
        if (moveChoice == 2 && !attacking) {
            Move2();
        }
        if (moveChoice == 3 && !attacking) {
            Move3();
        }        
    }

    /*IEnumerator MoveChooser() {
        while (isAlive) {
            yield return new WaitForSeconds(2f);
            moveChoice = Random.Range(1, 4);
            Debug.Log(moveChoice);
        }
    }
    */

    public void ReSpawnBoss() {
        gameObject.transform.position = oriPos.position;
        attacking = false;
        this.transform.localScale = new Vector3(-1,1,1);
    }

    public void SetColliderForSprite(int spriteNum) {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }

    void Move1() {
        attacking = true;
        anim.SetBool("BossKick", true);
    }
    void Move2() {
        attacking = true;
        anim.SetBool("BossSlash", true);
    }
    void Move3() {
        attacking = true;
        anim.SetBool("BossFireAttack", true);
    }

    public void SpawnFire() {
        GameObject FireClone = Instantiate(BigFire, FirePos.position, FirePos.rotation) as GameObject;
        foreach(Transform pos in fallFirePos) {
            // FirePos.rotation = Quaternion.Euler(0, 0, -90);
            GameObject FallFireClone = Instantiate(fallFire, pos.position, Quaternion.Euler(0, 0, -90)) as GameObject;
        }
    }

    public void SlashAttack() {
        Transform RamSlashPos = SlashPos[Random.Range(0, 3)];
        GameObject SlashClone = Instantiate(Slash, RamSlashPos.position, RamSlashPos.rotation) as GameObject;
    }

    public void NextMove() {
        anim.SetBool("BossKick", false);
        anim.SetBool("BossSlash", false);
        anim.SetBool("BossFireAttack", false);
        moveChoice++;
        Invoke("ChangeToIdle", 1.5f);
    }
    public void ChangeToIdle() {
        attacking = false;
    }
}