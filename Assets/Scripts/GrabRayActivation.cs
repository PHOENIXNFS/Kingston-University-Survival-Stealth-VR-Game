using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabRayActivation : MonoBehaviour
{
    public GameObject LeftVRGrabRay;
    public GameObject RightVRGrabRay;

    public XRDirectInteractor LeftHandVRDirectInteractor;
    public XRDirectInteractor RightHandVRDirectInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftVRGrabRay.SetActive(LeftHandVRDirectInteractor.interactablesSelected.Count == 0);
        RightVRGrabRay.SetActive(RightHandVRDirectInteractor.interactablesSelected.Count == 0);

    }
}
