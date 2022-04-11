using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject shotPrefab;
    public float initialShotForce = 50.0f;
    public float shootCooldown = 2;
    public Transform shotOrigin;

    private float m_timeSinceLastShoot = 0;

    private void Update()
    {
        m_timeSinceLastShoot += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && m_timeSinceLastShoot >= shootCooldown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject spawnedShot = Instantiate(shotPrefab, shotOrigin.position, shotOrigin.rotation);
        Rigidbody2D spawnedRigidBody = spawnedShot.GetComponent<Rigidbody2D>();
        spawnedRigidBody.AddForce(Vector2.one * initialShotForce);
        m_timeSinceLastShoot = 0;
    }
}
