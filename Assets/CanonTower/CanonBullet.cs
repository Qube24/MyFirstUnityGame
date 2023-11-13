using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    [SerializeField] GameObject hitEffecfPrefab;
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
            ShowHitEffect(transform.position);
            if (other.GetComponent<Hp>())
            {
                other.GetComponent<Hp>().TakeDamage(bulletPower);
            }
            Destroy(gameObject, 0f);
        }
    }

    void ShowHitEffect(Vector2 pos)
    {
        if (hitEffecfPrefab)
        {
            GameObject hitEffect = Instantiate(hitEffecfPrefab, pos, Quaternion.identity);
            Destroy(hitEffect, 1f);
        }
    }

}
