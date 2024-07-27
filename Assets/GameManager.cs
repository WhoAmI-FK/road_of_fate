using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
  //  bool firstTimePressed
    public GameObject pause;

    void Start()
    {
        pause.SetActive(false);
    }

   public void EndGame()
   {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart",4f);
           
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
        if(pause.activeSelf == false)
        {
            Time.timeScale = 1;
        }
    }

   public void ResumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

}
