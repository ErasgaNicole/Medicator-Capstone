using UnityEngine;

public class removeTower : MonoBehaviour
{
    towerParent towerDetected;
    public currencySystem currencySystem;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "towerCollider")
        {
            towerDetected = collision.GetComponent<towerParent>();
            int getTowerCost = collision.gameObject.GetComponent<towerParent>().towerCost;
            GameManager.instance.currencySystem.gainCurrency(getTowerCost / 2);
            
            bool isDead = towerDetected.loseHealth(99999);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
