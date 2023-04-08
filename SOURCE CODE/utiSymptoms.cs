using UnityEngine;
using TMPro;

public class utiSymptoms : MonoBehaviour
{
    private void OnEnable()
    {
        utiRandomSymptoms();
    }

    private void utiRandomSymptoms()
    {
        int randomTips = Random.Range(1, 5);
        if (randomTips == 1)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience cloudy urine";
        }
        else if (randomTips == 2)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience burning senstation when urinating.";
        }

        else if (randomTips == 3)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience strong smelling urine.";
        }

        else if (randomTips == 4)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience Passing small amounts of urine.";
        }

        else if (randomTips == 5)
        {
            GetComponent<TMP_Text>().text = "You are now sick and may experience Pelvic Pain.";
        }
    }

}
