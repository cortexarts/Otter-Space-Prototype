using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField]
    private FuelObject m_currentFuel;
    [SerializeField]
    private List<FuelObject> m_discoveredFuel;

	// Use this for initialization
	void Start ()
    {
        if(!m_discoveredFuel.Contains(m_currentFuel))
        {
            m_discoveredFuel.Add(m_currentFuel);
        }	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetCurrentFuel(FuelObject fuelObject)
    {
        m_currentFuel = fuelObject;
    }

    public FuelObject GetCurrentFuel()
    {
        return m_currentFuel;
    }

    public void AddDiscoveredFuel(FuelObject fuelObject)
    {
        // Only add fuel if it isn't discovered yet
        if(!m_discoveredFuel.Contains(fuelObject))
        {
            m_discoveredFuel.Add(fuelObject);
        }
        else
        {
            Debug.Log(fuelObject.name + " has already been discovered!");
        }
    }
}
