using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float rotationPull = 1.0f;
    public float mass = 1.0f;
    private const float gravitationalPull = 667.4f;

    private void Start()
    {
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attract(collision.gameObject);
    }

    void Attract(GameObject objToAttract)
    {
        Debug.Log(gameObject.name + " is attracting " + objToAttract.name);

        Rigidbody2D rbToAttract = objToAttract.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(transform.position.x, transform.position.y) - rbToAttract.position;
        float distance = direction.magnitude;

        // Position
        float forceMagnitude = gravitationalPull * (mass * rbToAttract.mass) / Mathf.Pow(distance, 3);
        Vector2 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);

        // Rotation
        float angle = Vector3.Angle(Vector3.up, objToAttract.transform.position - transform.position);
        float currentAngle = objToAttract.transform.eulerAngles.z;
        if (objToAttract.transform.position.x > transform.position.x)
        {
            angle = -angle;
        }
        float finalAngle = Mathf.LerpAngle(currentAngle, angle, Time.deltaTime);
        objToAttract.transform.eulerAngles = new Vector3(0, 0, finalAngle);
    }
}
