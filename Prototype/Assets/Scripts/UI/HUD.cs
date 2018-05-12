using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Speed;
    public Text Fuel;

    private PlayerController player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Speed.text = player.GetVelocity().ToString("F");
        Fuel.text = player.GetFuelAmount().ToString("F");
    }
}
