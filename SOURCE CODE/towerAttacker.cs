using UnityEngine;

public class towerAttacker : towerParent
{
    // FIELDS
    // Tower Damage Value
    public int towerDamage;
    // Tower Prefab ( Shooting Projectile )
    public GameObject prefab_attackCollider;

    // Shooting time value 
    public BoxCollider2D attackCollider;
    public bool isFiring = false;

    private void Start()
    {
        towerAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spawnCollider1")
        {
            attackCollider.offset = new Vector2(12, 0);
            attackCollider.size = new Vector2(25, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider2")
        {
            attackCollider.offset = new Vector2(14.5f, 0);
            attackCollider.size = new Vector2(29.5f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider3")
        {
            attackCollider.offset = new Vector2(17, 0);
            attackCollider.size = new Vector2(34, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider4")
        {
            attackCollider.offset = new Vector2(19, 0);
            attackCollider.size = new Vector2(38, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider5")
        {
            attackCollider.offset = new Vector2(21.5f, 0);
            attackCollider.size = new Vector2(43, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider6")
        {
            attackCollider.offset = new Vector2(23.5f, 0);
            attackCollider.size = new Vector2(48, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider7")
        {
            attackCollider.offset = new Vector2(25.9f, 0);
            attackCollider.size = new Vector2(52.1f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider8")
        {
            attackCollider.offset = new Vector2(28.2f, 0);
            attackCollider.size = new Vector2(56.1f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider9")
        {
            attackCollider.offset = new Vector2(30.1f, 0);
            attackCollider.size = new Vector2(61, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider10")
        {
            attackCollider.offset = new Vector2(33.4f, 0);
            attackCollider.size = new Vector2(67.6f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider11")
        {
            attackCollider.offset = new Vector2(11.3f, 0);
            attackCollider.size = new Vector2(23.33f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider12")
        {
            attackCollider.offset = new Vector2(9.4f, 0);
            attackCollider.size = new Vector2(19.26f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider13")
        {
            attackCollider.offset = new Vector2(7.1f, 0);
            attackCollider.size = new Vector2(14.5f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }

        if (collision.tag == "spawnCollider14")
        {
            attackCollider.offset = new Vector2(4.8f, 0);
            attackCollider.size = new Vector2(9.8f, 0.25f);
            Instantiate(prefab_attackCollider, transform);
        }
    }
}
