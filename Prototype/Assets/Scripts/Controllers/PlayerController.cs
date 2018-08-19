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
    private float m_Thrust = 0;
    private float m_LeftThrust = 0;
    private float m_RightThrust = 0;
    private bool m_Thrusting = false;
    private bool m_LeftThrusting = false;
    private bool m_RightThrusting = false;

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

        if (CrossPlatformInputManager.GetButtonDown("Boost"))
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }
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
        //if (rigidBody2D.velocity.x < maxMovementSpeed && rigidBody2D.velocity.y < maxMovementSpeed)
        //{
        //    rigidBody2D.AddForce(transform.up * CrossPlatformInputManager.GetAxis("Vertical") * movementSpeedScale * Time.fixedDeltaTime);
        //}

        //transform.Rotate(transform.forward, -CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeedScale * Time.fixedDeltaTime);

        // Horizontal movement based on accelerometer for rotation
        transform.Rotate(transform.forward, -Input.acceleration.x * rotationSpeedScale * Time.fixedDeltaTime);

        if(m_Thrusting)
        {
            m_Thrust += Time.fixedDeltaTime;
        }
        else if (m_Thrust > 0)
        {
            m_Thrust = 0;
        }

        if(m_LeftThrusting)
        {
            m_LeftThrust += Time.deltaTime;
        }
        else if(m_LeftThrust > 0)
        {
            m_LeftThrust = 0;
        }

        if(m_RightThrusting)
        {
            m_RightThrust += Time.deltaTime;
        }
        else if(m_RightThrust > 0)
        {
            m_RightThrust = 0;
        }

        //if(rigidBody2D.velocity.x < maxMovementSpeed && rigidBody2D.velocity.y < maxMovementSpeed)
        //{
        //    rigidBody2D.AddForce(transform.up * m_Thrust * movementSpeedScale * Time.fixedDeltaTime);
        //    rigidBody2D.AddForce(-transform.right * m_LeftThrust * movementSpeedScale * Time.fixedDeltaTime);
        //    rigidBody2D.AddForce(transform.right * m_RightThrust * movementSpeedScale * Time.fixedDeltaTime);
        //}

        rigidBody2D.AddForce(transform.up * m_Thrust * movementSpeedScale * Time.fixedDeltaTime);
        rigidBody2D.AddForce(-transform.right * m_LeftThrust * movementSpeedScale * Time.fixedDeltaTime);
        rigidBody2D.AddForce(transform.right * m_RightThrust * movementSpeedScale * Time.fixedDeltaTime);
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
    
    public void SetThrusting(bool a_Thrusting)
    {
        m_Thrusting = a_Thrusting;
    }

    public void SetLeftThrusting(bool a_Thrusting)
    {
        m_LeftThrusting = a_Thrusting;
    }

    public void SetRightThrusting(bool a_Thrusting)
    {
        m_RightThrusting = a_Thrusting;
    }
}
