using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetDisplay : MonoBehaviour
{
    public Text planetName;
    public Text planetGalaxy;
    public Text planetDistance;
    public Text planetDiameter;
    public Text planetDescription;
    public Image planetImage;
    public Image planetBackground;
    public PlanetObject initialPlanet;

	// Use this for initialization
	void Start ()
    {
        ChangeActivePlanet(initialPlanet);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeActivePlanet(PlanetObject planet)
    {
        planetName.text = planet.planetName;
        planetGalaxy.text = planet.planetGalaxy + " galaxy";
        planetDistance.text = planet.planetDistance.ToString() + " km";
        planetDiameter.text = planet.planetDiameter.ToString() + " km";
        planetDescription.text = planet.planetDescription;
        planetImage.sprite = planet.planetImage;
        planetBackground.sprite = planet.planetBackground;
    }
}
