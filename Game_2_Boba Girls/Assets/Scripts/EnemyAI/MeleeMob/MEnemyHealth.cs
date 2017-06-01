using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEnemyHealth : MonoBehaviour {
    public int lives = 1;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	public void Update ()
    {
        if(lives == 0)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
		
	}

    public void  takeLive()
    {
        lives -= 1;
    }
}
