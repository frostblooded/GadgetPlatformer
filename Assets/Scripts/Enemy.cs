using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float damage = 2;
    public float damageCooldown = 1;

    private float m_timeSinceLastDamage = Mathf.Infinity;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        GetComponent<Animator>().SetBool("IsWalking", true);

        m_timeSinceLastDamage += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_timeSinceLastDamage > damageCooldown)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);
                m_timeSinceLastDamage = 0;
            }
        }
    }
}
