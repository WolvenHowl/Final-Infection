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
    
    //Recoil Animation
    [SerializeField] private Animator recoilAnimator;
    private bool didShoot = false;

    private void Start() 
    {
        playerCamera = gameObject.GetComponent<Camera>();
        statsPlayer = transform.parent.GetComponent<PlayerStats>();

        ammoCountUI = GameObject.Find("AmmoCount").GetComponent<TMP_Text>();
        ammoCountUI.text = (statsPlayer.playerAmmo).ToString();

        //Recoil
        recoilAnimator = gameObject.transform.GetChild(0).GetComponent<Animator>();
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
            if(recoilAnimator != null)
            {
                if(!didShoot)
                {
                    CancelInvoke(nameof(AttackAfter1Sec));
                    recoilAnimator.SetTrigger("onShoot");
                    didShoot = true;
                    Invoke(nameof(resetRecoilAfterAttack), 3f);
                }
            }

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

    private void resetRecoilAfterAttack()
    {
        recoilAnimator.ResetTrigger("onShoot");
        didShoot = false;
    }
}
