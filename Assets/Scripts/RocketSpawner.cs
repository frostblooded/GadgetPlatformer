using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float spawnCooldown = 1;

    private float m_timeSinceLastSpawn = 0;

    private void Update()
    {
        m_timeSinceLastSpawn += Time.deltaTime;

        if(m_timeSinceLastSpawn >= spawnCooldown)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
        m_timeSinceLastSpawn = 0;
    }
}
