using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHat : MonoBehaviour
{
    public float speed = 1;

    private Transform m_target;

    private void OnEnable()
    {
        GetComponent<Spawner>().enabled = true;
    }

    private void Start()
    {
        m_target = PickTarget();
    }

    private void Update()
    {
        if (!m_target)
            m_target = PickTarget();

        if (m_target)
        {
            Vector3 desiredPosition = new Vector3(m_target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
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
}
