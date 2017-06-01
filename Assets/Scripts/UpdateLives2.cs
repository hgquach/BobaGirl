using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives2 : MonoBehaviour {

    private Text currentText;
    private PlayerHealth2 health;
    public GameObject PlayerHealth;

    // Use this for initialization
    void Start()
    {
        currentText = this.GetComponent<Text>();
        health = PlayerHealth.GetComponent<PlayerHealth2>();

    }

    // Update is called once per frame
    void Update()
    {
        currentText.text = string.Concat("You have: " + health.playerLives.ToString()+" Lives Left");


    }
}
