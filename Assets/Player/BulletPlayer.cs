using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer :MonoBehaviour
{
    [SerializeField] GameObject hitEffecfPrefab;
    Rigidbody2D rb;
    Vector2 vel;
    float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = vel * moveSpeed;
        Destroy(gameObject, 0.6f);
    }

    public void Initialize(Vector2 vel_p, float bulletSpeed_p){
        vel = vel_p.normalized;
        moveSpeed = bulletSpeed_p;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Obstacle") || other.transform.CompareTag("Enemy"))
        {
            ShowHitEffect(transform.position);
            if (other.GetComponent<Hp>())
            {

                other.GetComponent<Hp>().TakeDamage(1);
            }
            Destroy(gameObject);
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
