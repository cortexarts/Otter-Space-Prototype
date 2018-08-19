using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MaxVelocity = 10.0f;

    [SerializeField]
    private float m_MaxThrust = 10.0f;

    [SerializeField]
    private float m_MaxSideThrust = 5.0f;

    [SerializeField]
    private float m_RotationSpeedScale = 20.0f;

    [SerializeField]
    private float m_MovementSpeedScale = 50.0f;

    [SerializeField]
    private float m_FuelAmount = 100.0f;

    [SerializeField]
    private float m_Thrust = 0;

    [SerializeField]
    private float m_LeftThrust = 0;

    [SerializeField]
    private float m_RightThrust = 0;

    [SerializeField]
    private bool m_Thrusting = false;

    [SerializeField]
    private bool m_LeftThrusting = false;

    [SerializeField]
    private bool m_RightThrusting = false;

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
            m_FuelAmount -= Time.deltaTime / fuelLevel;
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

    private void FixedUpdate()
    {
        // Rotation based on accelerometer
        transform.Rotate(transform.forward, (-Input.acceleration.x + m_LeftThrust - m_RightThrust) * m_RotationSpeedScale * Time.fixedDeltaTime);

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

        m_Thrust = Mathf.Clamp(m_Thrust, 0.0f, m_MaxThrust);
        m_LeftThrust = Mathf.Clamp(m_LeftThrust, 0.0f, m_MaxSideThrust);
        m_RightThrust = Mathf.Clamp(m_RightThrust, 0.0f, m_MaxSideThrust);

        rigidBody2D.AddForce(transform.up * m_Thrust * m_MovementSpeedScale * Time.fixedDeltaTime);
        rigidBody2D.AddForce(transform.right * m_LeftThrust * m_MovementSpeedScale * Time.fixedDeltaTime);
        rigidBody2D.AddForce(-transform.right * m_RightThrust * m_MovementSpeedScale * Time.fixedDeltaTime);

        // Clamp velocity as thrust only adds more force
        Vector2 velocity = Vector2.zero;

        velocity.x = Mathf.Clamp(rigidBody2D.velocity.x, -m_MaxVelocity, m_MaxVelocity);
        velocity.y = Mathf.Clamp(rigidBody2D.velocity.y, -m_MaxVelocity, m_MaxVelocity);

        rigidBody2D.velocity = velocity;
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

    public float GetVelocity()
    {
        float velocity = rigidBody2D.velocity.magnitude;

        return velocity;
    }

    public float GetFuelAmount()
    {
        return m_FuelAmount;
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
