using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHatProjectile : HatProjectile
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ActivateHat();
    }
}
