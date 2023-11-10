using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] GameObject destroyEffectPrefab;
    [SerializeField] int hp;
    [SerializeField] int hitDamage = 5;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if (destroyEffectPrefab)
            {
                GameObject destroyEffect = Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
                Destroy(destroyEffect, 1f);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.CompareTag("Enemy") || collision.gameObject.transform.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Hp>())
            {
                collision.gameObject.GetComponent<Hp>().TakeDamage(hitDamage);
            }
        }

        if(gameObject.CompareTag("Enemy") || gameObject.CompareTag("Obstacle"))
        {
            if (collision.gameObject.transform.CompareTag("Barrier"))
            {
                if (gameObject.GetComponentInParent<Moon>())
                {
                    Destroy(transform.parent.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
