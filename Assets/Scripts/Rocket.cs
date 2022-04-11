using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 0.3f;

    private float m_timeAlive = 0;
    private float m_effectiveSpeed;

    private void Update()
    {
        m_timeAlive += Time.deltaTime;

        CalculateSpeed();
        transform.position += transform.up * m_effectiveSpeed * Time.deltaTime;
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        Transform player = FindObjectOfType<Player>().transform;
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) - Mathf.PI/2) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * speed);
    }

    private void CalculateSpeed()
    {
        if(m_timeAlive < 1)
        {
            m_effectiveSpeed = speed;
        }
        else if(m_timeAlive < 2)
        {
            m_effectiveSpeed = speed * 2;
        }
        else
        {
            m_effectiveSpeed = speed * 3;
        }
    }

}
