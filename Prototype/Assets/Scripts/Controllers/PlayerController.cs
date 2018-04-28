using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxMovementSpeed = 10.0f;
    public float rotationSpeedScale = 20.0f;
    public float movementSpeedScale = 50.0f;
    public float fuelAmount = 100.0f;

    private Rigidbody2D rigidBody2D;
    private GameObject planet;
    private bool isBoosting = false;
    private int fuelLevel = 1;

	// Use this for initialization
	void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetInt("FuelLevel") > 0)
        {
            fuelLevel = PlayerPrefs.GetInt("FuelLevel");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rigidBody2D.velocity.x > 0.0f || rigidBody2D.velocity.y > 0.0f)
        {
            fuelAmount -= Time.deltaTime / fuelLevel;
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (CrossPlatformInputManager.GetButtonDown("Boost"))
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }

        Debug.DrawLine(transform.position, rigidBody2D.transform.up, Color.red);
    }

    private void Shoot()
    {
        Debug.Log("Shot!");
    }

    public float GetVelocity()
    {
        float velocity = rigidBody2D.velocity.magnitude;
        return velocity;
    }

    public float GetFuelAmount()
    {
        return fuelAmount;
    }

    private void FixedUpdate()
    {
        if (rigidBody2D.velocity.x < maxMovementSpeed && rigidBody2D.velocity.y < maxMovementSpeed)
        {
            rigidBody2D.AddForce(transform.up * CrossPlatformInputManager.GetAxis("Vertical") * movementSpeedScale * Time.fixedDeltaTime);
        }

        transform.Rotate(transform.forward, -CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeedScale * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Planet")
        {
            planet = collider.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Planet")
        {
            planet = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Planet")
        {
            planet = null;
        }
    }
}
