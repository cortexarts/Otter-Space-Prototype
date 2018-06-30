using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForAsteroids : MonoBehaviour
{
    public GameObject indicator;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            collision.GetComponent<Indicator>().enabled = true;
            collision.GetComponent<Indicator>().RGBA.w = 1.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            collision.GetComponent<Indicator>().enabled = false;
            collision.GetComponent<Indicator>().RGBA.w = 1.0f;
        }
    }
}
