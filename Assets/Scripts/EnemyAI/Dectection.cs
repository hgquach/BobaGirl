using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dectection : MonoBehaviour {

    public bool isDetected;
	// Use this for initialization
	void Start () {
        isDetected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isDetected = true;
            print("Detected");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            isDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isDetected = false;
            Debug.Log("left Detection Zone");

        }
 

    }
}
