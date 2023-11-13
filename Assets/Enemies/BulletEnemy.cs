using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] GameObject hitEffecfPrefab;
    Vector2 vel;
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
            // wywołanie funkcji z efektem gdy Player lub Obstacle zostanie trafiony
            ShowHitEffect(transform.position);

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

    // funkcja od efektów uderzenia pocisku. Przyjmuje pozycje czyli miejsce trafienia pocisku pod zmienną Vector2 oraz to co ma być wyświetlone po uderzeniu (zmienna hitEffecfPrefab)
    void ShowHitEffect(Vector2 pos)
    {
        if (hitEffecfPrefab)
        {
            GameObject hitEffect = Instantiate(hitEffecfPrefab, pos, Quaternion.identity);
            Destroy(hitEffect, 1f);
        }
    }
}
