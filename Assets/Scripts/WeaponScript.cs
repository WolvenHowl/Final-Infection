using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float weaponDamage = 10f;
    [SerializeField] private float weaponRange = 15f;
    [SerializeField] private Camera playerCamera;

    private void Start() 
    {
        playerCamera = gameObject.GetComponent<Camera>();
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
        RaycastHit hit;
        //Only if something is hit
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weaponRange))
        {
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
            if(enemy != null)
            {
                enemy.TakeDamage(weaponDamage);
            }
        }
    }
}
