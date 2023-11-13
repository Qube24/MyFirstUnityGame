using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] float speed = 1.5f;
    [SerializeField][Range(1f, 180f)] float maxRotation ;
    // dodana zamienna startAngle, która pozwala na zmianę pkt od którego zaczyna się kręcić ksieżyc
    [SerializeField][Range(1f, 360f)] float startAngle ;

    void Update()
    {
         transform.rotation = Quaternion.Euler(0f, 0f, startAngle+(maxRotation * Mathf.Sin(Time.time * speed)));


    }
}
