using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // My script
    void Start()
    {
     DontDestroyOnLoad(gameObject);
    }

}
