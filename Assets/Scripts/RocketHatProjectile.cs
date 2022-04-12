using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHatProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<RocketHat>().enabled = true;
        enabled = false;
    }
}
