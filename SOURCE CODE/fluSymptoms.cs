using UnityEngine;
using TMPro;

public class fluSymptoms : MonoBehaviour
{
    private void OnEnable()
    {
        fluRandomSymptoms();
    }

    private void fluRandomSymptoms()
    {
        int randomTips = Random.Range(1, 6);
        if (randomTips == 1)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience FEVER";
        }
        else if (randomTips == 2)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience COUGH.";
        }

        else if (randomTips == 3)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience BODY ACHES.";
        }

        else if (randomTips == 4)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience SORE THROAT.";
        }

        else if (randomTips == 5)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience HEADACHES.";
        }

        else if (randomTips == 6)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience FATIGUES.";
        }
    }

}
