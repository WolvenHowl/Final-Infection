using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks = 2f;
    bool alreadyAttacked;

    //States
    public float sightRange = 1000f;
    public float attackRange = 1.25f;
    public bool playerInSightRange, playerInAttackRange;
    
    [SerializeField] private int enemyHealth = 50;
    [SerializeField] private int enemyDamage = 15;
    [SerializeField] private PlayerStats statsPlayer;

    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isAttacking;
    [SerializeField] private bool isDead;

    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        statsPlayer = player.GetComponent<PlayerStats>();
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if(!isDead)
        {
            if (playerInSightRange && !playerInAttackRange) 
            {
                ChasePlayer();
                if(enemyAnimator != null)
                {
                    if(isAttacking || !isWalking && !isDead)
                    {
                        enemyAnimator.ResetTrigger("onAttack");
                        enemyAnimator.SetTrigger("onWalk");
                        isAttacking = false;
                        isWalking = true;
                        isDead = false;
                    }
                }
            }

            if (playerInAttackRange && playerInSightRange) 
            {
                AttackPlayer();
                if(enemyAnimator != null)
                {
                    if(!isAttacking || isWalking && !isDead)
                    {
                        enemyAnimator.ResetTrigger("onWalk");
                        enemyAnimator.SetTrigger("onAttack");
                        isAttacking = true;
                        isWalking = false;
                        isDead = false;
                    }
                }
            }
        }
    }
    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
        CancelInvoke(nameof(AttackAfter1Sec));
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Invoke(nameof(AttackAfter1Sec), 1f);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void AttackAfter1Sec()
    {
        statsPlayer.PlayerDamaged(enemyDamage);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int ammount)
    {
        enemyHealth -= ammount;
        if(enemyHealth <= 0f)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<AudioSource>().enabled = false;
            if(enemyAnimator != null)
            {
                if(!isDead)
                {
                    enemyAnimator.Rebind();
                    enemyAnimator.SetTrigger("onDeath");
                    isAttacking = false;
                    isWalking = false;
                    isDead = true;
                    
                    if(OnEnemyKilled != null)
                    {
                        OnEnemyKilled();
                    }
                    Invoke(nameof(DestroyCorpseAfter10Seconds), 10f);
                }
            }
        }
    }
    private void DestroyCorpseAfter10Seconds()
    {
        statsPlayer.playerAmmo += 10;
        Destroy(gameObject);
    }
}
