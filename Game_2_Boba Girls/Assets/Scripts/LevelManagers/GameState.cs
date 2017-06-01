using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    public bool isGameOver;
    public bool isWin;

    private int numOfEnemy;
    public GameObject[] rangeEnemy;
    public GameObject[] meleeEnemy;
    public GameObject playerUI;
    public GameObject loseMenu;
	// Use this for initialization
	void Start () {
        isGameOver = false;
        isWin = false;

        rangeEnemy = GameObject.FindGameObjectsWithTag("Range");
        meleeEnemy = GameObject.FindGameObjectsWithTag("Melee");

        playerUI = GameObject.FindWithTag("playerUI");
        loseMenu = GameObject.FindWithTag("looseScreen");




    }

    // Update is called once per frame
    void Update () {
        if(!isGameOver)
        {
            Time.timeScale = 1;
            rangeEnemy = GameObject.FindGameObjectsWithTag("Range");
            meleeEnemy = GameObject.FindGameObjectsWithTag("Melee");
            numOfEnemy = rangeEnemy.Length + meleeEnemy.Length;

            if(numOfEnemy == 0)
            {
                isGameOver = true;
                isWin = true;
            }

        }
        if(isGameOver)
        {
            Time.timeScale = 0;
            if(isWin)
            {
                loseMenu.GetComponent<Canvas>().enabled = true;

                loseMenu.transform.GetChild(3).GetComponent<Text>().enabled = true;
                loseMenu.transform.GetChild(1).GetComponent<Text>().enabled = false;


                //restart button
                loseMenu.transform.GetChild(0).GetChild(0).GetComponent<Text>().enabled = false;
                loseMenu.transform.GetChild(0).GetComponent<Image>().enabled = false;
                loseMenu.transform.GetChild(0).GetComponent<Button>().enabled = false;

                //next level button
                loseMenu.transform.GetChild(2).GetChild(0).GetComponent<Text>().enabled = true;
                loseMenu.transform.GetChild(2).GetComponent<Image>().enabled = true;
                loseMenu.transform.GetChild(2).GetComponent<Button>().enabled = true;


                playerUI.GetComponent<Canvas>().enabled = false;

            }

            else
            {

                loseMenu.transform.GetChild(3).GetComponent<Text>().enabled = false;
                loseMenu.transform.GetChild(1).GetComponent<Text>().enabled = true;
                loseMenu.GetComponent<Canvas>().enabled = true;
                // restart button
                loseMenu.transform.GetChild(0).GetChild(0).GetComponent<Text>().enabled = true;
                loseMenu.transform.GetChild(0).GetComponent<Image>().enabled = true;
                loseMenu.transform.GetChild(0).GetComponent<Button>().enabled = true;


                // next level button
                loseMenu.transform.GetChild(2).GetChild(0).GetComponent<Text>().enabled = false;
                loseMenu.transform.GetChild(2).GetComponent<Image>().enabled = false;
                loseMenu.transform.GetChild(2).GetComponent<Button>().enabled = false;


                playerUI.GetComponent<Canvas>().enabled = false;

            }



        }

    }
}
