using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarFollowsPlayerCamera : MonoBehaviour
{
    public Transform PlayerCamera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + PlayerCamera.forward);
    }
}
