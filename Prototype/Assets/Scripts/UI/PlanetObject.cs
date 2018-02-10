using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Planet", menuName = "Planet")]
public class PlanetObject : ScriptableObject
{
    public string planetName;
    public string planetGalaxy;
    public float planetDistance;
    public float planetDiameter;
    public string planetDescription;
    public Sprite planetImage;
    public Sprite planetBackground;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
