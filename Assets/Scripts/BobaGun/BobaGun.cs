using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaGun : MonoBehaviour {
    private Transform spawnPoint;
    public float bobaSpeed = 1000.0f;
    public GameObject bulletSpawn;

    public GameObject bobaPoolContainer;
    private BobaPool bobapool ;
	// Use this for initialization
	void Start ()
    {
        bobapool =bobaPoolContainer.GetComponent<BobaPool>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void gunFire()
    {
        spawnPoint = bulletSpawn.GetComponent<Transform>();

        for (int i = 0; i <bobapool.bobaPool.Count; ++i)
        {
            if(!bobapool.bobaPool[i].activeInHierarchy)
            {
                bobapool.bobaPool[i].transform.position = spawnPoint.position;
                bobapool.bobaPool[i].transform.rotation = spawnPoint.rotation;
                bobapool.bobaPool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                bobapool.bobaPool[i].SetActive(true);
                bobapool.bobaPool[i].GetComponent<Rigidbody>().AddForce(transform.right * bobaSpeed);
                break;
            }
        }
        //boba = Instantiate( boba,spawnPoint.position,spawnPoint.rotation);
        //boba.GetComponent<Rigidbody>().AddRelativeForce(transform.right * bobaSpeed);

    }
}
