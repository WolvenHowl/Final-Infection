using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float weaponDamage = 10f;
    [SerializeField] private float weaponRange = 15f;
    [SerializeField] private Camera playerCamera;

    //PlayerAmmoUI
    [SerializeField] private PlayerStatsScript statsPlayer;
    [SerializeField] private TMP_Text ammoCountUI;

    private void Start() 
    {
        playerCamera = gameObject.GetComponent<Camera>();
        statsPlayer = transform.parent.GetComponent<PlayerStatsScript>();

        ammoCountUI = GameObject.Find("AmmoCount").GetComponent<TMP_Text>();
        ammoCountUI.text = (statsPlayer.playerAmmo).ToString();
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(statsPlayer.playerAmmo > 0)
        {
            //Decrease ammo when player shoots
            statsPlayer.playerAmmo -= 1;
            ammoCountUI.text = (statsPlayer.playerAmmo).ToString();

            RaycastHit hit;
            //Only if something is hit
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weaponRange))
            {
                EnemyStatsScript enemy = hit.transform.GetComponent<EnemyStatsScript>();
                if(enemy != null)
                {
                    enemy.TakeDamage(weaponDamage);
                }
            }
        }
    }
}
