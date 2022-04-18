using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the next scene isn't set, don't do anything
        if (nextSceneName.Length == 0)
            return;

        if(collision.CompareTag("Player"))
            SceneManager.LoadScene(nextSceneName);
    }
}
