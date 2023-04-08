using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriviaManager : MonoBehaviour
{
    public List<TriviaList> QnA;
    public GameObject Triviapanel;
    public GameObject GoPanel;
    public GameObject nextbtn;
    public Text QuestionTxt;
    public int currentQuestion;
   
    private void Start()
    {
        GoPanel.SetActive(false);
        generateTrivia();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //CHANGE NEXT SCENE
    public void nextScene()
    {
        Debug.Log("NEXT SCENE!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void TriviaOver()
    {
        Triviapanel.SetActive(false);
        GoPanel.SetActive(true);
        nextbtn.SetActive(false);
        GoPanel.GetComponentInChildren<Text>().color = Color.red;
        GoPanel.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Read Again"; 
    } 

    public void Next()
    {
        QnA.RemoveAt(currentQuestion);
        generateTrivia();
    }


    void generateTrivia()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
        }
        else
        {
            TriviaOver();
        }
    }
}
