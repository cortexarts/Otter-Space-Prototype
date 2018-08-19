using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MaxVelocity = 10.0f;

    [SerializeField]
    private float m_RotationSpeedScale = 20.0f;

    [SerializeField]
    private float m_MovementSpeedScale = 50.0f;

    [SerializeField]
    private float m_FuelAmount = 100.0f;

    [SerializeField]
    private float m_ForwardThrust = 0;

    [SerializeField]
    private float m_SideThrust = 0;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float m_ForwardThrustLimit;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float m_SideThrustLimit;

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
        transform.Rotate(transform.forward, (-Input.acceleration.x + m_SideThrust) * m_RotationSpeedScale * Time.fixedDeltaTime);

        if(m_Thrusting)
        {
            m_ForwardThrust += Time.fixedDeltaTime;
        }
        else
        {
            m_ForwardThrust = 0;
        }

        if(m_LeftThrusting)
        {
            m_SideThrust += Time.deltaTime;
        }
        else if(m_RightThrusting)
        {
            m_SideThrust -= Time.deltaTime;
        }
        else
        {
            m_SideThrust = 0;
        }

        m_ForwardThrust = Mathf.Clamp(m_ForwardThrust, 0.0f, m_ForwardThrustLimit);
        m_SideThrust = Mathf.Clamp(m_SideThrust, -m_SideThrustLimit, m_SideThrustLimit);

        rigidBody2D.AddForce(transform.up * m_ForwardThrust * m_MovementSpeedScale * Time.fixedDeltaTime);

        if(m_SideThrust > 0.0f)
        {
            rigidBody2D.AddForce(transform.right * m_SideThrust * m_MovementSpeedScale * Time.fixedDeltaTime);
        }
        else
        {
            rigidBody2D.AddForce(-transform.right * -m_SideThrust * m_MovementSpeedScale * Time.fixedDeltaTime);
        }

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

    public bool GetIsThrusting()
    {
        return m_Thrusting;
    }

    public bool GetIsLeftthrusting()
    {
        return m_LeftThrusting;
    }

    public bool GetIsRightThrusting()
    {
        return m_RightThrusting;
    }

    public float GetForwardThrust()
    {
        return m_ForwardThrust;
    }

    public float GetSideThrust()
    {
        return m_SideThrust;
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
