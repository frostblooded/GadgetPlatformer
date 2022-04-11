using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
}
