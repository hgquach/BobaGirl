using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobaProperty : MonoBehaviour {

    // Use this for initialization
    void OnEnable()
    {
        Invoke("Destroy", 2);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "IZ" || collision.gameObject.tag == "FOD")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<Collider>());
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeLive();
            StartCoroutine(Flasher(collision));
        }

        if (collision.gameObject.tag == "Melee")
        {
            collision.gameObject.GetComponent<MEnemyHealth>().takeLive();
            StartCoroutine(Flasher(collision));

        }

        if (collision.gameObject.tag == "Range")
        {
            collision.gameObject.GetComponent<REnemyHealth>().takeLive();
            StartCoroutine(Flasher(collision));

        }


    }

    IEnumerator Flasher(Collision collision)
    {
        Color normalColor;
        Color hurtColor = Color.magenta;
        if( collision.gameObject != null)
        {
            normalColor = collision.gameObject.GetComponent<Renderer>().material.color;
            if (collision.gameObject != null)
                collision.gameObject.GetComponent<Renderer>().material.color = hurtColor;
            yield return new WaitForSeconds(.1f);
            if (collision.gameObject != null)
            {
                collision.gameObject.GetComponent<Renderer>().material.color = normalColor;

            }
            yield return new WaitForSeconds(.1f);

        }

        
    }

}
