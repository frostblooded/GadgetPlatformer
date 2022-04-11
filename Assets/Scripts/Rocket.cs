using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 0.3f;

    private void Update()
    {
        // transform.position += transform.up * speed * Time.deltaTime;

        Transform player = FindObjectOfType<Player>().transform;
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
