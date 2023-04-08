using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public GameObject Retry;
    public GameObject NextPass;


    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text CurrentScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    private void Update()
    {
        CurrentScoreTxt.text = score + "/" + totalQuestions;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //CHANGE NEXT SCENE
    public void nextScene()
    {
        Debug.Log("NEXT SCENE!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        if (score >= 3)
        {
            NextPass.SetActive(true);
            Retry.SetActive(false);
            ScoreTxt.gameObject.GetComponent<Text>().color = Color.green;
            ScoreTxt.text = "You Passed! Your Score is " + score + "/" + totalQuestions;
        }
        else
        {
            NextPass.SetActive(false);
            Retry.SetActive(true);
            ScoreTxt.text = "You Failed! Your Score is " + score + "/" + totalQuestions;
            ScoreTxt.gameObject.GetComponent<Text>().color = Color.red;
        }
    }

    public void  correct()
    {
        Quizpanel.GetComponent<Image>().color = Color.green;
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    public void wrong()
    {
        Quizpanel.GetComponent<Image>().color = Color.red;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;

            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        } 
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
