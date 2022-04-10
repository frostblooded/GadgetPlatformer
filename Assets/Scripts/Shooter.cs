using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject shotPrefab;
    public float initialShotForce = 50.0f;

    private Transform m_shotOrigin;

    private void Start()
    {
        m_shotOrigin = transform.Find("ShotOrigin");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedShot = Instantiate(shotPrefab, m_shotOrigin.position, m_shotOrigin.rotation);
            Rigidbody2D spawnedRigidBody = spawnedShot.GetComponent<Rigidbody2D>();
            spawnedRigidBody.AddForce(Vector2.one * initialShotForce);
        }
    }
}
