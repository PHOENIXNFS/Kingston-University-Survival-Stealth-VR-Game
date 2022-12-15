using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public static float PlayerHealth;
    public float PlayerMaxHealth;
    public GameObject PlayerHeadLocation;
    [HideInInspector] public bool bIsPlayerDead;
    public HealthBar playerHealthBar;

    public void Awake()
    {
        bIsPlayerDead = false;
        PlayerHealth = PlayerMaxHealth;
        playerHealthBar.SetMaxHealth(PlayerMaxHealth);

    }

    private void Update()
    {
        //Debug.Log("Player Health is : " + PlayerHealth);
        GetPlayerHealth();
        IsPlayerDead();
    }
    public Vector3 GetPlayerHeadPosition()
    {
        
        return PlayerHeadLocation.transform.position;
        
    }

    public bool IsPlayerDead()
    {
        if (PlayerHealth <= 0)
        {
            bIsPlayerDead = true;
        }

        return bIsPlayerDead;
    }

    public void GetPlayerHealth()
    {
        playerHealthBar.SetCurrentHealth(PlayerHealth);
    }

}
