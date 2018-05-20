using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTypeButton : MonoBehaviour
{
    public Sprite kerosene;
    public Sprite hydrogen;
    public Image currentFuelTypeImage;
    public GameObject fuelTypeContainer;

    private ProgressManager progressManager;

	// Use this for initialization
	void Start ()
    {
        progressManager = FindObjectOfType<ProgressManager>();

        UpdateImage();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateImage()
    {
        if(progressManager.GetCurrentFuel().name == "Kerosene")
        {
            currentFuelTypeImage.sprite = kerosene;
        }
        else if(progressManager.GetCurrentFuel().name == "Hydrogen")
        {
            currentFuelTypeImage.sprite = hydrogen;
        }
    }
    
    public void ToggleFuelContainer()
    {
        if(fuelTypeContainer.activeInHierarchy)
        {
            fuelTypeContainer.SetActive(false);
        }
        else
        {
            fuelTypeContainer.SetActive(true);
        }
    }

    public void SetFuelType(FuelObject fuel)
    {
        if(fuelTypeContainer.activeInHierarchy)
        {
            progressManager.SetCurrentFuel(fuel);
            ToggleFuelContainer();
            UpdateImage();
        }
        else
        {
            Debug.LogWarning(gameObject.name + "Selected fuel type!");
        }
    }
}
