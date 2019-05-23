using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject gameOverPanel;
    public GameObject Boss;
    public Vector3 respawnPoint;
    public Transform oriRoomSpawnPos;
    public Transform room1Middle;
    public Transform room2Middle;
    public Camera mainCamera;
    public Transform bossRoomMid;
    public Transform oriBossRoomSpawnPos;
    public Transform room2EnterPos;
    public bool bossFightStarted = false;
    public BossControl bossControl;
    public BossHealth bossHealth;
    public Text roomNumber;
    public Text levelName;

    public static int currentRoomNum;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        //bossControl = GameObject.FindObjectOfType<BossControl>();
        roomNumber = GetComponent<Text>();
        offset = new Vector3(0, 0, -8);
        Player.transform.position = oriRoomSpawnPos.position;
        respawnPoint = oriRoomSpawnPos.position;
        mainCamera.transform.position = room1Middle.position + offset;
        PlayerControl.newSpawnPos = oriRoomSpawnPos.position;
        currentRoomNum = 1;
    }

    public void EnterNextRoom() {
        mainCamera.transform.position = room2Middle.position + offset;
        Player.transform.position = room2EnterPos.position;
    }

    public void EnterBossRoom() {
        bossFightStarted = true;
        mainCamera.transform.position = bossRoomMid.position + offset;
        Player.transform.position = oriBossRoomSpawnPos.position;
        Boss.SetActive(true);

    }

    void Update() {
        if (PlayerControl.isDead) {
            Player.SetActive(false);
            gameOverPanel.SetActive(true);
            if (Input.GetKey(KeyCode.R)) {
                ReSpawn();
            }
        }
    }

    void ReSpawn() {
        if (bossFightStarted) {
            bossControl.GetComponent<BossControl>().ReSpawnBoss();
            bossHealth.GetComponent<BossHealth>().ResetBossHealth();
            Boss.SetActive(false);
            bossFightStarted = false;
        }
        mainCamera.transform.position = room1Middle.position + offset;
        gameOverPanel.SetActive(false);
        Player.transform.position = PlayerControl.newSpawnPos;
        Player.SetActive(true);
        PlayerControl.isDead = false;
    }
}
