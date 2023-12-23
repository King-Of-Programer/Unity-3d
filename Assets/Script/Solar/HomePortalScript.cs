using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePortalScript : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine to load the new scene
        StartCoroutine(LoadNewSceneAfterDelay());
    }

    IEnumerator LoadNewSceneAfterDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Load the new scene
        SceneManager.LoadScene("Labirint"); // Replace with your scene's name
    }
}
