using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a hat projectile that activates mid-air when it reaches
// the highest point in its arc.
public class FlyingHatProjectile : HatProjectile
{
    public float flightHeight = 5;
    public float movementX = 1;
    public float movementY = 1;

    private float m_startingHeight;
    private Vector3 m_movement;

    override protected void Start()
    {
        m_startingHeight = transform.position.y;
        m_movement = new Vector3(movementX, movementY, 0);
        base.Start();
    }

    private void Update()
    {
        if (transform.position.y - m_startingHeight >= flightHeight)
            ActivateHat();
        else
            transform.position += m_movement * Time.deltaTime;
    }
}
