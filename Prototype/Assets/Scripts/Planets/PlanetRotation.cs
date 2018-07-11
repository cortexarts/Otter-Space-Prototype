using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // FixedUpdate is called every fixed framerate frame, if the MonoBehaviour is enabled.
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed, Space.World);
    }
}
