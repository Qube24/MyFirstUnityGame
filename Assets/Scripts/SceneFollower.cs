using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Also My Script
public class SceneFollower : MonoBehaviour
{
    public static int CurrentLevelSceneIndex { get; private set; }
    private void Awake()
    {
        CurrentLevelSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

}
