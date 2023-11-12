using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    GameObject target;
    Vector2 targetPos;
    float speed;
    
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void Initialize(float speed_p){
        speed = speed_p;
    }
    void Update()
    {
        if(target != null){ 
            targetPos = target.transform.position;  
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        float angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);         
    }
}
