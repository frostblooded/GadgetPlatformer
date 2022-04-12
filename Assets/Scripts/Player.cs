using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30.0f;

    private Animator m_animator;
    private SpriteRenderer m_spriteRenderer;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 movement = new Vector3();

        if(Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if(movement.magnitude > 0)
        {
            m_animator.SetBool("IsWalking", true);

            if(movement.x >= 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            m_animator.SetBool("IsWalking", false);
        }

        transform.position += movement;
    }

    public Vector2 GetRight()
    {
        if (transform.localScale.x >= 0)
            return Vector2.right;

        return -Vector2.right;
    }
}
