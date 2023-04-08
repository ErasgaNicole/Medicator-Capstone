using System.Collections;
using UnityEngine;

public class enemyCounter : MonoBehaviour
{
    private GameObject[] getCount;
    private void Start()
    {
        StartCoroutine(startCounting());
    }
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("enemyCollider");
    }

    int count;
    IEnumerator startCounting()
    {
        count++;
        yield return new WaitForSeconds(1);
        StartCoroutine(startCounting());
    }
}
