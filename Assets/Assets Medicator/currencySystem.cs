using TMPro;
using UnityEngine;

public class currencySystem : MonoBehaviour
{
    // FIELDS
    // Text label for the currency value
    public TMP_Text currencyText;

    // default currency value
    public int defaultCurrency;

    // current currency value
    [HideInInspector ]public int currentCurrency;

    // METHODS
    // Setting the default value
    public void initializeValues()
    {
        currentCurrency = defaultCurrency;
        updateUI();
    }
    // Gain currency ++
    public void gainCurrency(int currencyValue)
    {
        //Debug.Log("GAIN CURRENCY");
        currentCurrency += currencyValue;
        updateUI();
    }

    // Use currency
    public bool useCurrency(int currencyValue)
    {
        if (isEnough(currencyValue))
        {
            currentCurrency -= currencyValue;
            Debug.Log("USED CURRENCY");
            updateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    // Check available currency
    public bool isEnough(int currencyValue)
    {
        // Check if the player can afford
        if (currencyValue <= currentCurrency)
            return true;
        else
            return false;
    }
    // Update the text UI

    public void updateUI()
    {
        currencyText.text = currentCurrency.ToString();
    }
}
