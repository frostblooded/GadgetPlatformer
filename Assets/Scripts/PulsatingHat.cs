using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsatingHat : MonoBehaviour
{
    public float radius = 1;
    public float force = 10;
    public float forceCooldown = 2;

    private Timer m_forceTimer;
    private ParticleSystem m_particleSystem;

    private void Start()
    {
        m_forceTimer = new Timer(forceCooldown, true);
        m_forceTimer.onTimerEnd += Pulse;

        m_particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        m_forceTimer.Update();
    }

    private void Pulse()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            Rigidbody2D rigidbody2D = hit.collider.GetComponent<Rigidbody2D>();

            if (!rigidbody2D)
                continue;

            Vector3 directionNormalized = (hit.transform.position - transform.position).normalized;
            rigidbody2D.AddForce(directionNormalized * force, ForceMode2D.Impulse);
        }

        m_particleSystem.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
