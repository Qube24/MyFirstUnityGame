using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletEnemyPrefab;
    [SerializeField] int bulletSpeed;
    [SerializeField] int power;
    [SerializeField] float shootDelay;
    [SerializeField] float startShootingDistance = 14f;
    Transform player;
    bool triggered = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player)
        {
            if (Mathf.Abs(player.position.x - transform.position.x) < startShootingDistance)
            {
                if (!triggered)
                {
                    triggered = true;
                    InvokeRepeating("Shoot", 1f, shootDelay);
                }
            }
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletEnemyPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletEnemy>().Initialize(bulletSpeed, power);
    }
}
