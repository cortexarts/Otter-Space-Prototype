using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTrigger : MonoBehaviour
{

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
        if(collision.tag == "Player")
        {
            CameraController.m_Instance.ChangeSize();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CameraController.m_Instance.ChangeSize();
        }
    }
}
