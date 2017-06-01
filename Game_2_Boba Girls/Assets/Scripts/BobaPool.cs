using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaPool : MonoBehaviour {
    public int pooledAmount = 30;
    public List<GameObject> bobaPool;
    public GameObject boba;

    // Use this for initialization
    void Start () {
        bobaPool = new List<GameObject>();
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = (GameObject)Instantiate(boba);
            obj.SetActive(false);
 //           obj.hideFlags = HideFlags.HideInHierarchy;
            bobaPool.Add(obj);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
