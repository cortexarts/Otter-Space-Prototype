using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroidField : MonoBehaviour
{
    public GameObject AsteroidField;
    public Vector3 SpawnOffset;
    public bool hasSpawnedFied;
    public float SpawnDelay;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.realtimeSinceStartup > SpawnDelay && !hasSpawnedFied)
        {
            SpawnAsteroids(SpawnOffset);
            hasSpawnedFied = true;
        }
	}

    public void SpawnAsteroids(Vector3 a_SpawnOffset)
    {
        Instantiate(AsteroidField, this.gameObject.transform.position + a_SpawnOffset, Quaternion.identity);
    }
}
