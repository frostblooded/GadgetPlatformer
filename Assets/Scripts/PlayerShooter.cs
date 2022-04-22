using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject shot1Prefab;
    public GameObject shot2Prefab;
    public float initialShotForce = 50.0f;
    public float shootCooldown = 2;
    public Transform shotOrigin;

    private Timer m_shootCooldownTimer;

    private void Start()
    {
        m_shootCooldownTimer = new Timer(shootCooldown);

        // Make the timer start as completed so that the shooter can shoot
        // its first shot immediately.
        m_shootCooldownTimer.CompleteTimer();
    }

    private void Update()
    {
        m_shootCooldownTimer.Update();

        if (m_shootCooldownTimer.isDone)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Shoot(shot1Prefab);
            else if (Input.GetKeyDown(KeyCode.E))
                Shoot(shot2Prefab);
        }
    }

    private void Shoot(GameObject shotPrefab)
    {
        GameObject spawnedShot = Instantiate(shotPrefab, shotOrigin.position, shotOrigin.rotation);
        Rigidbody2D spawnedRigidBody = spawnedShot.GetComponent<Rigidbody2D>();
        Vector2 force = Vector2.one * initialShotForce;
        force.x *= GetComponent<Player>().GetRight().x;
        spawnedRigidBody.AddForce(force);
        m_shootCooldownTimer.Restart();
    }
}
