using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class pagesScript : MonoBehaviour
{
    // Objects for disable
    public Sprite disabledStage;
    public Sprite enabledStage;
    public Sprite bossEnabledSprite;

    // Array of stages in COMMON ILLNESSES
    public Image[] fluStages;
    public Button[] fluStagesButton;

    public Image[] utiStages;
    public Button[] utiStagesButton;

    public Image[] amoeStages;
    public Button[] amoeStagesButton;

    public Image[] commonStages;
    public Button[] commonStagesButton;

    public Image[] soreStages;
    public Button[] soreStagesButton;

    public Image[] pneumoniaStages;
    public Button[] pneumoniaStagesButton;

    // Object for Trivia
    public GameObject triviaObject;
    public GameObject quizObject;
    public GameObject tutorialObject;
    public GameObject cutsceneObject;
    public TMP_Text triviaText;

    // LEVELS
    public GameObject fluLevels;
    public GameObject utiLevels;
    public GameObject amoeLevels;
    public GameObject commonLevels;
    public GameObject soreLevels;
    public GameObject pneumoniaLevels;

    private void Start()
    {
        stageSelector();
        playTutorial();
        stageActive();
        playCutsceneTutorial();
    }
    private void stageSelector()
    {
        Time.timeScale = 1;
        disableStageFunction();
        // FLU
        if (PlayerPrefs.GetInt("fluLevel1") == 1)
        {
            fluStages[0].sprite = enabledStage;
            fluStagesButton[0].interactable = true;
        }

        if (PlayerPrefs.GetInt("fluLevel2") == 2)
        {
            fluStages[1].sprite = enabledStage;
            fluStagesButton[1].interactable = true;
        }

        if (PlayerPrefs.GetInt("fluLevel3") == 3)
        {
            fluStages[2].sprite = enabledStage;
            fluStagesButton[2].interactable = true;
        }

        if (PlayerPrefs.GetInt("fluLevel4") == 4)
        {
            fluStages[3].sprite = enabledStage;
            fluStagesButton[3].interactable = true;
        }

        if (PlayerPrefs.GetInt("fluLevel5") == 5)
        {
            fluStages[4].sprite = bossEnabledSprite;
            fluStagesButton[4].interactable = true;
        }

        // UTI

        if (PlayerPrefs.GetInt("utiLevel1") == 1)
        {
            utiStages[0].sprite = enabledStage;
            utiStagesButton[0].interactable = true;
        }

        if (PlayerPrefs.GetInt("utiLevel2") == 2)
        {
            utiStages[1].sprite = enabledStage;
            utiStagesButton[1].interactable = true;
        }

        if (PlayerPrefs.GetInt("utiLevel3") == 3)
        {
            utiStages[2].sprite = enabledStage;
            utiStagesButton[2].interactable = true;
        }

        if (PlayerPrefs.GetInt("utiLevel4") == 4)
        {
            utiStages[3].sprite = enabledStage;
            utiStagesButton[3].interactable = true;
        }

        if (PlayerPrefs.GetInt("utiLevel5") == 5)
        {
            utiStages[4].sprite = bossEnabledSprite;
            utiStagesButton[4].interactable = true;
        }

        // AMOE

        if (PlayerPrefs.GetInt("amoeLevel1") == 1)
        {
            amoeStages[0].sprite = enabledStage;
            amoeStagesButton[0].interactable = true;
        }

        if (PlayerPrefs.GetInt("amoeLevel2") == 2)
        {
            amoeStages[1].sprite = enabledStage;
            amoeStagesButton[1].interactable = true;
        }

        if (PlayerPrefs.GetInt("amoeLevel3") == 3)
        {
            amoeStages[2].sprite = enabledStage;
            amoeStagesButton[2].interactable = true;
        }

        if (PlayerPrefs.GetInt("amoeLevel4") == 4)
        {
            amoeStages[3].sprite = enabledStage;
            amoeStagesButton[3].interactable = true;
        }

        if (PlayerPrefs.GetInt("amoeLevel5") == 5)
        {
            amoeStages[4].sprite = bossEnabledSprite;
            amoeStagesButton[4].interactable = true;
        }

        // COMMON COLD

        if (PlayerPrefs.GetInt("commonLevel1") == 1)
        {
            commonStages[0].sprite = enabledStage;
            commonStagesButton[0].interactable = true;
        }

        if (PlayerPrefs.GetInt("commonLevel2") == 2)
        {
            commonStages[1].sprite = enabledStage;
            commonStagesButton[1].interactable = true;
        }

        if (PlayerPrefs.GetInt("commonLevel3") == 3)
        {
            commonStages[2].sprite = enabledStage;
            commonStagesButton[2].interactable = true;
        }

        if (PlayerPrefs.GetInt("commonLevel4") == 4)
        {
            commonStages[3].sprite = enabledStage;
            commonStagesButton[3].interactable = true;
        }

        if (PlayerPrefs.GetInt("commonLevel5") == 5)
        {
            commonStages[4].sprite = bossEnabledSprite;
            commonStagesButton[4].interactable = true;
        }

        // SORE THROAT

        if (PlayerPrefs.GetInt("soreLevel1") == 1)
        {
            soreStages[0].sprite = enabledStage;
            soreStagesButton[0].interactable = true;
        }

        if (PlayerPrefs.GetInt("soreLevel2") == 2)
        {
            soreStages[1].sprite = enabledStage;
            soreStagesButton[1].interactable = true;
        }

        if (PlayerPrefs.GetInt("soreLevel3") == 3)
        {
            soreStages[2].sprite = enabledStage;
            soreStagesButton[2].interactable = true;
        }

        if (PlayerPrefs.GetInt("soreLevel4") == 4)
        {
            soreStages[3].sprite = enabledStage;
            soreStagesButton[3].interactable = true;
        }

        if (PlayerPrefs.GetInt("soreLevel5") == 5)
        {
            soreStages[4].sprite = bossEnabledSprite;
            soreStagesButton[4].interactable = true;
        }

        // PNEUMONIA

        if (PlayerPrefs.GetInt("pneumoniaLevel1") == 1)
        {
            pneumoniaStages[0].sprite = enabledStage;
            pneumoniaStagesButton[0].interactable = true;
        }

        if (PlayerPrefs.GetInt("pneumoniaLevel2") == 2)
        {
            pneumoniaStages[1].sprite = enabledStage;
            pneumoniaStagesButton[1].interactable = true;
        }

        if (PlayerPrefs.GetInt("pneumoniaLevel3") == 3)
        {
            pneumoniaStages[2].sprite = enabledStage;
            pneumoniaStagesButton[2].interactable = true;
        }

        if (PlayerPrefs.GetInt("pneumoniaLevel4") == 4)
        {
            pneumoniaStages[3].sprite = enabledStage;
            pneumoniaStagesButton[3].interactable = true;
        }

        if (PlayerPrefs.GetInt("pneumoniaLevel5") == 5)
        {
            pneumoniaStages[4].sprite = bossEnabledSprite;
            pneumoniaStagesButton[4].interactable = true;
        }
    }

    public void completeTutorial()
    {
        PlayerPrefs.SetInt("fluLevel1", 1);
        PlayerPrefs.SetInt("fluLevel1Win", 1);
        stageSelector();
    }

    // IF PLAYER PREFS IS LEVEL WIN THEN NO LOADING
    public void fluStage1()
    {
        if (PlayerPrefs.GetInt("fluLevel1Win") == 1)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Flu vaccination cause antibodies to develop in the body, and provide protection against flu ilness";
        }

        else
        {
            SceneManager.LoadScene("fluLevel1");
        }
    }

    public void fluStage2()
    {
        if (PlayerPrefs.GetInt("fluLevel2Win") == 2)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that influenza is more common in children than adults.";
        }

        else
        {
            SceneManager.LoadScene("fluLevel2");
        }
    }

    public void fluStage3()
    {
        if (PlayerPrefs.GetInt("fluLevel3Win") == 3)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that influenza or also known as flu is cause most illness during the rainy season.";
        }

        else
        {
            SceneManager.LoadScene("fluLevel3");
        }
    }

    public void fluStage4()
    {
        if (PlayerPrefs.GetInt("fluLevel4Win") == 4)
        { 
            triviaObject.SetActive(true);
            triviaText.text = "Did you know washing your hands often with soap can decrease the change of getting the flu.";
        }

        else
        {
            SceneManager.LoadScene("fluLevel4");
        }
    }

    public void fluStage5()
    {
        if (PlayerPrefs.GetInt("fluLevel5Win") == 5)
        {
            quizObject.SetActive(true);
            triviaObject.SetActive(true);
            triviaText.text = "Flu symptoms can start unexpectedly.";
        }

        else
        {
            SceneManager.LoadScene("fluLevel5");
        }
    }

    public void utiStage1()
    {
        if (PlayerPrefs.GetInt("utiLevel1Win") == 1)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that the meaning of UTI is Urinary Tract Infection.";
        }

        else
        {
            SceneManager.LoadScene("utiLevel1");
        }
    }

    public void utiStage2()
    {
        if (PlayerPrefs.GetInt("utiLevel2Win") == 2)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Women are more likely to develop UTIs than men.";
        }

        else
        {
            SceneManager.LoadScene("utiLevel2");
        }
    }

    public void utiStage3()
    {
        if (PlayerPrefs.GetInt("utiLevel3Win") == 3)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Drinking plenty of water can help to prevent UTI.";
        }

        else
        {
            SceneManager.LoadScene("utiLevel3");
        }
    }
    public void utiStage4()
    {
        if (PlayerPrefs.GetInt("utiLevel4Win") == 4)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know when you have an UTI, your urine will become foul-smelling.";
        }

        else
        {
            SceneManager.LoadScene("utiLevel4");
        }
    }

    public void utiStage5()
    {
        if (PlayerPrefs.GetInt("utiLevel5Win") == 5)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Urinate often to flush the UTI bacterias.";
        }

        else
        {
            SceneManager.LoadScene("utiLevel5");
        }
    }

    // AMOEBIASIS
    public void amoebaStage1()
    {
        if (PlayerPrefs.GetInt("amoeLevel1Win") == 1)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that if you have amoebiasis, you must drink plenty of fluids, such as water, to avoid dehydration.";
        }

        else
        {
            SceneManager.LoadScene("amoebiasisLevel1");
        }
    }

    public void amoebaStage2()
    {
        if (PlayerPrefs.GetInt("amoeLevel2Win") == 2)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Amoebiasis can be transmitted through contaminated water containing feces..";
        }

        else
        {
            SceneManager.LoadScene("amoebiasisLevel2");
        }
    }

    public void amoebaStage3()
    {
        if (PlayerPrefs.GetInt("amoeLevel3Win") == 3)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that diarrhea is the most common symptom of amoebiasis.";
        }

        else
        {
            SceneManager.LoadScene("amoebiasisLevel3");
        }
    }

    public void amoebaStage4()
    {
        if (PlayerPrefs.GetInt("amoeLevel4Win") == 4)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that people with amoebiasis can lose weight.";
        }

        else
        {
            SceneManager.LoadScene("amoebiasisLevel4");
        }
    }

    public void amoebaStage5()
    {
        if (PlayerPrefs.GetInt("amoeLevel5Win") == 5)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that stomach cramps are a symptom of amoebiasis.";
        }

        else
        {
            SceneManager.LoadScene("amoebiasisLevel5");
        }
    }

    // COMMON COLD
    public void commonStage1()
    {
        if (PlayerPrefs.GetInt("commonLevel1Win") == 1)
        {
            triviaObject.SetActive(true);
            triviaText.text = "When you have a common cold, your nose becomes stuffy..";
        }

        else
        {
            SceneManager.LoadScene("commonColdLevel1");
        }
    }

    public void commonStage2()
    {
        if (PlayerPrefs.GetInt("commonLevel2Win") == 2)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that common-cold is usually harmless.";
        }

        else
        {
            SceneManager.LoadScene("commonColdLevel2");
        }
    }

    public void commonStage3()
    {
        if (PlayerPrefs.GetInt("commonLevel3Win") == 3)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that resting can help you recover quickly from a common cold.";
        }

        else
        {
            SceneManager.LoadScene("commonColdLevel3");
        }
    }

    public void commonStage4()
    {
        if (PlayerPrefs.GetInt("commonLevel4Win") == 4)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that antibiotics are not always required for a common cold.";
        }

        else
        {
            SceneManager.LoadScene("commonColdLevel4");
        }
    }

    public void commonStage5()
    {
        if (PlayerPrefs.GetInt("commonLevel5Win") == 5)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Drinking plenty of fluids will aid your recovery..";
        }

        else
        {
            SceneManager.LoadScene("commonColdLevel5");
        }
    }

    // SORE THROAT
    public void soreStage1()
    {
        if (PlayerPrefs.GetInt("soreLevel1Win") == 1)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that sore throat can start quickly.";
        }

        else
        {
            SceneManager.LoadScene("soreThroatLevel1");
        }
    }

    public void soreStage2()
    {
        if (PlayerPrefs.GetInt("soreLevel2Win") == 2)
        {
            triviaObject.SetActive(true);
            triviaText.text = "A sore throat is irritation of the throat.";
        }

        else
        {
            SceneManager.LoadScene("soreThroatLevel2");
        }
    }

    public void soreStage3()
    {
        if (PlayerPrefs.GetInt("soreLevel3Win") == 3)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that drinking gargle with salt water can help you to feel better.";
        }

        else
        {
            SceneManager.LoadScene("soreThroatLevel3");
        }
    }

    public void soreStage4()
    {
        if (PlayerPrefs.GetInt("soreLevel4Win") == 4)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Warm beverages and plenty fluids are useful drinks.";
        }

        else
        {
            SceneManager.LoadScene("soreThroatLevel4");
        }
    }

    public void soreStage5()
    {
        if (PlayerPrefs.GetInt("soreLevel5Win") == 5)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that when you encounter pain when swallowing, you have a sore throat.";
        }

        else
        {
            SceneManager.LoadScene("soreThroatLevel5");
        }
    }

    public void pneumoniaStage1()
    {
        if (PlayerPrefs.GetInt("pneumoniaLevel1Win") == 1)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that Pneumonia is a lung infection.";
        }

        else
        {
            SceneManager.LoadScene("PneumoniaLevel1");
        }
    }

    public void pneumoniaStage2()
    {
        if (PlayerPrefs.GetInt("pneumoniaLevel2Win") == 2)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that your chest might be in pain when you cough.";
        }

        else
        {
            SceneManager.LoadScene("PneumoniaLevel2");
        }
    }

    public void pneumoniaStage3()
    {
        if (PlayerPrefs.GetInt("pneumoniaLevel3Win") == 3)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Drinking enough water will help you recover.";
        }

        else
        {
            SceneManager.LoadScene("PneumoniaLevel3");
        }
    }

    public void pneumoniaStage4()
    {
        if (PlayerPrefs.GetInt("pneumoniaLevel4Win") == 4)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that immune system can fight against Pneumonia without taking any medicine.";
        }

        else
        {
            SceneManager.LoadScene("PneumoniaLevel4");
        }
    }

    public void pneumoniaStage5()
    {
        if (PlayerPrefs.GetInt("pneumoniaLevel5Win") == 5)
        {
            triviaObject.SetActive(true);
            triviaText.text = "Did you know that lungs are affected when having Pneumonia .";
        }

        else
        {
            SceneManager.LoadScene("PneumoniaLevel5");
        }
    }


    private void disableStageFunction()
    {
        // FLU
        foreach (Image fluImage in fluStages)
        {
            fluImage.sprite = disabledStage;
        }

        foreach (Button fluButtons in fluStagesButton)
        {
            fluButtons.interactable = false;
        }

        // UTI
        foreach (Image utiImage in utiStages)
        {
            utiImage.sprite = disabledStage;
        }

        foreach (Button utiButtons in utiStagesButton)
        {
            utiButtons.interactable = false;
        }

        // AMOEBIASIS
        foreach (Image amoeImage in amoeStages)
        {
            amoeImage.sprite = disabledStage;
        }

        foreach (Button amoeButton in amoeStagesButton)
        {
            amoeButton.interactable = false;
        }

        // COMMON COLD
        foreach (Image commonImage in commonStages)
        {
            commonImage.sprite = disabledStage;
        }

        foreach (Button commonButton in commonStagesButton)
        {
            commonButton.interactable = false;
        }

        // SORE THROAT
        foreach (Image soreImage in soreStages)
        {
            soreImage.sprite = disabledStage;
        }

        foreach (Button soreButton in soreStagesButton)
        {
            soreButton.interactable = false;
        }

        // PNEUMONIA
        foreach (Image pneumoniaImage in pneumoniaStages)
        {
            pneumoniaImage.sprite = disabledStage;
        }

        foreach (Button pneumoniaButton in pneumoniaStagesButton)
        {
            pneumoniaButton.interactable = false;
        }
    }

    public GameObject debugModeObject;
    public GameObject debugModeUnlockables;
    bool isDebug = false;
    public TMP_InputField debugmodeInputField;

    private int debugCounter = 0;
    public void debugMode()
    {
        debugCounter++;
        if (debugCounter == 5)
        {
            if (isDebug == false)
            {
                debugModeObject.SetActive(true);
                isDebug = true;
                debugCounter = 0;
            }

            else
            {
                debugModeObject.SetActive(false);
                isDebug = false;
               
            }
        }
    }

    public void checkInputField()
    {
        if (debugmodeInputField.text == "Debug" || debugmodeInputField.text == "debug")
        {
            debugModeUnlockables.SetActive(true);
            debugModeObject.SetActive(false);
        }

        else
        {
            debugmodeInputField.text = "";
            debugModeObject.SetActive(false);
        }
    }
    public void completeAllStages()
    {
        Debug.Log("COMPLETE");
        // FLU
        PlayerPrefs.SetInt("fluLevel1", 1);
        PlayerPrefs.SetInt("fluLevel1Win", 1);
        PlayerPrefs.SetInt("fluLevel2", 2);
        PlayerPrefs.SetInt("fluLevel2Win", 2);
        PlayerPrefs.SetInt("fluLevel3", 3);
        PlayerPrefs.SetInt("fluLevel3Win", 3);
        PlayerPrefs.SetInt("fluLevel4", 4);
        PlayerPrefs.SetInt("fluLevel4Win", 4);
        PlayerPrefs.SetInt("fluLevel5", 5);
        PlayerPrefs.SetInt("fluLevel5Win", 5);

        // UTI
        PlayerPrefs.SetInt("utiLevel1", 1);
        PlayerPrefs.SetInt("utiLevel1Win", 1);
        PlayerPrefs.SetInt("utiLevel2", 2);
        PlayerPrefs.SetInt("utiLevel2Win", 2);
        PlayerPrefs.SetInt("utiLevel3", 3);
        PlayerPrefs.SetInt("utiLevel3Win", 3);
        PlayerPrefs.SetInt("utiLevel4", 4);
        PlayerPrefs.SetInt("utiLevel4Win", 4);
        PlayerPrefs.SetInt("utiLevel5", 5);
        PlayerPrefs.SetInt("utiLevel5Win", 5);

        // AMOE
        PlayerPrefs.SetInt("amoeLevel1", 1);
        PlayerPrefs.SetInt("amoeLevel1Win", 1);
        PlayerPrefs.SetInt("amoeLevel2", 2);
        PlayerPrefs.SetInt("amoeLevel2Win", 2);
        PlayerPrefs.SetInt("amoeLevel3", 3);
        PlayerPrefs.SetInt("amoeLevel3Win", 3);
        PlayerPrefs.SetInt("amoeLevel4", 4);
        PlayerPrefs.SetInt("amoeLevel4Win", 4);
        PlayerPrefs.SetInt("amoeLevel5", 5);
        PlayerPrefs.SetInt("amoeLevel5Win", 5);

        // COMMON COLD
        PlayerPrefs.SetInt("commonLevel1", 1);
        PlayerPrefs.SetInt("commonLevel1Win", 1);
        PlayerPrefs.SetInt("commonLevel2", 2);
        PlayerPrefs.SetInt("commonLevel2Win", 2);
        PlayerPrefs.SetInt("commonLevel3", 3);
        PlayerPrefs.SetInt("commonLevel3Win", 3);
        PlayerPrefs.SetInt("commonLevel4", 4);
        PlayerPrefs.SetInt("commonLevel4Win", 4);
        PlayerPrefs.SetInt("commonLevel5", 5);
        PlayerPrefs.SetInt("commonLevel5Win", 5);

        // SORE THROAT
        PlayerPrefs.SetInt("soreLevel1", 1);
        PlayerPrefs.SetInt("soreLevel1Win", 1);
        PlayerPrefs.SetInt("soreLevel2", 2);
        PlayerPrefs.SetInt("soreLevel2Win", 2);
        PlayerPrefs.SetInt("soreLevel3", 3);
        PlayerPrefs.SetInt("soreLevel3Win", 3);
        PlayerPrefs.SetInt("soreLevel4", 4);
        PlayerPrefs.SetInt("soreLevel4Win", 4);
        PlayerPrefs.SetInt("soreLevel5", 5);
        PlayerPrefs.SetInt("soreLevel5Win", 5);

        // PNEUMONIA
        PlayerPrefs.SetInt("pneumoniaLevel1", 1);
        PlayerPrefs.SetInt("pneumoniaLevel1Win", 1);
        PlayerPrefs.SetInt("pneumoniaLevel2", 2);
        PlayerPrefs.SetInt("pneumoniaLevel2Win", 2);
        PlayerPrefs.SetInt("pneumoniaLevel3", 3);
        PlayerPrefs.SetInt("pneumoniaLevel3Win", 3);
        PlayerPrefs.SetInt("pneumoniaLevel4", 4);
        PlayerPrefs.SetInt("pneumoniaLevel4Win", 4);
        PlayerPrefs.SetInt("pneumoniaLevel5", 5);
        PlayerPrefs.SetInt("pneumoniaLevel5Win", 5);
        stageSelector();
    }

    public void unlockAllStages()
    {
        foreach (Button fluButtons in fluStagesButton)
        {
            fluButtons.interactable = true;
        }

        foreach (Image fluImage in fluStages)
        {
            fluImage.sprite = enabledStage;
        }
        fluStages[4].sprite = bossEnabledSprite;

        foreach (Button utiButtons in utiStagesButton)
        {
            utiButtons.interactable = true;
        }

        foreach (Image utiImage in utiStages)
        {
            utiImage.sprite = enabledStage;
        }
        utiStages[4].sprite = bossEnabledSprite;

        foreach (Button amoeButtons in amoeStagesButton)
        {
            amoeButtons.interactable = true;
        }

        foreach (Image amoeImages in amoeStages)
        {
            amoeImages.sprite = enabledStage;
        }
        amoeStages[4].sprite = bossEnabledSprite;

        foreach (Button commonButtons in commonStagesButton)
        {
            commonButtons.interactable = true;
        }

        foreach (Image commonImages in commonStages)
        {
            commonImages.sprite = enabledStage;
        }
        commonStages[4].sprite = bossEnabledSprite;
        foreach (Button soreButtons in soreStagesButton)
        {
            soreButtons.interactable = true;
        }

        foreach (Image soreImages in soreStages)
        {
            soreImages.sprite = enabledStage;
        }
        soreStages[4].sprite = bossEnabledSprite;
        foreach (Button pneumoniaButtons in pneumoniaStagesButton)
        {
            pneumoniaButtons.interactable = true;
        }

        foreach (Image pneumoniaImages in pneumoniaStages)
        {
            pneumoniaImages.sprite = enabledStage;
        }
        pneumoniaStages[4].sprite = bossEnabledSprite;
        //FLU
        PlayerPrefs.SetInt("fluLevel1", 1);
        PlayerPrefs.SetInt("fluLevel2", 2);
        PlayerPrefs.SetInt("fluLevel3", 3);
        PlayerPrefs.SetInt("fluLevel4", 4);
        PlayerPrefs.SetInt("fluLevel5", 5);
        // UTI
        PlayerPrefs.SetInt("utiLevel1", 1);
        PlayerPrefs.SetInt("utiLevel2", 2);
        PlayerPrefs.SetInt("utiLevel3", 3);
        PlayerPrefs.SetInt("utiLevel4", 4);
        PlayerPrefs.SetInt("utiLevel5", 5);

        //AMOEBA
        PlayerPrefs.SetInt("amoeLevel1", 1);
        PlayerPrefs.SetInt("amoeLevel2", 2);
        PlayerPrefs.SetInt("amoeLevel3", 3);
        PlayerPrefs.SetInt("amoeLevel4", 4);
        PlayerPrefs.SetInt("amoeLevel5", 5);
        // COMMON LEVEL
        PlayerPrefs.SetInt("commonLevel1", 1);
        PlayerPrefs.SetInt("commonLevel2", 2);
        PlayerPrefs.SetInt("commonLevel3", 3);
        PlayerPrefs.SetInt("commonLevel4", 4);
        PlayerPrefs.SetInt("commonLevel5", 5);
        // SORE THROAT
        PlayerPrefs.SetInt("soreLevel1", 1);
        PlayerPrefs.SetInt("soreLevel2", 2);
        PlayerPrefs.SetInt("soreLevel3", 3);
        PlayerPrefs.SetInt("soreLevel4", 4);
        PlayerPrefs.SetInt("soreLevel5", 5);

        // PNEUMONIA
        PlayerPrefs.SetInt("pneumoniaLevel1", 1);
        PlayerPrefs.SetInt("pneumoniaLevel2", 2);
        PlayerPrefs.SetInt("pneumoniaLevel3", 3);
        PlayerPrefs.SetInt("pneumoniaLevel4", 4);
        PlayerPrefs.SetInt("pneumoniaLevel5", 5);

        commonStages[4].sprite = bossEnabledSprite;
    }

    public void playCutscene(int whatStage)
    {
        if (whatStage == 1)
        {
            if (PlayerPrefs.GetInt("cutsceneFlu") != 1)
            {
                SceneManager.LoadScene("FLUCutscene");
            }
            else
            {
                PlayerPrefs.SetInt("FLUStage", 1);
                fluLevels.SetActive(true);
            }
        }

        if (whatStage == 2)
        {
            if (PlayerPrefs.GetInt("cutsceneUTI") != 1)
            {
                SceneManager.LoadScene("UTICutscene");
            }
            else
            {
                PlayerPrefs.SetInt("UTIStage", 1);
                utiLevels.SetActive(true);
            }
        }

        if (whatStage == 3)
        {
            if (PlayerPrefs.GetInt("cutsceneAmoeba") != 1)
            {
                SceneManager.LoadScene("AmoebiasisCutscene");
            }
            else
            {
                PlayerPrefs.SetInt("AmoeStage", 1);
                amoeLevels.SetActive(true);
            }
        }

        if (whatStage == 4)
        {
            if (PlayerPrefs.GetInt("cutsceneCommonCold") != 1)
            {
                SceneManager.LoadScene("CommonColdCutscene");
            }
            else
            {
                PlayerPrefs.SetInt("CommonStage", 1);
                commonLevels.SetActive(true);
            }
        }

        if (whatStage == 5)
        {
            if (PlayerPrefs.GetInt("cutsceneSorethroat") != 1)
            {
                SceneManager.LoadScene("SorethroatCutscene");
            }
            else
            {
                PlayerPrefs.SetInt("SoreStage", 1);
                soreLevels.SetActive(true);
            }
        }

        if (whatStage == 6)
        {
            if (PlayerPrefs.GetInt("cutscenePneumonia") != 1)
            {
                SceneManager.LoadScene("PneumoniaCutscene");
            }
            else
            {
                PlayerPrefs.SetInt("PneumoniaStage", 1);
                pneumoniaLevels.SetActive(true);
            }
        }
    }

    public void exitLevel()
    {
        // OBJECTS
        triviaObject.SetActive(false);
        fluLevels.SetActive(false);
        utiLevels.SetActive(false);
        amoeLevels.SetActive(false);
        commonLevels.SetActive(false);
        pneumoniaLevels.SetActive(false);

        // Player prefs for close
        PlayerPrefs.SetInt("UTIStage", 2);
        PlayerPrefs.SetInt("FLUStage", 2);
        PlayerPrefs.SetInt("AmoeStage", 2);
        PlayerPrefs.SetInt("CommonStage", 2);
        PlayerPrefs.SetInt("SoreStage", 2);
        PlayerPrefs.SetInt("PneumoniaStage", 2);
        stageActive();
    }

    private void playTutorial()
    { 
        if (PlayerPrefs.GetInt("fluLevel1") == 1)
        {
            tutorialObject.SetActive(false);
        }
    }

    private void playCutsceneTutorial()
    {
        if (PlayerPrefs.GetInt("cutSceneTutorial") == 1)
        {
            cutsceneObject.SetActive(false);
        }
    }

    public void clickContinueCutscene()
    {
        PlayerPrefs.SetInt("cutSceneTutorial", 1);
        cutsceneObject.SetActive(false);
    }

    public void stageActive()
    {
        if (PlayerPrefs.GetInt("FLUStage") == 1)
        {
            fluLevels.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("UTIStage") == 1)
        {
            utiLevels.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("AmoeStage") == 1)
        {
            amoeLevels.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("CommonStage") == 1)
        {
            commonLevels.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("SoreStage") == 1)
        {
            soreLevels.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("PneumoniaStage") == 1)
        {
            pneumoniaLevels.SetActive(true);
        }

        else
        {
            utiLevels.SetActive(false);
            fluLevels.SetActive(false);
            amoeLevels.SetActive(false);
            commonLevels.SetActive(false);
            soreLevels.SetActive(false);
            pneumoniaLevels.SetActive(false);
        }
    }
}
