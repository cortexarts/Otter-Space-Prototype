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

    private void ShortenValue(Text target, float value)
    {
        // Display shortened distances
        if (value >= 1000000000.0f)
        {
            string tmpDistance = value.ToString("n0");
            target.text = tmpDistance.Remove(tmpDistance.Length - 9) + "bln km";
        }
        else if (value >= 1000000.0f)
        {
            string tmpDistance = value.ToString("n0");
            target.text = tmpDistance.Remove(tmpDistance.Length - 6) + "mln km";
        }
        else if (value >= 1000.0f)
        {
            string tmpDistance = value.ToString("n0");
            target.text = tmpDistance.Remove(tmpDistance.Length - 3) + "k km";
        }
        else if (value >= 0.0f)
        {
            target.text = value.ToString("n0") + " km";
        }
    }

    public void ChangeActivePlanet(PlanetObject planet)
    {
        planetName.text = planet.planetName;
        planetGalaxy.text = planet.planetGalaxy + " galaxy";
        ShortenValue(planetDistance, planet.planetDistanceToEarth);
        ShortenValue(planetDiameter, planet.planetRadius);
        planetDiameter.text = planet.planetRadius.ToString("n0") + " km";
        planetDescription.text = planet.planetDescription;
        planetImage.sprite = planet.planetImage;
        planetBackground.sprite = planet.planetBackground;
    }
}
