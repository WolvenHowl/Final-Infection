using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int playerMaxHealth = 100;
    [SerializeField] public int playerHealth = 100;
    [SerializeField] public int playerAmmo = 100;
    [SerializeField] private float playerInfectionBar = 100;

    public HealthBar healthBar;

    private void Start() 
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    public void PlayerDamaged(int damage)
    {
        if(playerHealth > damage)
        {
            //Remove health
            playerHealth -= damage;
            
            //Decrease health on players Hud
            healthBar.SetHealth(playerHealth);
        }
        else if(playerHealth <= damage)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        Debug.Log("Player has died!");
    }
}
