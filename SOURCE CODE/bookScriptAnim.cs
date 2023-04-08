using UnityEngine;
using UnityEngine.UI;

public class bookScriptAnim : MonoBehaviour
{
    // ARRAYS OF PAGES
    public GameObject[] bookPages;

    // Variable for animation
    public Animator bookAnimator;

    // SETS THE PAGE INDEX =-1 SINCE ARRAY STARTS AT [0]
    static int pageIndex = 0;

    // ARRAYS OF SPRITE CONTAINER
    public Image[] layoutButtons;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    // Variable for current button
    int currentButton;

    // Variables for the previous and next button
    public Button nextButton;
    public Button prevButton;

    // SELECT WHAT BUTTONS
    public void selectButton(int indexButton)
    {
        defaultSprite();
        currentButton = indexButton;
        layoutButtons[currentButton].sprite = selectedSprite;
    }

    // SET ALL SPRITES TO DEFAULT
    public void defaultSprite()
    {
        foreach (Image active in layoutButtons)
        {
            active.sprite = unselectedSprite;
        }
    }

    // DETERMINE IF pageIndex is not equal to the length of array then do something else do nothing
    public void nextPage()
    {
        pageIndex++;
       // StartCoroutine(cooldownPreviousButton());
        if (pageIndex != bookPages.Length)
        {
            defaultSprite();
            layoutButtons[pageIndex].sprite = selectedSprite;
            deactivateAllPages();
            bookAnimator.SetTrigger("isNext");
        }
        else
        {
            pageIndex--;
            Debug.Log("END OF PAGE");
        }
    }

    // DETERMINE IF pageIndex is not equal to the length of array then do something else do nothing
    public void prevPage()
    {
        pageIndex--;
       // StartCoroutine(cooldownNextButton());
        if (pageIndex != -1)
        {
            defaultSprite();
            layoutButtons[pageIndex].sprite = selectedSprite;
            deactivateAllPages();
            bookAnimator.SetTrigger("isPrev");
        }
        else
        {
            pageIndex++;
            Debug.Log("END OF PAGE");
        }
    }

    // CODE IN THE LAST SECONDS OF THE ANIMATION
    public void previousPage()
    {
        SelectPage(pageIndex);
    }

    // CODE IN THE LAST SECONDS OF THE ANIMATION
    public void nextiousPage()
    {
        SelectPage(pageIndex);
    }

    // SET THE CURRENT PAGE
    int currentPage;

    // DEACTIVATES ALL PAGES
    public void deactivateAllPages()
    {
        foreach (GameObject page in bookPages)
        {
            page.SetActive(false);
        }
    }

    // LAST INDEX VALUE
    int lastIndex = pageIndex;

    // DEACTIVES ALL PAGE BUT THEN ACTIVATE SELECTED
    public void SelectPage(int whatPage)
    {
        deactivateAllPages();
        defaultSprite();
        currentPage = whatPage;
        bookPages[currentPage].SetActive(true);
        Debug.Log(bookPages[currentPage]);  
    }

    public void pageSelector(int whatPage)
    {
        lastIndex = pageIndex;
        pageIndex = whatPage;
        if (lastIndex < pageIndex)
        {
            defaultSprite();
            layoutButtons[pageIndex].sprite = selectedSprite;
            deactivateAllPages();
            bookAnimator.SetTrigger("isNext");
        }

        else if (lastIndex > pageIndex)
        {
            defaultSprite();
            layoutButtons[pageIndex].sprite = selectedSprite;
            deactivateAllPages();
            bookAnimator.SetTrigger("isPrev");
        }
        // Get the value of the last index
        lastIndex = pageIndex;
    }
}
