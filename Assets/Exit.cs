using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            FindObjectOfType<AudioManager>().Stop("Theme");
        }
    }
}
