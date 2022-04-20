using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 1;
    public float radius = 1;

    private void Start()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            Health hitHealth = hit.collider.GetComponent<Health>();

            if (hitHealth)
                hitHealth.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
