using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooter : MonoBehaviour
{
    Transform target;
    Vector2 targetPos;
    bool triggered = false;

    [SerializeField] GameObject BulletPrefab;
    Transform aimPos;
    Transform canon;
    [SerializeField] [Range(1, 10)] int power = 1;
    [SerializeField] [Range(1, 10)] int NoOfBulletsInSeries = 4;
    [SerializeField] [Range(0.1f, 1f)] float delayBetweenBullets = 0.2f;
    [SerializeField] [Range(0.5f, 5f)] float delayBetweenSeries = 1.2f;
    [SerializeField] [Range(5, 14)] int distance = 10;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canon = gameObject.transform.Find("canon");
        aimPos = canon.transform.Find("aim").transform;
    }

    void Update()
    {
        if (target != null)
        {
            targetPos = target.transform.position - transform.position;
        }
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        canon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        canon.transform.rotation *= Quaternion.Euler(new Vector3(1f, 1f, 1.1f));

        if (Mathf.Abs(targetPos.x) < distance)
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
        for (int i = 0; i < NoOfBulletsInSeries; i++)
        {
            Vector3 bulletDir = aimPos.transform.position - canon.transform.position;
            GameObject g = Instantiate(BulletPrefab, aimPos.transform.position, Quaternion.identity);
            g.GetComponent<CanonBullet>().Initialize(bulletDir, power);
            yield return new WaitForSeconds(delayBetweenBullets);
        }
        yield return new WaitForSeconds(delayBetweenSeries);
        StartCoroutine(Shoot());
    }
}
