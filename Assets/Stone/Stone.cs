using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Vector3 shootingDirection;
    Rigidbody2D rb;
    void Start()
    {
        float randX = Random.Range(-7,-12);
        float randY = Random.Range(1.5f,3.5f);
        rb = GetComponent<Rigidbody2D>();
        shootingDirection = new Vector3(randX, randY, 0f);
        rb.AddForce(shootingDirection, ForceMode2D.Impulse);
    }

}
