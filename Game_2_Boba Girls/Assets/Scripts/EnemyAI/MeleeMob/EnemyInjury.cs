using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInjury : MonoBehaviour {

    public bool canAttack = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" )
        {
            print("canAttack");
            canAttack = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            canAttack = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canAttack = false;
        Debug.Log("left IZ zone");
    }
}

