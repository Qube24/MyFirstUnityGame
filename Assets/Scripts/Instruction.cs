using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// biblioteka obs�uguj�ca Build Settings
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    // publiczna bo musi by� widoczna z poziomu Unity
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

  
}
