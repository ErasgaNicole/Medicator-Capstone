using UnityEngine;

public class shootProjectile : MonoBehaviour
{
    // FIELDS
    // GRAPHICS ( THE SPRITE ) 
    public Transform projectileGraphics;

    // Damage
    public int projectileDamage;

    // projectile speed
    public float projectileSpeed;

    // METHODS
    // Initialization
    public void InitializationValues(int parDmg)
    {
        projectileDamage = parDmg;
    }
    // Trigger with enemyif (c
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyCollider")
        {
            collision.GetComponent<enemyScript>().enemyLoseHealth(projectileDamage);
            Destroy(gameObject);
        }

        if (collision.tag == "shieldCollider")
        {
            collision.GetComponent<shieldScript>().enemyLoseHealth(projectileDamage);
            Destroy(gameObject);
        }

        if (collision.tag == "outBounds")
        {
            Destroy(gameObject);
        }
    }

    // Handle Rotation 
    void Update()
    {
        projectileForward();
    }
    void projectileForward()
    {
        transform.Translate(transform.right * projectileSpeed * Time.deltaTime);
    }
}
