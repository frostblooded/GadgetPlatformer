using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class HatProjectile : MonoBehaviour
{
    public MonoBehaviour hatComponent;

    virtual protected void Start()
    {
        hatComponent.enabled = false;
    }

    protected void ActivateHat()
    {
        Destroy(GetComponent<Rigidbody2D>());
        hatComponent.enabled = true;
        enabled = false;
    }
}
