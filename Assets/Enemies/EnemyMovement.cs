using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float distance = 16f;
    [SerializeField] bool isWaitingForPlayer = true;
    Vector2 dir;
    Rigidbody2D rb;
    Transform player;
    bool triggered = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player && isWaitingForPlayer)
        {
            if (Mathf.Abs(player.position.x - transform.position.x) < distance)
            {
                if (!triggered)
                {
                    triggered = true;
                    dir = new Vector2(-1, 0);
                }
            }
            else
            {
                triggered = false;
                dir = new Vector2(0, 0);
            }
        }
        else
        {
            dir = new Vector2(-1, 0);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = dir * speed;   
    }
}
