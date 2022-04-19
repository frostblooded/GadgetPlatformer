using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;

    [SerializeField]
    [ReadOnly]
    private float m_currentHealth;

    private void Start()
    {
        m_currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        m_currentHealth -= damage;

        if (m_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
