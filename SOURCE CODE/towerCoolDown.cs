using UnityEngine;
using UnityEngine.UI;

public class towerCoolDown : MonoBehaviour
{
    private Image towerCooldownImage;
    // VARIABLES FOR COOLDOWN
    private bool isCooldown = false;
    public float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    
    private void OnEnable()
    {
        towerCooldownImage = GetComponent<Image>();     
        useTower();
        Button button = gameObject.GetComponentInParent<Button>();
        button.enabled = false;
    }

    void applyCooldown()
    {
        // Last Called
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            towerCooldownImage.fillAmount = 0.0f;
            Button button = gameObject.GetComponentInParent<Button>();
            button.enabled = true;
            gameObject.SetActive(false);
        }
        else
        {
            towerCooldownImage.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    private void useTower()
    {
        if (isCooldown == true)
        {
            Debug.Log(" IN COOLDOWN");
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }

    private void Update()
    {
        if (isCooldown == true)
        {
            applyCooldown();
        }
    }
}
