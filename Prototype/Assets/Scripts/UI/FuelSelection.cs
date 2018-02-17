using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSelection : MonoBehaviour
{
    public Text Name;
    public Text DescriptionText;

    // Use this for initialization
    void Start()
    {
        Name.text = "";
        DescriptionText.text = "Choose one of the fuel types as your rocket propellant.";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeFuelType(FuelObject fuel)
    {
        PlayerPrefs.SetString("FuelType", fuel.fuelName);
        Name.text = fuel.fuelName;
        DescriptionText.text = fuel.fuelDescription;
    }
}
