using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [HideInInspector] public bool bIsPlayerOnFinishPoint;

    private void Awake()
    {
        bIsPlayerOnFinishPoint = false;
    }

    //private void Update()
    //{
    //    Debug.Log("Player On Finish Point: " + bIsPlayerOnFinishPoint);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Player>())
        {
            bIsPlayerOnFinishPoint = true;
        }
    }
}
