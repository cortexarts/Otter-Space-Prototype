using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    //Maximum speed
    [SerializeField]
    private float m_MaxVelocity = 200f;
    //Maximum speed while going backwards,
    [SerializeField]
    private float m_MinVelocity = 0f;
    //Current speed
    [SerializeField]
    private float m_Velocity = 0f;
    private float m_LastVelocity = 0f;
    //Value by which speed is increased
    [SerializeField]
    private float m_Acceleration = 4f;
    //Degrees turned a second if buttons are pressed 
    [SerializeField]
    private float m_RotationSpeed = 80f;
    //Fuel amount, currently untapped
    [SerializeField]
    private float m_FuelAmount = 100f;
    //Current direction the craft is moving towards
    [SerializeField]
    private Vector3 m_MoveDirection;
    [SerializeField]
    private bool m_PlayerControlled = false;

    [SerializeField]
    private float m_SpeedTransferInCollision = 1;
    
    private Rigidbody2D m_Rigidbody2D;


    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (m_PlayerControlled)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");

            if (inputVertical != 0)
            {
                ChangeDirectionAndVelocity(transform.up, m_Acceleration, inputVertical);
            }
            if (inputHorizontal != 0)
            {
                //Rotate the craft according to button press
                transform.Rotate(transform.forward, -inputHorizontal * m_RotationSpeed * Time.fixedDeltaTime);

            }
        }
        //Move the craft
        m_Rigidbody2D.velocity = m_MoveDirection * m_Velocity * Time.fixedDeltaTime;
        m_LastVelocity = m_Velocity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<ObjectController>())
        {
            ObjectController objController = collider.gameObject.GetComponent<ObjectController>();
            float speedDifference = 0;
            if (objController.m_LastVelocity < .1)
            {
                print(this.name + " obj < .1");
                speedDifference = m_Velocity;
            }
            else if (m_LastVelocity < .1)
            {
                print(this.name + " < .1");
                speedDifference = objController.m_Velocity;
            }
            else
            {
                print(this.name + " else");
                speedDifference = ((m_MoveDirection * m_Velocity) - (objController.m_MoveDirection * m_Velocity)).magnitude;
            }
            Vector2 pushDir = transform.position - collider.transform.position;
            pushDir.Normalize();
            float pushAmount = 1;
            if (m_Velocity > .1)
                pushAmount = (Mathf.Abs(Vector3.Cross(m_MoveDirection, pushDir).z) - 1) * -1;
            else
                m_MoveDirection = pushDir;
            print("n:" + this.name + " d:" + speedDifference + " p:" + pushAmount + " s:" + m_SpeedTransferInCollision);
            Debug.DrawRay(transform.position, pushDir, Color.red, speedDifference * pushAmount * m_SpeedTransferInCollision);
            ChangeDirectionAndVelocity(pushDir, speedDifference * pushAmount * m_SpeedTransferInCollision);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

    }

    private void OnTriggerStay2D(Collider2D collider)
    {

    }

    //Takes an degree angle difference between two directions and returns a value between 1 and -1
    //if the angle is 0 the directions aligned and 1 is returned
    //if the angle is 180 the directions were totally opposite and -1 is returned
    //and everything in between
    private float AngleToDirection(float angle)
    {
        return (angle - 90) / 90 * -1;
    }

    //This method is able to take a direction and howfast someone is trying to get there
    //And change the movement direction and velocity with it
    private void ChangeDirectionAndVelocity(Vector3 direction, float acceleration, float dir = 1)
    {
        float angle = Vector3.Angle(m_MoveDirection, direction * acceleration * dir);
        float accFactor = AngleToDirection(angle);
        //Change the move direction according to button press
        m_MoveDirection = m_MoveDirection * m_Velocity + direction * acceleration * dir;
        //Normalize it again
        m_MoveDirection.Normalize();
        //Update velocity
        m_Velocity += acceleration * accFactor;
        m_Velocity = Mathf.Clamp(m_Velocity, m_MinVelocity, m_MaxVelocity);
    }

    public float CurrentFuelAmount()
    {
        return m_FuelAmount;
    }

    private void OnDestroy()
    {
        Debug.Log("Still need to add animations!");
    }
}
