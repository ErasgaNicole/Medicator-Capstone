using System.Collections;
using UnityEngine;

public class towerIncome : towerParent
{
    // Income Value
    public int incomeValue;
    // Interval for income
    public float intervalTime;
    // Gain Currency Indicator
    public GameObject currencyImage;
    // METHODS
    void Start()
    {
        towerAnimator = GetComponent<Animator>();
        StartCoroutine(spawnInterval());
    }
    // Initialization for values
    IEnumerator spawnInterval()
    {
        yield return new WaitForSeconds(intervalTime);
        increaseIncome();
        StartCoroutine(spawnInterval());
    }
    // Trigger income increase
    public void increaseIncome()
    {
        GameManager.instance.currencySystem.gainCurrency(incomeValue);
        StartCoroutine(currencyIndication());
    }
    // User Interface for gaining currency 
    IEnumerator currencyIndication()
    {
        currencyImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        currencyImage.SetActive(false);
    }  
}
