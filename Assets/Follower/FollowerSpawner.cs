using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyFollowerPrefab;
    [SerializeField] [Range(1, 10)] int howManyFollowers = 3;
    [SerializeField] [Range(1f, 5f)] float enemySpeed = 1f;
    [SerializeField] [Range(8f, 20f)] float startSpawningDistance = 14f;
    Transform player;
    bool triggered = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void SpawnEnemyFollower()
    {
        for(int i=0; i < howManyFollowers; i++)
        {
            Vector2 spawnPos = new Vector2(player.position.x + Random.Range(5, 20), Random.Range(-3.5f, 3.5f));
            if (enemyFollowerPrefab != null)
            {
                GameObject a = Instantiate(enemyFollowerPrefab, spawnPos, Quaternion.identity);
                a.GetComponent<EnemyFollower>().Initialize(enemySpeed);
            }
        }
    }

    private void Update()
    {
        if (player)
        {
            if (Mathf.Abs(player.position.x - transform.position.x) < startSpawningDistance)
            {
                if (!triggered)
                {
                    triggered = true;
                    SpawnEnemyFollower();
                }
            }
        }
    }
}


