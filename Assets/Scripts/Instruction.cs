using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// biblioteka obs³uguj¹ca Build Settings
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    // publiczna bo musi byæ widoczna z poziomu Unity
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

  
}
