using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnerProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<RocketSpawner>().enabled = true;
        enabled = false;
    }
}
