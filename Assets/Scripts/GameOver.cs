using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// biblioteka obs³uguj¹ca Build Settings
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // publiczna bo musi byæ widoczna z poziomu Unity
    public void RetryGame()
    {
        // My Script
        int currentLevelSceneIndex = SceneFollower.CurrentLevelSceneIndex;
        Debug.Log(currentLevelSceneIndex);
        SceneManager.LoadScene(currentLevelSceneIndex);
      
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
