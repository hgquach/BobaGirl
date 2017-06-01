using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour {

    private Text currentText;
    private PlayerHealth health;
    public GameObject PlayerHealth;

    // Use this for initialization
    void Start()
    {
        currentText = this.GetComponent<Text>();
        health = PlayerHealth.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        currentText.text = string.Concat("You have: " + health.playerLives.ToString()+" Lives Left");


    }
}
