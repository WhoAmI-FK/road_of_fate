using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(int Level)
    {
        if(SceneManager.GetActiveScene().name != "SampleScene")
            PlayerMovement.newScene = true;

        SceneManager.LoadScene(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
