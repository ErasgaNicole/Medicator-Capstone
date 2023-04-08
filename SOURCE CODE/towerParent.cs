using System.Collections;
using UnityEngine;

public class towerParent : MonoBehaviour
{
    // FIELDS FOR COMMON VALUES
    public int towerHealth;
    public int towerCost;
    private Vector3Int cellPosition;
    public Animator towerAnimator;

    // INITIALIZATION
    public virtual void InitializationValues(Vector3Int cellPos)
    {
        cellPosition = cellPos;
    }

    // LOSE HEALTH AND DESTROY
    public virtual bool loseHealth(int enemyDamage)
    {
        // conditon for tower health and tutorial
        towerHealth -= enemyDamage;
        StartCoroutine(getHurtAnim());
        if (towerHealth <= 0)
        {
            towerAnimator.SetTrigger("isDead");
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator getHurtAnim()
    {
        // CHANGE THE SPRITE TO RED 
        GetComponent<SpriteRenderer>().color = Color.red;
        // WAIT FOR SECONDS TO TURN BACK THEN REVERT    
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Function method for tower dying
    protected virtual void towerDestroy()
    {
        FindObjectOfType<Spawner>().revertCellState(cellPosition);
        Destroy(gameObject);
    }
}
