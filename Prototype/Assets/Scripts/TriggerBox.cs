using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public GameObject AsteroidSpawner;
    public GameObject m_CanvasCamera;

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
        if (collision.tag == "Player")
        {
            m_CanvasCamera.SetActive(true);
            Instantiate(AsteroidSpawner, gameObject.transform.position, Quaternion.identity);
        }
    }
}
