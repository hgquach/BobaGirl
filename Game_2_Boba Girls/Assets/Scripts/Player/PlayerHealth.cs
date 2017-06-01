using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerLives = 3 ;
    private bool isDead = false;
    public bool canHurt = true;
    public float timer;
    public float invincibleTimer = 3f;
    public GameObject gameState;
    private GameState gamestate;
	// Use this for initialization
	void Start () {
        gamestate= gameState.GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (playerLives <= 0)
        {
            isDead = true;
            gamestate.isGameOver = true;

        }

        if (timer > invincibleTimer)
            canHurt = true;
    }

    public void takeLive()
    {
        if(!isDead && playerLives >0 && canHurt)
        {
            playerLives -= 1;
            canHurt = false;
            timer = 0f;
            print(playerLives);
        }

    }
}
