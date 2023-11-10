using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    float targetOffsetX = 5.5f;

    void FixedUpdate()
    {
        if (target != null)
        {
            if (target.transform.position.x > transform.position.x - (targetOffsetX - 0.5f))
            {
                FollowWithReverseOption();
            }
        }
    }

    void FollowWithReverseOption()
    {
        if (target != null)
        {
            // Follow the target on x axis only
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + targetOffsetX, transform.position.y, transform.position.z), 0.1f);
        }
    }
}
