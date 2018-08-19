using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTypeButton : MonoBehaviour
{
    public Sprite undiscovered;
    public Sprite kerosene;
    public Sprite hydrogen;
    public Sprite diesel;
    public Sprite rp1;
    public Sprite lox;
    public Sprite coal;
    public Sprite aerozine;
    public Image buttonKerosene;
    public Image buttonDiesel;
    public Image buttonLiquidHydrogen;
    public Image buttonRP1;
    public Image buttonLOX;
    public Image buttonCoal;
    public Image buttonAerozine;
    public Image currentFuelTypeImage;
    public GameObject fuelTypeContainer;

    private ProgressManager progressManager;
    private IntroCanvasManager m_IntroCanvasManager;

    // Use this for initialization
    void Start ()
    {
        progressManager = FindObjectOfType<ProgressManager>();
        m_IntroCanvasManager = FindObjectOfType<IntroCanvasManager>();

        UpdateImage();
        UpdateFuelButtons();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateImage()
    {
        switch(progressManager.GetCurrentFuel().name)
        {
            case "Kersone":
                currentFuelTypeImage.sprite = kerosene;
                break;
            case "Hydrogen":
                currentFuelTypeImage.sprite = hydrogen;
                break;
            case "Coal":
                currentFuelTypeImage.sprite = coal;
                break;
            case "LOX":
                currentFuelTypeImage.sprite = lox;
                break;
            case "RP1":
                currentFuelTypeImage.sprite = rp1;
                break;
            case "Aerozine":
                currentFuelTypeImage.sprite = aerozine;
                break;
            case "Diesel":
                currentFuelTypeImage.sprite = diesel;
                break;
            default:
                break;
        }
    }

    public void UpdateFuelButtons()
    {
        List<FuelObject> discoveredFuel = progressManager.GetDiscoveredFuel();

        for(int i = 0; i < discoveredFuel.Count; i++)
        {
            switch(discoveredFuel[i].fuelName)
            {
                case "Kersone":
                    buttonKerosene.sprite = kerosene;
                    break;
                case "Hydrogen":
                    buttonLiquidHydrogen.sprite = hydrogen;
                    break;
                case "Coal":
                    buttonCoal.sprite = coal;
                    break;
                case "LOX":
                    buttonLOX.sprite = lox;
                    break;
                case "RP1":
                    buttonRP1.sprite = rp1;
                    break;
                case "Aerozine":
                    buttonAerozine.sprite = aerozine;
                    break;
                case "Diesel":
                    buttonDiesel.sprite = diesel;
                    break;
                default:
                    break;
            }
        }

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

            if(m_IntroCanvasManager.currentState != IntroCanvasManager.State.Playing)
            {
                m_IntroCanvasManager.ToNextState();
            }
        }
        else
        {
            Debug.LogWarning(gameObject.name + "Selected fuel type!");
        }
    }
}
