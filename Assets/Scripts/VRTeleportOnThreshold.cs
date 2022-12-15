using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class VRTeleportOnThreshold : MonoBehaviour
{
    public GameObject leftTeleportVRHand;
    public GameObject rightTeleportVRHand;

    public InputActionProperty leftHandActivate;
    public InputActionProperty rightHandActivate;

    //public InputActionProperty leftHandCancel;
    //public InputActionProperty rightHandCancel;


    // Update is called once per frame
    void Update()
    {
        leftTeleportVRHand.SetActive(leftHandActivate.action.ReadValue<float>() > 0.2f);
        rightTeleportVRHand.SetActive(rightHandActivate.action.ReadValue<float>() > 0.2f);
    }
}
