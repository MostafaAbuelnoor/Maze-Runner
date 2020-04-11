using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//this script helps load the core game scene from the death menu or the starting menu

public class SceneLoader : MonoBehaviour
{
   
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 5)
        {
            SceneManager.LoadScene(1);
        }
        else if (currentSceneIndex == 6)
        {
            SceneManager.LoadScene(3);
        }
        else if (currentSceneIndex == 4)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings);
        }
    }
}
