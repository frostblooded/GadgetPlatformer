using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 0.3f;
    public float damage = 1;

    private float m_timeAlive = 0;
    private float m_effectiveSpeed;
    private ParticleSystem m_particleSystem;
    private int m_speedStage = 0;
    private Transform m_target;

    private void Start()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
        m_effectiveSpeed = speed;
        m_target = PickTarget();
    }

    private void Update()
    {
        m_timeAlive += Time.deltaTime;

        CalculateSpeed();
        transform.position += transform.up * m_effectiveSpeed * Time.deltaTime;
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        if (!m_target)
            return;

        Vector3 vectorToTarget = m_target.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) - Mathf.PI / 2) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * speed);
    }

    private void CalculateSpeed()
    {
        if (m_speedStage == 0 && m_timeAlive >= 1)
        {
            m_effectiveSpeed = speed * 2;
            m_particleSystem.Emit(20);
            m_speedStage = 1;
        }
        else if (m_speedStage == 1 && m_timeAlive >= 2)
        {
            m_effectiveSpeed = speed * 3;
            m_particleSystem.Emit(20);
            m_speedStage = 2;
        }
    }

    private Transform PickTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy closestEnemy = Helpers.FindClosest(transform.position, enemies);

        if (!closestEnemy)
            return default;

        return closestEnemy.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
