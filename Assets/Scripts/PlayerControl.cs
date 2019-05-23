using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public GameObject snowBall;
    public Transform throwPoint;
    public AudioSource throwSound;
    public static bool isDead = false;
    public static Vector3 newSpawnPos;
    public int oriExtraJump = 1;

    public int extraJump;
    private Rigidbody2D rb;
    private Animator anim;
    private bool cooldown = false;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (!isDead) {
            PlayerMovement();
        }
    }

    void PlayerMovement() {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (isGrounded) {
            extraJump = oriExtraJump;
        }
        if (Input.GetKeyDown(jump) && extraJump > 0) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            extraJump--;
        }
        if (Input.GetKey(left)) {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

        } else if (Input.GetKey(right)) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(throwBall) && cooldown == false) {
            GameObject ballClone = Instantiate(snowBall, throwPoint.position, throwPoint.rotation) as GameObject;
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
            throwSound.Play();
            Invoke("ResetCooldown", 0.25f);
            cooldown = true;
        }
        if (rb.velocity.x < 0) {
            transform.localScale = new Vector3(-4, 4, 1);
        } else if (rb.velocity.x > 0) {
            transform.localScale = new Vector3(4, 4, 1);
        }
        anim.SetFloat("walkSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("jumping", !isGrounded);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy") {
            Dead();
            Debug.Log("His enemy");
        }
        if(col.tag == "CheckPoint") {
            newSpawnPos = col.transform.position;
        }
    }
    void Dead() {
        isDead = true;
    }
    void ResetCooldown() {
        cooldown = false;
    }
}
