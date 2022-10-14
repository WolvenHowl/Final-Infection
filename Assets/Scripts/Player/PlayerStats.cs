using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100;
    [SerializeField] public int playerAmmo = 100;
    [SerializeField] private float playerInfectionBar = 100;
    
    //PlayerHealthUI
    [SerializeField] private TMP_Text healthCountUI;

    private void Start() 
    {
        healthCountUI = GameObject.Find("HealthCount").GetComponent<TMP_Text>();
        healthCountUI.text = (playerHealth).ToString();
    }

    public void PlayerDamaged(float damage)
    {
        if(playerHealth > damage)
        {
            //Remove health
            playerHealth -= damage;
            
            //Decrease health on players Hud
            healthCountUI.text = (playerHealth).ToString();
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
