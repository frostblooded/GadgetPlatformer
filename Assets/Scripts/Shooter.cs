using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject shotPrefab;
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

        if (Input.GetKeyDown(KeyCode.Space) && m_shootCooldownTimer.isDone)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject spawnedShot = Instantiate(shotPrefab, shotOrigin.position, shotOrigin.rotation);
        Rigidbody2D spawnedRigidBody = spawnedShot.GetComponent<Rigidbody2D>();
        Vector2 force = Vector2.one * initialShotForce;
        force.x *= GetComponent<Player>().GetRight().x;
        spawnedRigidBody.AddForce(force);
        m_shootCooldownTimer.Restart();
    }
}
