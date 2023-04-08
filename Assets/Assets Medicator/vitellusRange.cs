using UnityEngine;

public class vitellusRange : MonoBehaviour
{
    public GameObject prefab_towerProjectile;
    public int shootTimeInterval;
    public int nextUpdate = 1;

    public void shootProjectileRange()
    {
        GameObject shootProjectileOBJ = Instantiate(prefab_towerProjectile, transform);
        shootProjectileOBJ.transform.localScale = new Vector3(3.5f, 1f, 1);
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.tag == "enemyCollider")
        {
            if (Time.time >= nextUpdate)
            {
                nextUpdate = Mathf.FloorToInt(Time.time) + shootTimeInterval;
                shootProjectileRange();
            }
        }
    }
}