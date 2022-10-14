using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsScript : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 50f;
    [SerializeField] private float enemyDamage = 15f;
    [SerializeField] private PlayerStatsScript statsPlayer;

    public void TakeDamage(float ammount)
    {
        enemyHealth -= ammount;
        if(enemyHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        //OnPlayerHit
        statsPlayer.PlayerDamaged(enemyDamage);
    }
}
