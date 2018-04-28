using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketShooting : MonoBehaviour
{
    public GameObject missilePrefab;
    //public Text TextValue;
    public KeyCode IncreaseKey;
    public KeyCode DecreaseKey;
    public int Value;
    public int ValueMin;
    public int ValueMax;
    public int numCorrectAnswers;
    public float cooldown = 1.0f;
    public float lastShotTime;

    // Use this for initialization
    void Start ()
    {
        Value = ValueMin;
        //TextValue.text = Value.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            if (Time.time - lastShotTime > cooldown)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }

        if (Input.GetKeyUp(IncreaseKey))
        {
            Value++;
            //TextValue.text = Value.ToString();
        }

        if (Input.GetKeyUp(DecreaseKey))
        {
            Value--;
            //TextValue.text = Value.ToString();
        }
    }

    void Shoot()
    {
        GameObject Missile = Instantiate(missilePrefab, this.transform.position, this.transform.rotation);
        Missile.SendMessage("SetAnswer", Value);
        //if (++Value > ValueMax)
        //{
        //    Value = ValueMin;
        //}
        //TextValue.text = Value.ToString();
    }
}