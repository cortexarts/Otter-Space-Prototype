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
    [TextArea]
    public string fuelDescription;
    public string fuelFormula;
    public FuelTypes fuelType;
    public List<string> elements;
    public float fuelLevel;
}
