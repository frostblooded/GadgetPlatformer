using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    public bool blinkOnDamaged = false;

    [SerializeField]
    [ReadOnly]
    private float m_currentHealth;
    private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        m_currentHealth = maxHealth;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        m_currentHealth -= damage;

        if (m_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if (blinkOnDamaged)
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        m_spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.2f);
        m_spriteRenderer.enabled = true;
    }
}
