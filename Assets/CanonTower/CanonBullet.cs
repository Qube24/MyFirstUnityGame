using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    int bulletPower;
    float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 16f;
        rb.velocity = vel * moveSpeed;
        Destroy(gameObject, 3f);
    }

    public void Initialize(Vector2 vel_p, int power_p){
        vel = vel_p.normalized;
        bulletPower = power_p;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Obstacle") || other.transform.CompareTag("Player"))
        {
            if (other.GetComponent<Hp>())
            {
                other.GetComponent<Hp>().TakeDamage(bulletPower);
            }
            Destroy(gameObject, 0f);
        }
    }
}
