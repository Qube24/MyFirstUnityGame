using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    int bulletSpeed = 1;
    int bulletPower = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1*bulletSpeed, 0f);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Obstacle") || other.transform.CompareTag("Player")){
            if (other.GetComponent<Hp>())
            {
                other.GetComponent<Hp>().TakeDamage(bulletPower);
            }
            Destroy(gameObject,0f);
        }
    }

    public void Initialize(int speed, int power)
    {
        bulletSpeed = speed;
        bulletPower = power;
    }
}
