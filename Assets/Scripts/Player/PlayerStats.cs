using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int playerMaxHealth = 100;
    [SerializeField] public int playerHealth = 100;
    [SerializeField] public int playerAmmo = 100;
    [SerializeField] public int playerMaxInfectionLevel = 100;
    [SerializeField] public int playerInfectionLevel = 75;

    public HealthBar healthBar;
    public InfectionBar infecBar;

    public delegate void syringeUsed();
    public static event syringeUsed onSyringeUsed;

    private void Start() 
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(playerMaxHealth);
        
        infecBar = GameObject.Find("InfectionBar").GetComponent<InfectionBar>();
        infecBar.SetMaxSlider(playerMaxInfectionLevel);

        InvokeRepeating("DecreaseInfection", 1f, 1f);
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
        SceneManager.LoadScene(sceneBuildIndex: 2);
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 7)
        {
            playerInfectionLevel += 5;

            //Decrease health on players Hud
            infecBar.SetSlider(playerInfectionLevel);

            if(onSyringeUsed != null)
            {
                 onSyringeUsed();
            }

            Destroy(other.gameObject);
        }
    }

    void DecreaseInfection()
    {
        Debug.Log("ran");
        playerInfectionLevel -= 1;

        //Decrease health on players Hud
        infecBar.SetSlider(playerInfectionLevel);
    }
}
