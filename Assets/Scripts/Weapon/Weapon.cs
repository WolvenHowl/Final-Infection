using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage = 10;
    [SerializeField] private float weaponRange = 15f;
    [SerializeField] private Camera playerCamera;

    //PlayerAmmoUI
    [SerializeField] private PlayerStats statsPlayer;
    [SerializeField] private TMP_Text ammoCountUI;

    public AudioSource playSoundOnShoot;

    private void Start() 
    {
        playerCamera = gameObject.GetComponent<Camera>();
        statsPlayer = transform.parent.GetComponent<PlayerStats>();

        ammoCountUI = GameObject.Find("AmmoCount").GetComponent<TMP_Text>();
        ammoCountUI.text = (statsPlayer.playerAmmo).ToString();
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        ammoCountUI.text = (statsPlayer.playerAmmo).ToString();
    }

    void Shoot()
    {
        if(statsPlayer.playerAmmo > 0)
        {
            playSoundOnShoot.Play();
            //Decrease ammo when player shoots
            statsPlayer.playerAmmo -= 1;
            ammoCountUI.text = (statsPlayer.playerAmmo).ToString();

            RaycastHit hit;
            //Only if something is hit
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weaponRange))
            {
                
                Debug.Log(hit.transform.name);
                EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
                if(enemy != null)
                {
                    enemy.TakeDamage(weaponDamage);
                }
            }
        }
    }
}
