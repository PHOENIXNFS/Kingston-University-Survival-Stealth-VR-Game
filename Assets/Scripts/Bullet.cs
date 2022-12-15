using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float BulletLifetime;

    private void Start()
    {
        Destroy(gameObject, BulletLifetime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.GetComponentInParent<Player>())
        {
            //Debug.Log("Player Is Hit");
            //player.PlayerHealth -= 20.0f;
            Player.PlayerHealth -= 1.0f;
            //Debug.Log("Player Health is : " + Player.PlayerHealth);
        }
    }


}
