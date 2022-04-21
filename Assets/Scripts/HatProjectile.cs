using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatProjectile : MonoBehaviour
{
    public MonoBehaviour hatComponent;

    private void Start()
    {
        hatComponent.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(GetComponent<Rigidbody2D>());
        hatComponent.enabled = true;
        enabled = false;
    }
}
