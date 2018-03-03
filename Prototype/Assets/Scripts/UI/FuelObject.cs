using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FuelTypes
{
    Liquid,
    Petroleum,
    Cryogenic,
    Solid
}

[CreateAssetMenu(fileName = "New Fuel", menuName = "Fuel")]
public class FuelObject : ScriptableObject
{
    public string fuelName;
    public string fuelDescription;
    public string fuelFormula;
    public FuelTypes fuelType;
    public float fuelLevel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
