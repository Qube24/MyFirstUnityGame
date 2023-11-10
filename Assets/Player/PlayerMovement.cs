using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(4,10)] float moveSpeed = 7f;
    Rigidbody2D rb;
    float moveX, moveY;
    Vector2 playerVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        GetUserInput();
    }
    void FixedUpdate() {
        Move();
    }

    void Move(){
        playerVelocity = new Vector2(moveX, moveY).normalized;
        playerVelocity *= moveSpeed;
        rb.velocity = playerVelocity;

        if (playerVelocity != Vector2.zero) {
            float angle = Mathf.Atan2(playerVelocity.y, playerVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    void GetUserInput(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }
}
