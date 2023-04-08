using UnityEngine;
using UnityEngine.UI;

public class pregameScript : MonoBehaviour
{
    public GameObject warningText;
    public GameObject screenAndpanel;
    public Transform parentObject;
    private Spawner spawnerScript;
    public Button[] towerButtons;
    public draggableItem[] draggableItems;
    public Animator panelAnimator;
    private void Start()
    {
        spawnerScript = GetComponent<Spawner>();
        foreach (Button button in towerButtons)
        {
            button.enabled = false;
        }
    }

    public void playAnimation()
    {
        GetComponent<Spawner>().gameStart = true;
        if (parentObject.childCount == 7)
        {
            warningText.SetActive(false);
            screenAndpanel.SetActive(true);
            spawnerScript.deselectTower();
            Time.timeScale = 1;
            panelAnimator.SetTrigger("isClose");
            foreach (Button button in towerButtons)
            {
                button.enabled = true;
            }

            foreach (draggableItem draggableItemOBJ in draggableItems)
            {
                draggableItemOBJ.GetComponent<draggableItem>();
                draggableItemOBJ.enabled = false;
            }
        }

        else
        {
            warningText.SetActive(true);
        }
    }
}
