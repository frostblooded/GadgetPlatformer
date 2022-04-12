using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHat : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform spawnLocation;
    public float spawnCooldown = 1;
    public int maxSpawnCount = 3;

    private float m_timeSinceLastSpawn = 0;
    private int m_spawnsCount = 0;

    private void Update()
    {
        m_timeSinceLastSpawn += Time.deltaTime;

        if(m_timeSinceLastSpawn >= spawnCooldown)
        {
            Spawn();
        }

        if(m_spawnsCount >= maxSpawnCount)
        {
            Destroy(gameObject);
        }
    }

    private void Spawn()
    {
        Instantiate(rocketPrefab, spawnLocation.position, Quaternion.identity);
        m_spawnsCount++;
        m_timeSinceLastSpawn = 0;
    }
}
