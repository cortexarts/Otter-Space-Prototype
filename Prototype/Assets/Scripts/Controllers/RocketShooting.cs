using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketShooting : MonoBehaviour
{
    public GameObject missilePrefab;
    public Text TextValue;
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
        TextValue.text = Value.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp(IncreaseKey))
        {
            IncrementValue();
        }

        if (Input.GetKeyUp(DecreaseKey))
        {
            DecrementValue();
        }
    }

    public void Shoot()
    {
        if(Time.time - lastShotTime > cooldown)
        {
            CreateMissile();
            lastShotTime = Time.time;
        }
    }

    private void CreateMissile()
    {
        GameObject Missile = Instantiate(missilePrefab, this.transform.position, this.transform.rotation);
        Missile.SendMessage("SetAnswer", Value);
        Missile.GetComponent<MissileBehaviour>().AddVelocity(GetComponent<PlayerController>().GetVelocity());
        if(++Value > ValueMax)
        {
            Value = ValueMin;
        }
        TextValue.text = Value.ToString();
    }

    public void IncrementValue()
    {
        Value++;
        TextValue.text = Value.ToString();
    }

    public void DecrementValue()
    {
        Value--;
        TextValue.text = Value.ToString();
    }
}