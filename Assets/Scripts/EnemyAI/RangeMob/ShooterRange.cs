using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRange : MonoBehaviour {
    public bool canShoot = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            Debug.Log("can shoot");
            canShoot = true;
        }

    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("can shoot");

            canShoot = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("cannot shoot");

            canShoot = false;
        }
    }


}
