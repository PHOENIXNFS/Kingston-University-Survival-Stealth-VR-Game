using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip Song;
    public AudioClip WarningSound;
    public Enemy enemy;

    private void Start()
    { 
        GetComponent<AudioSource>().clip = Song;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
        
    }

    private void Update()
    {
        EnemyChecker();
    }

    private void EnemyChecker()
    {
        if(enemy.bIsPlayerInSight)
        {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = WarningSound;
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().Play();
            
        }

        if (!enemy.bIsPlayerInSight)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = Song;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
    }




}
