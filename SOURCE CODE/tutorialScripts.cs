using UnityEngine;
using UnityEngine.UI;

public class tutorialScripts : MonoBehaviour
{
    // GAME OBJECTS
    public GameObject firstTutorial;
    public GameObject secondTutorial;
    public GameObject thirdTutorial;
    public GameObject fourthTutorial;
    public GameObject fifthTutorial;
    public GameObject sixthTutorial;
    public GameObject seventhTutorial;
    public GameObject eightTutorial;
    public GameObject ninthTutorial;

    // BUTTONS
    public Button towerIncomeButton;
    public Button towerAttackerButton;
    public Button towerRemoveButton;

    public GameObject blocker;
    // CURRENCY SYSTEM
    public currencySystem currencySystem;
    public enemySpawner enemySpawner;
    // TUTORIAL STAGE
    private int tutorialStage;
    private void Start()
    {
        Time.timeScale = 0;
        firstTutorial.SetActive(true);
        towerAttackerButton.enabled = false;
        towerRemoveButton.enabled = false;
        towerIncomeButton.enabled = false;
    }

    public void Continue()
    {
        tutorialStage++;
        if (tutorialStage == 1)
        {
            firstTutorial.SetActive(false);
            secondTutorial.SetActive(true);
        }

        else if (tutorialStage == 2)
        {
            secondTutorial.SetActive(false);
            thirdTutorial.SetActive(true);
        }

        else if (tutorialStage == 3)
        {
            thirdTutorial.SetActive(false);
            fourthTutorial.SetActive(true);
        }

        else if (tutorialStage == 4)
        {
            towerIncomeButton.enabled = true;
            fourthTutorial.SetActive(false);
            fifthTutorial.SetActive(true);
        }

        else if (tutorialStage == 5)
        {
            towerIncomeButton.interactable = false;
            fifthTutorial.SetActive(false);
            sixthTutorial.SetActive(true);
            Time.timeScale = 1;
        }

        else if (tutorialStage == 6)
        {    
            seventhTutorial.SetActive(false);
            Time.timeScale = 1;
            eightTutorial.SetActive(true);
        }

        else if (tutorialStage == 7)
        {
            seventhTutorial.SetActive(false);
            Time.timeScale = 1;
            towerAttackerButton.enabled = false;
            eightTutorial.SetActive(true);
        }
    }

    bool isPlace1st = false;
    public GameObject[] getTowerCount;
    bool isRunning = true;
    private void Update()
    {
        getTowerCount = GameObject.FindGameObjectsWithTag("towerCollider");
        if (isRunning)
        {
            if (getTowerCount.Length == 1 && currencySystem.currentCurrency == 20 && isPlace1st == false)
            {
                isPlace1st = true;
                towerIncomeButton.enabled = false;
                towerAttackerButton.enabled = true;
                seventhTutorial.SetActive(true);
                Time.timeScale = 0;
                isRunning = false;
                Debug.Log("RUNNING IS NOW " + isRunning);
            }

            else if (getTowerCount.Length == 2 && currencySystem.currentCurrency == 20 && isPlace1st == true)
            {
                blocker.SetActive(false);
                Debug.Log("THIS ONE!"); 
                towerAttackerButton.enabled = true;
                seventhTutorial.SetActive(true);
                Time.timeScale = 0;
                isRunning = false;
            }
        }
    

        if (getTowerCount.Length == 2)
        {
            ninthTutorial.SetActive(false);
        }

        if (getTowerCount.Length == 3)
        {
            isRunning = false;
            Time.timeScale = 1;
            eightTutorial.SetActive(false);
            enemySpawner.isTutorialDone = true;
            enemySpawner.timerIsRunning = false;
            PlayerPrefs.SetInt("fluLevel1", 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "towerCollider")
        {
            if (getTowerCount.Length == 1)
            {
                enemySpawner.timerIsRunning = true;
                sixthTutorial.SetActive(false);
                eightTutorial.SetActive(false);
                Time.timeScale = 1;
            }

            else if (getTowerCount.Length == 2 )
            {
                isRunning = true;
                towerAttackerButton.enabled = false;
                enemySpawner.timerIsRunning = true;
                sixthTutorial.SetActive(false);
                eightTutorial.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyCollider")
        {
            if (getTowerCount.Length == 1)
            {
                eightTutorial.SetActive(false);
                ninthTutorial.SetActive(true);
                Time.timeScale = 0.1f;
                Debug.Log("WHAT ARE YOU DOING ? SPAWN A TOWER NOW!!");
            }
        }
    }
}
