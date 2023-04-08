using UnityEngine;

public class attackRange : MonoBehaviour
{
    public GameObject prefab_towerProjectile;
    public int shootTimeInterval;
    public int nextUpdate = 1;
    public void shootProjectileRange()
    {
        GameObject shootProjectileOBJ = Instantiate(prefab_towerProjectile, transform);
        shootProjectileOBJ.transform.localScale = new Vector3(3.5f, 1f, 1);
    }

    float doubleFire = 0;
    public void doubleProjectile()
    {
        for (int i = 0; i <= 1; i++)
        {
            doubleFire -= 0.8f;
            // Instantiate Shoot Projectile
            GameObject shootProjectileOBJ = Instantiate(prefab_towerProjectile, new Vector3(transform.position.x - doubleFire, transform.position.y, transform.position.z), Quaternion.identity, transform);
            // Set its values
            shootProjectileOBJ.transform.localScale = new Vector3(3.5f, 1f, 1);
        }
        doubleFire = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "enemyCollider")
        {
            // If the next update is reached
            if (Time.time >= nextUpdate)
            {
                nextUpdate = Mathf.FloorToInt(Time.time) + 3;
                shootProjectileRange();
            }
        }
    }
}