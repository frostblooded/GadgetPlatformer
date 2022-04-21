using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float damage = 2;
    public float damageCooldown = 1;

    private Timer m_damageTimer;

    private void Start()
    {
        m_damageTimer = new Timer(damageCooldown);

        // Can damage immediately
        m_damageTimer.CompleteTimer();
    }

    void Update()
    {
        m_damageTimer.Update();
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        GetComponent<Animator>().SetBool("IsWalking", true);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_damageTimer.isDone)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);
                m_damageTimer.Restart();
            }
        }
    }
}
