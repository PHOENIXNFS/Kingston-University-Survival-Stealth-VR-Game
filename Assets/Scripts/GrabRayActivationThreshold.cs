using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class GrabRayActivationThreshold : MonoBehaviour
{
    public GameObject VRLeftHandGrabRay;
    public GameObject VRRightHandGrabRay;

    public InputActionProperty leftHandGrabRayActivate;
    public InputActionProperty rightHandGrabRayActivate;

    public InputActionProperty leftHandGrabRayCancel;
    public InputActionProperty rightHandGrabRayCancel;

    // Update is called once per frame
    void Update()
    {
        VRLeftHandGrabRay.SetActive(leftHandGrabRayCancel.action.ReadValue<float>() == 0 && leftHandGrabRayActivate.action.ReadValue<float>() > 0.2f);
        VRRightHandGrabRay.SetActive(rightHandGrabRayCancel.action.ReadValue<float>() == 0 && rightHandGrabRayActivate.action.ReadValue<float>() > 0.2f);
    }
}
