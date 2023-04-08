using UnityEngine;

public class newUnlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1;
    }
}
