using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseScreen;

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);   
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void restartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenuMedicator");
    }

    public void levelMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("stageMenu");      
    }
}
