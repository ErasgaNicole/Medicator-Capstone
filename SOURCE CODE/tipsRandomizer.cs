using UnityEngine;
using TMPro;

public class tipsRandomizer : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("TIPS GOD");
        whatTip(); 
    }

    private void whatTip()
    {
        int randomTips = Random.Range(1, 11);
        if (randomTips == 1)
        {
            GetComponent<TMP_Text>().text = "Tips: Build a lot of replicator as it is the backbone of your defense.";
        }
        else if (randomTips == 2)
        {
            GetComponent<TMP_Text>().text = "Tips: Starting tips you can build 3 replicator before placing an eosishooter.";
        }

        else if (randomTips == 3)
        {
            GetComponent<TMP_Text>().text = "Tips: Having a good flow of DNA makes the game easier.";
        }

        else if (randomTips == 4)
        {
            GetComponent<TMP_Text>().text = "Tips: Always remember to know the enemies weaknesses..";
        }

        else if (randomTips == 5)
        {
            GetComponent<TMP_Text>().text = "Tips: Relax and take a break often.";
        }

        else if (randomTips == 6)
        {
            GetComponent<TMP_Text>().text = "Tips: Don't forget to read the almanac, It contains useful information.";
        }

        else if (randomTips == 7)
        {
            GetComponent<TMP_Text>().text = "Tips: Replicator takes 12 seconds to produce 5 DNA. ";
        }

        else if (randomTips == 8)
        {
            GetComponent<TMP_Text>().text = "Tips: Duetoplasm is an upgraded version of the eosishooter.";
        }

        else if (randomTips == 9)
        {
            GetComponent<TMP_Text>().text = "Tips: Use the swab wisely as it allows the return of 50% dna. ";
        }

        else if (randomTips == 10)
        {
            GetComponent<TMP_Text>().text = "Tips: Whenever a plant is not in cooldown. PLANT IT! .";
        }

        else if (randomTips == 11)
        {
            GetComponent<TMP_Text>().text = "Tips: Having 2-3 layers of replicator will boost your winrate!. ";
        }
    }
}
