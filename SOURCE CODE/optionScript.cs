using UnityEngine;
using TMPro;

public class optionScript : MonoBehaviour
{
    // Start of the open and close animation for the place holder 
    // Variables 
    public GameObject parentPanel;
    private Animator panelAnimator;
    // Variables for determining if the button is clicked or not
    private bool isOpen = true;

    // Automatically get the component Animator
    void Start()
    {
        panelAnimator = GetComponent<Animator>();
    }

    // Opening of the panels and the activation 
    public void openPanel()
    {
        if (isOpen == true)
        {
            parentPanel.SetActive(true);
            panelAnimator.SetTrigger("openTrigger");
            isOpen = false;
        }
    }

    // Closing the panels
    public void closePanel()
    {
        if (isOpen == false)
        {
            panelAnimator.SetTrigger("closeTrigger");
            isOpen = true;
        }
    }

    // Followed events that set the panel inactive
    public void setInactive()
    {
        parentPanel.SetActive(false);
    }

    // End of the open and close animation for the place holder
    // Start of the functions for the buttons inside
    public TMP_Text musicLabel;
    public TMP_Text sfxLabel;
    bool isMusic = true;
    bool isSFX = true;
    public void musicButton()
    {
        if (isMusic == true)
        {
            musicLabel.text = "Music Off";
            isMusic = false;
        }

        else
        {
            musicLabel.text = "Music On";
            isMusic = true;
        }        
    }

    public void sfxButton()
    {
        if (isSFX == true)
        {
            sfxLabel.text = "SFX Off";
            isSFX = false;
        }

        else
        {
            sfxLabel.text = "SFX On";
            isSFX = true;
        }
    }
    public void gameExit()
    {
        Application.Quit();   
    }
}
