using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSwipe : MonoBehaviour
{
    public Vector3 axis = Vector3.forward;
    public Canvas target;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    private Vector3 center;

    // Use this for initialization
    void Start ()
    {
        center = new Vector3(0.0f, -5.0f, 0.0f);
        //transform.position = (transform.position - center).normalized * radius + center;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(target.transform.position + center, axis, rotationSpeed * Time.deltaTime);
        Vector3 desiredPosition = (transform.position - center).normalized * radius + center;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}
