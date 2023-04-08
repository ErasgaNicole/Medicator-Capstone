using System.Collections;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // FIELDS
    // HEALTH VALUE 
    public int enemyHealth;

    // ATTACK POWER
    public int enemyAttackPower;

    // MOVEMENT SPEED
    public float enemyMovementSpeed;

    // ROOT
    public Transform splitRoot;

    // ANIMATOR , INTERVAL AND ATTACK ORDER
    public Animator enemyAnimator;
    public AnimationClip attackAnimation;
    public AnimationClip moveAnimation;
    public AnimationClip deathAnimation;
    public float attackInterval;
    Coroutine attackOrder;
    towerParent towerDetected;

    // Prefabs
    public GameObject miniPrefabs;
    public GameObject normalPrefabs;

    // VARIABLE TO KNOW IF ATTACKING
    bool isAttacking = false;

    // VARIABLE TO KNOW ENEMY IF ALIVE OR NOT
    private bool isAlive = true;
    // BEHAVIOUR FOR INVISIBLE
    public bool isInvisible;
    // METHODS

    private void Start()
    {
        if (isInvisible == true)
        {
            gameObject.tag = "Untagged";
            Color temporaryAlpha = GetComponent<SpriteRenderer>().color;
            temporaryAlpha.a = 0.5f;
            GetComponent<SpriteRenderer>().color = temporaryAlpha;
        }
    }
    private void Update()
    {
        if (towerDetected == null && enemyHealth != 0 && enemyDead != true)
        {
            enemyMove();
        }

        else if (enemyDead == true)
        {
            enemyDie();
        }

        if (isAlive == false)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator enemyAttack()
    {
        Color originalAlpha = GetComponent<SpriteRenderer>().color;
        originalAlpha.a = 1f;
        GetComponent<SpriteRenderer>().color = originalAlpha;
        gameObject.tag = "enemyCollider";
        enemyAnimator.Play(attackAnimation.name, 0, 0);
        // WAIT FOR attackInterval 
        yield return new WaitForSeconds(attackInterval);
        // then attack again
        attackOrder = StartCoroutine(enemyAttack());
    }

    [HideInInspector] public bool enemyDead = false;
    void enemyDie()
    {
        if (enemyDead == false)
        {
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            StopCoroutine(attackOrder);
            enemyAnimator.Play(deathAnimation.name, 0, 0);
            isAttacking = false;
            enemyDead = true;
        }
    }

    // MOVING FORWARD FUNCTION
    void enemyMove()
    {
        enemyAnimator.Play(moveAnimation.name);
        transform.Translate(-transform.right * enemyMovementSpeed * Time.deltaTime);
    }

    public void inflictDamage()
    {
        bool isDead = towerDetected.loseHealth(enemyAttackPower);
        if (isDead)
        {
            towerDetected = null;
            StopCoroutine(attackOrder);
        }
    }

    // LOSE HEALTH WHEN HIT 
    public void enemyLoseHealth(int projectileDamage)
    {
        // DECREASE HEALTH
        enemyHealth -= projectileDamage;
        // BLINK RED ANIMATION // ANIMATION HERE WHEN HURT
        StartCoroutine(getHurtAnim());

        // CHECK IF HEALTH IS ZERO THEN DESTROYED
        if (isAttacking == true)
        {
            if (enemyHealth <= 0)
            {
                BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
                boxCollider2D.enabled = false;
                StopCoroutine(attackOrder);
                gameObject.tag = "Untagged";
                enemyAnimator.Play(deathAnimation.name, 0, 0);
                isAttacking = false;
            }
        }

        if (enemyHealth <= 0 && isAttacking != true)
        {
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            gameObject.tag = "Untagged";
            enemyAnimator.Play(deathAnimation.name, 0, 0);
            isAttacking = false;
        }
    }

    // BOTH FOUND IN THE ANIMATION EVENTS
    public void destroyGameObject()
    {
        Destroy(gameObject);
        StartCoroutine(startCountdown());
    }

    // TIMER FOR DESTROYING
    IEnumerator startCountdown()
    {
        Debug.Log("START COUNTDOWN");
        yield return new WaitForSeconds(3);
        isAlive = false;
        Destroy(gameObject);
    }

    public void StopAnim()
    {
        StopCoroutine(attackOrder);
    }

    // GETTING HURT ANIMATION
    IEnumerator getHurtAnim()
    {
        if (isFrozen == true)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        else
        {
            // CHANGE THE SPRITE TO RED 
            GetComponent<SpriteRenderer>().color = Color.red;
            // WAIT FOR SECONDS TO TURN BACK THEN REVERT    
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    

    // stack counts
    private int forenStackCount = 0;

    // COLLISION DETECTOR
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (towerDetected == true)
        {
            return;
        }

        if (collision.tag == "towerCollider")
        {
            isAttacking = true;
            towerDetected = collision.GetComponent<towerParent>();
            attackOrder = StartCoroutine(enemyAttack());
        }

        if (collision.tag == "slowProjectile")
        {
            StartCoroutine(slowEnemy());
        }

        else if (collision.tag == "playerBound")
        {
            Debug.Log("YOU LOSE!!");
            Destroy(gameObject);
            GameManager.instance.youLose();
            Time.timeScale = 0;
        }
    }

    public void parentDelay()
    {
        enemyAnimator.Play(deathAnimation.name, 0, 0);
        StartCoroutine(countdownDelay());
        towerDetected = GetComponent<towerParent>();
    }
    // FOUND OF UTI DEATH ANIMATION
    // MULTIPLYING ENEMY BEHAVIOUR
    IEnumerator countdownDelay()
    {
        Debug.Log("COUNTDOWN STARTED");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    float doubleSpawn;
    public void multiplyNormal()
    {
        for (int i = 0; i <= 2; i++)
        {
            doubleSpawn -= 0.3f;
            // Instantiate Shoot Projectile
            GameObject shootProjectileOBJ = Instantiate(miniPrefabs, new Vector3(transform.position.x - doubleSpawn, transform.position.y, transform.position.z), Quaternion.identity, splitRoot);
            // Set its values
            shootProjectileOBJ.transform.localScale = new Vector3(3.5f, 1f, 1);
        }
    }

    public void multiplyBoss()
    {
        for (int i = 0; i <= 2; i++)
        {
            doubleSpawn -= 0.3f;
            // Instantiate Shoot Projectile
            GameObject shootProjectileOBJ = Instantiate(normalPrefabs, new Vector3(transform.position.x - doubleSpawn, transform.position.y, transform.position.z), Quaternion.identity, splitRoot);
            // Set its values
            shootProjectileOBJ.transform.localScale = new Vector3(3.5f, 1f, 1);
        }
    }
    // FROZEN ENEMY BEHAVIOUR
    [HideInInspector] public bool isFrozen;
    IEnumerator slowEnemy()
    {
        if (forenStackCount == 0)
        {
            isFrozen = true;
            startFrozenEffect();
        }

        forenStackCount++;

        yield return new WaitForSeconds(3.2f);

        forenStackCount--;

        if (forenStackCount == 0)
        {
            isFrozen = false;
            endFrozenEffect();
        }
    }

    private void startFrozenEffect()
    {
        this.GetComponent<SpriteRenderer>().color = Color.cyan;
        enemyMovementSpeed = enemyMovementSpeed / 2;
    }

    private void endFrozenEffect()
    {
        enemyMovementSpeed = enemyMovementSpeed * 2;
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
