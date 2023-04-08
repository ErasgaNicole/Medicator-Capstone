using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject losePanel;
    void Awake() 
    { 
        instance = this;   
    }
    public currencySystem currencySystem;

    void Start()
    {
        GetComponent<currencySystem>().initializeValues();
    }

    public void youLose()
    {
        losePanel.SetActive(true);
    }
}
