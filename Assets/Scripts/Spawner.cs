using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedPrefab;
    public Transform spawnLocation;
    public float spawnCooldown = 1;
    public int maxSpawnCount = 3;

    private Timer m_spawnTimer;

    private void Start()
    {
        m_spawnTimer = new Timer(spawnCooldown, true);
        m_spawnTimer.onTimerEnd += Spawn;
    }

    private void Update()
    {
        m_spawnTimer.Update();

        if (m_spawnTimer.timesTriggered >= maxSpawnCount)
        {
            Destroy(gameObject);
        }
    }

    private void Spawn()
    {
        Instantiate(spawnedPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
