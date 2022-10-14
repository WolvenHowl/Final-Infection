using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer = 6;

    //Attacking
    public float timeBetweenAttacks = 2f;
    bool alreadyAttacked;

    //States
    public float sightRange = 1000f;
    public float attackRange = 2f;
    public bool playerInSightRange, playerInAttackRange;
    
    [SerializeField] private float enemyHealth = 50f;
    [SerializeField] private float enemyDamage = 15f;
    [SerializeField] private PlayerStats statsPlayer;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        statsPlayer = player.GetComponent<PlayerStats>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            statsPlayer.PlayerDamaged(enemyDamage);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float ammount)
    {
        enemyHealth -= ammount;
        if(enemyHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
