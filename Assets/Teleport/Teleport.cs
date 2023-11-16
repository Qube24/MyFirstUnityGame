using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            int sceneTotal = SceneManager.sceneCountInBuildSettings;
            int activeScene = SceneManager.GetActiveScene().buildIndex;
  

            if (activeScene < sceneTotal - 1)
            {
                SceneManager.LoadScene(++activeScene);
            }
            else
            {
                SceneManager.LoadScene(5);
            }
        }

    }


}
