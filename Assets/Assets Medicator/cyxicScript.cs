using UnityEngine;

public class cyxicScript : MonoBehaviour
{
    private Animator cyxicAnimator;
    private int projectileDamage = 500;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyCollider")
        {
            gameObject.tag = "Untagged";
            collision.GetComponent<enemyScript>().enemyLoseHealth(projectileDamage);
            collision.GetComponent<enemyScript>().enemyDead = true;
            GetComponent<BoxCollider2D>().enabled = false;
            cyxicAnimator = GetComponent<Animator>();
            cyxicAnimator.SetTrigger("isDead");
        }

        if (collision.tag == "shieldColliderss")
        {
            cyxicAnimator = GetComponent<Animator>();
            cyxicAnimator.SetTrigger("isDead");
            collision.GetComponent<shieldScript>().enemyLoseHealth(9999);
            collision.GetComponentInParent<enemyScript>().enemyLoseHealth(9999);
            collision.GetComponentInParent<enemyScript>().parentDelay();
        }
    }
}
