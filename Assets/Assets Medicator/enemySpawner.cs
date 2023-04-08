using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawner : MonoBehaviour
{
    // FIELDS
    public static enemySpawner enemyInstance;

    // FIELDS FOR TIMERS
    public float timeRemaining;
    public float maxTime;
    [HideInInspector] public bool timerIsRunning = false;

    // FIELDS FOR ENEMIES COMING PANEL
    public GameObject enemiesComing;
    public GameObject hugeWave;

    // OBJECTS FOR UI
    public GameObject victoryScreen;
    public GameObject timerBar;

    // FIELDS FOR ENEMY COUNTER
    private GameObject[] getCount;
    // MY VARIABLES
    public Image healthBar;
    public TMP_Text timeText;

    // STAGE INDICATOR
    public int stageLevel;
    void Awake()
    {
        enemyInstance = this;
    }
    // ENEMY PREFABS
    public List<GameObject> enemyPrefabs;

    // ENEMY SPAWN ROOT POINTS
    public List<Transform> enemySpawnPoints;

    // ENEMY SPAWN INTERVAL
    public float spawnInterval = 5f;
    [HideInInspector] public bool isTutorialDone = false;

    // spawnEnemyVariables
    int enemyMinSpawn = 0;
    int enemyMaxSpawn = 0;
    // FUNCTION FOR ENEMY SPAWN

    private void Start()
    {  
        if (SceneManager.GetActiveScene().name == "tutorialLevel")
        {
            // TuTORIAL STAGE
        }
        else
        {
            timerIsRunning = true;
            isTutorialDone = true;
            // NOT TUTORIAL STAGE
        }
    }
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("enemyCollider");
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                currentWave++;
                stageIndicator();
            }
        }

        else if (getCount.Length == 0 && timerIsRunning == false && isTutorialDone == true)
        {
            winStage();
            StartCoroutine(victoryDelay());     
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timerBar != null)
        {
            healthBar.fillAmount = timeRemaining / maxTime;
        }
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}", seconds);
    }

    IEnumerator victoryDelay()
    {
        yield return new WaitForSeconds(3);
        if (getCount.Length == 0)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(victoryDelay());
        }
    }

    int currentWave = 0;
    private void stageIndicator()
    {
        if (stageLevel == 0)
        {
            waveIndicatorTutorial();
        }

        else if (stageLevel == 1)
        {
            waveIndicatorLevel1();
        }

        else if (stageLevel == 2)
        {
            waveIndicatorLevel2();
        }

        else if (stageLevel == 3)
        {
            waveIndicatorLevel3();
        }

        else if (stageLevel == 4)
        {
            waveIndicatorLevel4();
        }

        else if (stageLevel == 5)
        {
            waveIndicatorLevel5();
        }

        else if (stageLevel == 6)
        {
            waveIndicatorLevel6();
        }

        else if (stageLevel == 7)
        {
            waveIndicatorLevel7();
        }

        else if (stageLevel == 8)
        {
            waveIndicatorLevel8();
        }

        else if (stageLevel == 9)
        {
            waveIndicatorLevel9();
        }

        else if (stageLevel == 10)
        {
            waveIndicatorLevel10();
        }

        else if (stageLevel == 11)
        {
            waveIndicatorLevel11();
        }

        else if (stageLevel == 12)
        {
            waveIndicatorLevel12();
        }

        else if (stageLevel == 13)
        {
            waveIndicatorLevel13();
        }

        else if (stageLevel == 14)
        {
            waveIndicatorLevel14();
        }

        else if (stageLevel == 15)
        {
            waveIndicatorLevel15();
        }

        else if (stageLevel == 16)
        {
            waveIndicatorLevel16();
        }

        else if (stageLevel == 17)
        {
            waveIndicatorLevel17();
        }

        else if (stageLevel == 18)
        {
            waveIndicatorLevel18();
        }

        else if (stageLevel == 19)
        {
            waveIndicatorLevel19();
        }

        else if (stageLevel == 20)
        {
            waveIndicatorLevel20();
        }

        else if (stageLevel == 21)
        {
            waveIndicatorLevel21();
        }

        else if (stageLevel == 22)
        {
            waveIndicatorLevel22();
        }

        else if (stageLevel == 23)
        {
            waveIndicatorLevel23();
        }

        else if (stageLevel == 24)
        {
            waveIndicatorLevel24();
        }

        else if (stageLevel == 25)
        {
            waveIndicatorLevel25();
        }

        else if (stageLevel == 26)
        {
            waveIndicatorLevel26();
        }

        else if (stageLevel == 27)
        {
            waveIndicatorLevel27();
        }

        else if (stageLevel == 28)
        {
            waveIndicatorLevel28();
        }

        else if (stageLevel == 29)
        {
            waveIndicatorLevel29();
        }

        else if (stageLevel == 30)
        {
            waveIndicatorLevel30();
        }
    }
    private void waveIndicatorTutorial()
    {
        if (currentWave == 1)
        {

            StartCoroutine(spawnDelay());
            enemiesComing.SetActive(true);
            spawnInterval = 5f;
            timeRemaining += 15;
            maxTime = 10;
        }

        else if (currentWave == 2)
        {
            spawnInterval = 5000;
            Destroy(timerBar);
            timerIsRunning = false;
        }
    }
    private void waveIndicatorLevel1()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComing.SetActive(true); // Notification of incoming enemy
            spawnInterval = 15f; // the spawn interval
            timeRemaining += 90;  // time remaining towards the next wave
            maxTime = timeRemaining;
        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            enemiesComing.SetActive(false);
            hugeWave.SetActive(true);

            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 0.6f; // the spawn interval

            // set the spawn duration
            timeRemaining += 7; // time remaining towards the next wave
            maxTime = timeRemaining;

        }

        else if (currentWave == 3)
        {
            hugeWave.SetActive(false);
            spawnInterval = 3;
            timeRemaining += 30;
            maxTime = timeRemaining;
        }
        else if (currentWave == 4)
        {
            endWave();
        }
    }
    private void waveIndicatorLevel2()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 15f;
            timeRemaining += 30;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 30;
        }

        else if (currentWave == 6)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel3()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 15f;
            timeRemaining += 30;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 15;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 10f;
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel4()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 15f;
            timeRemaining += 30;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnHardFLU();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 48;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnHardFLU();
            spawnHardFLU();
            spawnInterval = 0.6f;
            timeRemaining += 10f;
        }

        else if (currentWave == 8)
        {
            hugeWaveFalse();
            spawnInterval = 1f;
            timeRemaining += 5f;
        }

        else if (currentWave == 9)
        {
            endWave();

        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel5()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            Debug.Log("HUGE WAVE");
            hugeWaveComing();
            spawnHardFLU();
            spawnInterval = 0.5f;
            timeRemaining += 11f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            Debug.Log("HUGE WAVE");
            hugeWaveComing();
            spawnHardFLU();
            spawnHardFLU();
            spawnInterval = 0.4f;
            timeRemaining += 7f;

        }

        else if (currentWave == 7)
        {
            spawnInterval = 4;
            timeRemaining += 45f;
            hugeWaveFalse();
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 6f;
            spawnBossFLUFixedPosition(0);
            spawnBossFLUFixedPosition(1);
            spawnBossFLUFixedPosition(2);
            spawnBossFLUFixedPosition(3);
            spawnBossFLUFixedPosition(4);
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 5f;
            timeRemaining += 10;
        }

        else if (currentWave == 10)
        {
            spawnBossFLUFixedPosition(0);
            spawnBossFLUFixedPosition(1);
            spawnBossFLUFixedPosition(2);
            spawnBossFLUFixedPosition(3);
            spawnBossFLUFixedPosition(4);
        }

        else if (currentWave == 11)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel6()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComing.SetActive(true); // Notification of incoming enemy
            spawnInterval = 20f; // the spawn interval
            timeRemaining += 120;  // time remaining towards the next wave
            maxTime = timeRemaining;
        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            enemiesComing.SetActive(false);
            hugeWave.SetActive(true);

            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 0.6f; // the spawn interval

            // set the spawn duration
            timeRemaining += 7; // time remaining towards the next wave
            maxTime = timeRemaining;

        }

        else if (currentWave == 3)
        {
            spawnMiniUTI();
            hugeWave.SetActive(false);
            spawnInterval = 3;
            timeRemaining += 30;
            maxTime = timeRemaining;
        }
        else if (currentWave == 4)
        {
            spawnMiniUTI();
            spawnMiniUTI();
            spawnInterval = 4;
            timeRemaining += 30;
        }
        else if (currentWave == 5)
        {
            endWave();
        }
    }
    private void waveIndicatorLevel7()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 20f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 4f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 2f;
            timeRemaining += 30;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnNormalUTI();
            spawnNormalUTI();
            spawnNormalUTI();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 30;
        }

        else if (currentWave == 6)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel8()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnNormalUTI();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 3;
            spawnInterval = 15f;
            timeRemaining += 30;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 15f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 15;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.4f;
            timeRemaining += 15f;
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel9()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 15f;
            timeRemaining += 30;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnBossUTI();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 48;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnBossUTI();
            spawnBossUTI();
            spawnInterval = 0.6f;
            timeRemaining += 10f;
        }

        else if (currentWave == 8)
        {
            hugeWaveFalse();
            spawnInterval = 1f;
            timeRemaining += 5f;
        }

        else if (currentWave == 9)
        {
            endWave();

        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel10()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnMediumFLU();
            spawnInterval = 15f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnHardFLU();
            spawnInterval = 0.5f;
            timeRemaining += 11f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            enemyMaxSpawn = 4;
            hugeWaveComing();
            spawnBossUTI();
            spawnBossUTI();
            spawnInterval = 0.1f;
            timeRemaining += 10f;

        }

        else if (currentWave == 7)
        {
            spawnInterval = 0.5f;
            timeRemaining += 30f;
            hugeWaveFalse();
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.1f;
            timeRemaining += 10f;

        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 5f;
            timeRemaining += 10;
        }

        else if (currentWave == 10)
        {
            spawnInterval = 0.05f;
            timeRemaining += 15;
        }

        else if (currentWave == 11)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel11()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 5f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.05f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel12()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.5f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel13()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.25f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel14()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 10)
        {
            
            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 11)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel15()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 3;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 1;
            timeRemaining += 60;
        }

        else if (currentWave == 10)
        {
            enemyMaxSpawn = 3;
            hugeWaveComing();
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnInterval = 0.05f;
            timeRemaining += 10f;
        }
        else if (currentWave == 11)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 10;
        }

        else if (currentWave == 12)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 13)
        {
            spawnBossShieldedPosition(0);
            spawnBossShieldedPosition(1);
            spawnBossShieldedPosition(2);
            spawnBossShieldedPosition(3);
            spawnBossShieldedPosition(4);
            spawnInterval = 0.1f;
            timeRemaining += 15;
        }

        else if (currentWave == 14)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel16()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 5f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.05f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel17()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.5f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel18()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.25f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel19()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 10)
        {

            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 11)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel20()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 3;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 1;
            timeRemaining += 60;
        }

        else if (currentWave == 10)
        {
            enemyMaxSpawn = 3;
            hugeWaveComing();
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnInterval = 0.05f;
            timeRemaining += 10f;
        }
        else if (currentWave == 11)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 10;
        }

        else if (currentWave == 12)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 13)
        {
            spawnBossShieldedPosition(0);
            spawnBossShieldedPosition(1);
            spawnBossShieldedPosition(2);
            spawnBossShieldedPosition(3);
            spawnBossShieldedPosition(4);
            spawnInterval = 0.1f;
            timeRemaining += 15;
        }

        else if (currentWave == 14)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel21()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 5f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.05f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel22()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.5f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel23()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.25f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel24()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 10)
        {

            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 11)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel25()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 3;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 1;
            timeRemaining += 60;
        }

        else if (currentWave == 10)
        {
            enemyMaxSpawn = 3;
            hugeWaveComing();
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnInterval = 0.05f;
            timeRemaining += 10f;
        }
        else if (currentWave == 11)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 10;
        }

        else if (currentWave == 12)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 13)
        {
            spawnBossShieldedPosition(0);
            spawnBossShieldedPosition(1);
            spawnBossShieldedPosition(2);
            spawnBossShieldedPosition(3);
            spawnBossShieldedPosition(4);
            spawnInterval = 0.1f;
            timeRemaining += 15;
        }

        else if (currentWave == 14)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel26()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 5f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.05f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel27()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 5f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.7f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.3f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.5f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel28()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.25f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
        }

        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 8)
        {
            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 9)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel29()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 2;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 10)
        {

            spawnInterval = 0.45f;
            timeRemaining += 15;
        }

        else if (currentWave == 11)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void waveIndicatorLevel30()
    {
        if (currentWave == 1)
        {
            enemyMaxSpawn = 1; // Set the spawned enemies 1 for normal enemy 2 for medium enemy 3 for boss enemy
            StartCoroutine(spawnDelay()); // Start spawning
            enemiesComingWave(); // Notification of incoming enemy

            spawnInterval = 15f; // the spawn interval
            timeRemaining += 60;  // time remaining towards the next wave


        }
        else if (currentWave == 2)
        {
            Destroy(timerBar);
            // A HUGE WAVE OF ZOMBIES IS COMING
            enemyMaxSpawn = 1;
            // SpawnInterval Divided by 10 seconds = enemies spawned
            spawnInterval = 2f; // the spawn interval
            // set the spawn duration
            timeRemaining += 30; // time remaining towards the next wave
        }

        else if (currentWave == 3)
        {
            enemyMaxSpawn = 3;
            spawnInterval = 4f;
            timeRemaining += 20;
        }
        else if (currentWave == 4)
        {
            hugeWaveComing();
            spawnInterval = 0.6f;
            timeRemaining += 12f;
        }
        else if (currentWave == 5)
        {
            hugeWaveFalse();
            spawnInterval = 5;
            timeRemaining += 60;
        }

        else if (currentWave == 6)
        {
            hugeWaveComing();
            spawnInterval = 0.5f;
            timeRemaining += 20f;
        }
        else if (currentWave == 7)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 30;
        }

        else if (currentWave == 8)
        {
            hugeWaveComing();
            spawnInterval = 0.45f;
            timeRemaining += 10f;
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnBossAmoe();
            spawnBossAmoe();
        }

        else if (currentWave == 9)
        {
            hugeWaveFalse();
            spawnInterval = 1;
            timeRemaining += 60;
        }

        else if (currentWave == 10)
        {
            enemyMaxSpawn = 3;
            hugeWaveComing();
            spawnShieldFixedPosition(0);
            spawnShieldFixedPosition(1);
            spawnShieldFixedPosition(2);
            spawnShieldFixedPosition(3);
            spawnShieldFixedPosition(4);
            spawnInterval = 0.05f;
            timeRemaining += 10f;
        }
        else if (currentWave == 11)
        {
            hugeWaveFalse();
            spawnInterval = 2;
            timeRemaining += 10;
        }

        else if (currentWave == 12)
        {
            hugeWaveFalse();
            spawnInterval = 4f;
            timeRemaining += 10;
        }

        else if (currentWave == 13)
        {
            spawnBossShieldedPosition(0);
            spawnBossShieldedPosition(1);
            spawnBossShieldedPosition(2);
            spawnBossShieldedPosition(3);
            spawnBossShieldedPosition(4);
            spawnInterval = 0.1f;
            timeRemaining += 15;
        }

        else if (currentWave == 14)
        {
            endWave();
        }
        maxTime = timeRemaining;
    }
    private void endWave()
    {
        spawnInterval = 5000;
        timerIsRunning = false;
    }
    // SPAWN COUROUTINE
    IEnumerator spawnDelay()
    {
        // WAIT FOR SECONDS ( spawnInterval ) 
        yield return new WaitForSeconds(spawnInterval);
        spawnEnemy();
        // RECALL THE COUROUTINE ( RESTARTING COROUTINE ) 
        StartCoroutine(spawnDelay());
    }
    private void spawnEnemy()
    {
        // RANDOMIZE THE ENEMY SPAWN
        int randomEnemyPrefab = Random.Range(enemyMinSpawn, enemyMaxSpawn); // 0 - 5 ( 5 enemies )
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[randomEnemyPrefab], enemySpawnPoints[randomEnemySpawnID]);
    }

    // FLU PREFABS
    // Spawn normal enemy or mini
    private void spawnNormalFLU()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[0], enemySpawnPoints[randomEnemySpawnID]);
    }

    // Spawn stronger variatns of the mini
    private void spawnMediumFLU()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[1], enemySpawnPoints[randomEnemySpawnID]);
    }

    // Spawn the strongest enemy 
    private void spawnHardFLU()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[2], enemySpawnPoints[randomEnemySpawnID]);
    }

    private void spawnBossFLUFixedPosition(int spawnPosition)
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[2], enemySpawnPoints[spawnPosition]);
    }

    // UTI PREFABS
    private void spawnMiniUTI()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[1], enemySpawnPoints[randomEnemySpawnID]);
    }

    private void spawnNormalUTI()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[2], enemySpawnPoints[randomEnemySpawnID]);
    }

    private void spawnBossUTI()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[3], enemySpawnPoints[randomEnemySpawnID]);
    }

    private void spawnShieldFixedPosition(int spawnPosition)
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[4], enemySpawnPoints[spawnPosition]);
    }
    private void spawnBossAmoe()
    {
        // RANDOMIZE THE ENEMY SPAWN POINTS
        int randomEnemySpawnID = Random.Range(enemyMinSpawn, enemySpawnPoints.Count); // 0 - 5 ( 5 spawn points ) 
        // INSTANTIATE ENEMY PREFABS
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[5], enemySpawnPoints[randomEnemySpawnID]);
    }

    private void spawnBossShieldedPosition(int spawnPosition)
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[5], enemySpawnPoints[spawnPosition]);
    }
    private void enemiesComingWave()
    {
        enemiesComing.SetActive(true);
    }

    private void hugeWaveComing()
    {
        enemiesComing.SetActive(false);
        hugeWave.SetActive(true);
    }

    private void hugeWaveFalse()
    {
        hugeWave.SetActive(false);
    }

    // Set the player prefs to int value to make it done referrence in pageScript.
    private void winStage()
    {
        if (stageLevel == 1)
        {
            PlayerPrefs.SetInt("fluLevel1Win", 1);
            PlayerPrefs.SetInt("fluLevel2", 2);
        }
        else if (stageLevel == 2)
        {
            PlayerPrefs.SetInt("fluLevel2Win", 2);
            PlayerPrefs.SetInt("fluLevel3", 3);
        }
        else if (stageLevel == 3)
        {
            PlayerPrefs.SetInt("fluLevel3Win", 3);
            PlayerPrefs.SetInt("fluLevel4", 4);
        }
        else if (stageLevel == 4)
        {
            PlayerPrefs.SetInt("fluLevel4Win", 4);
            PlayerPrefs.SetInt("fluLevel5", 5);
        }
        else if (stageLevel == 5)
        {
            PlayerPrefs.SetInt("fluLevel5Win", 5);
            PlayerPrefs.SetInt("utiLevel1", 1);
        }

        else if (stageLevel == 6)
        {
            PlayerPrefs.SetInt("utiLevel1Win", 1);
            PlayerPrefs.SetInt("utiLevel2", 2);
        }

        else if (stageLevel == 7)
        {
            PlayerPrefs.SetInt("utiLevel2Win", 2);
            PlayerPrefs.SetInt("utiLevel3", 3);
        }

        else if (stageLevel == 8)
        {
            PlayerPrefs.SetInt("utiLevel3Win", 3);
            PlayerPrefs.SetInt("utiLevel4", 4);
        }

        else if (stageLevel == 9)
        {
            PlayerPrefs.SetInt("utiLevel4Win", 4);
            PlayerPrefs.SetInt("utiLevel5", 5);
        }

        else if (stageLevel == 10)
        {
            PlayerPrefs.SetInt("utiLevel5Win", 5);
            PlayerPrefs.SetInt("amoeLevel1", 1);
        }

        else if (stageLevel == 11)
        {
            PlayerPrefs.SetInt("amoeLevel1Win", 1);
            PlayerPrefs.SetInt("amoeLevel2", 2);
        }

        else if (stageLevel == 12)
        {
            PlayerPrefs.SetInt("amoeLevel2Win", 2);
            PlayerPrefs.SetInt("amoeLevel3", 3);
        }

        else if (stageLevel == 13)
        {
            PlayerPrefs.SetInt("amoeLevel3Win", 3);
            PlayerPrefs.SetInt("amoeLevel4", 4);
        }

        else if (stageLevel == 14)
        {
            PlayerPrefs.SetInt("amoeLevel4Win", 4);
            PlayerPrefs.SetInt("amoeLevel5", 5);
        }

        else if (stageLevel == 15)
        {
            PlayerPrefs.SetInt("amoeLevel5Win", 5);
        }
    }

    public void WinLevel()
    {
        winStage();
        victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
