using System.Collections;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    // FIELDS
    // HEALTH VALUE 
    public int enemyHealth;

    // ANIMATOR , INTERVAL AND ATTACK ORDER
    public Animator enemyAnimator;

    public AnimationClip moveAnimation;
    public AnimationClip deathAnimation;

    // LOSE HEALTH WHEN HIT 
    public void enemyLoseHealth(int projectileDamage)
    {
        // DECREASE HEALTH
        enemyHealth -= projectileDamage;
        // BLINK RED ANIMATION // ANIMATION HERE WHEN HURT
        StartCoroutine(getHurtAnim());
        // CHECK IF HEALTH IS ZERO THEN DESTROYED
            if (enemyHealth <= 0)
            {
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            gameObject.tag = "Untagged";
            enemyAnimator.Play(deathAnimation.name, 0, 0);
        }
    }

    // BOTH FOUND IN THE ANIMATION EVENTS
    public void destroyGameObject()
    {
        Destroy(gameObject);
    }

    // GETTING HURT ANIMATION
    IEnumerator getHurtAnim()
    {
            // CHANGE THE SPRITE TO RED 
            GetComponent<SpriteRenderer>().color = Color.red;
            // WAIT FOR SECONDS TO TURN BACK THEN REVERT    
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = Color.white;
    }
}
