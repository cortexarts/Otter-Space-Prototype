using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDespawn : MonoBehaviour
{
    private GameObject AsteroidSpawner;
    private GameObject player;

    public int maxDistanceToRocket;

    private void Start()
    {
        player = FindObjectOfType<RocketShooting>().gameObject;
    }

    void AsteroidSpawnerID(GameObject ID)
    {
        AsteroidSpawner = ID;
    }

    void OnDestroy()
    {
        if (AsteroidSpawner != null)
        {
            AsteroidSpawner.SendMessage("RequestAsteroidSpawn");
        }
    }

    void Update()
    {
        if (AsteroidSpawner != null)
        {
            float distanceToRocket = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
            
            if (distanceToRocket > maxDistanceToRocket) DestroyObject(this.gameObject);
        }
    }
}