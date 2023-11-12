using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShooter : MonoBehaviour
{
    [SerializeField] GameObject StonePrefab;
    [SerializeField] [Range(1f,4f)] float stoneShootingDelay = 2f;
    [SerializeField] [Range(16f, 35f)] float distance = 20f;
    Transform target;
    bool triggered = false;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {

        if (target && Mathf.Abs(target.position.x - transform.position.x) < distance)
        {
            if (!triggered)
            {
                triggered = true;
                StartCoroutine(Shoot());
            }
        }
        else
        {
            triggered = false;
            StopAllCoroutines();
        }
    }

    IEnumerator Shoot()
    {
        if (StonePrefab != null)
        {
            GameObject g = Instantiate(StonePrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(stoneShootingDelay);
            StartCoroutine(Shoot());
        }
    }
}
