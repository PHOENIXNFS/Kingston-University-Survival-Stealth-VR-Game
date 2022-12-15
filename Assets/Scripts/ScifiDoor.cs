using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScifiDoor : MonoBehaviour
{
    [SerializeField] private Animator DoorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>())
        {
            DoorAnimator.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>())
        {
            DoorAnimator.SetBool("character_nearby", false);
        }
    }

}
