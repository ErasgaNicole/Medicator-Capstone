using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmScript : MonoBehaviour
{
    private bool isDestroyed = false;
    private void Awake()
    {
        GameObject[] bgmObj = GameObject.FindGameObjectsWithTag("Music");
        if (bgmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        void OnSceneLoad (Scene scene, LoadSceneMode mode)
        {
            if (SceneManager.GetActiveScene().name == "stageMenu")
            {
                if (isDestroyed == false)
                {
                    Destroy(this.gameObject);
                    isDestroyed = true;
                }
            }
        }
    }
}
