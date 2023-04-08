using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class videoPlayer : MonoBehaviour
{
    // bool for cutscene
    private bool isDoneFLU = false;
    private bool isDoneUTI = false;
    private bool isDoneAmoeba = false;
    private bool isDoneCommonCold = false;
    private bool isDoneSorethroat = false;
    private bool isDonePneumonia = false;
    public GameObject touchScreen;
    
    void Start()
    {
        StartCoroutine(videoEnd());
    }

    private void Update()
    {
        if (isDoneFLU == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("cutsceneFlu", 1);
                SceneManager.LoadScene("stageMenu");
            }
        }

        if (isDoneUTI == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("cutsceneUTI", 1);
                SceneManager.LoadScene("stageMenu");
            }
        }

        if (isDoneCommonCold == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("cutsceneCommonCold", 1);
                SceneManager.LoadScene("stageMenu");
            }
        }

        if (isDoneAmoeba == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("cutsceneAmoeba", 1);
                SceneManager.LoadScene("stageMenu");
            }
        }

        if (isDoneSorethroat == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("cutsceneSorethroat", 1);
                SceneManager.LoadScene("stageMenu");
            }
        }

        if (isDonePneumonia == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("cutscenePneumonia", 1);
                SceneManager.LoadScene("stageMenu");
            }
        }
    }

    IEnumerator videoEnd()
    {
        if (SceneManager.GetActiveScene().name == "FLUCutscene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(32);
            touchScreen.SetActive(true);
            isDoneFLU = true;
        }

        if (SceneManager.GetActiveScene().name == "UTICutscene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(29);
            touchScreen.SetActive(true);
            isDoneUTI = true;
        }

        if (SceneManager.GetActiveScene().name == "AmoebiasisCutscene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(32);
            touchScreen.SetActive(true);
            isDoneAmoeba = true;
        }

        if (SceneManager.GetActiveScene().name == "CommonColdCutscene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(31);
            touchScreen.SetActive(true);
            isDoneCommonCold = true;
        }

        if (SceneManager.GetActiveScene().name == "SorethroatCutscene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(30);
            touchScreen.SetActive(true);
            isDoneSorethroat = true;
        }

        if (SceneManager.GetActiveScene().name == "PneumoniaCutscene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(31);
            touchScreen.SetActive(true);
            isDonePneumonia = true;
        }
    }
}
