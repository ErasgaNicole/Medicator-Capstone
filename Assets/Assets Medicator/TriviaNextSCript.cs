using UnityEngine;

public class TriviaNextSCript : MonoBehaviour
{
    public bool isDone = false;
    public TriviaManager TriviaManager;
    public void Answer()
    {
        if (!isDone)
        {
            Debug.Log("NEXTO");
            TriviaManager.Next();
        }      
    }
}
