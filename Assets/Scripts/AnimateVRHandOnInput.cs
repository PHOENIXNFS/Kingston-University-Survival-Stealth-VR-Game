using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateVRHandOnInput : MonoBehaviour
{
    public InputActionProperty VRPinchHandAction;
    public InputActionProperty VRGripHandAction;
    public Animator HandAnimation;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float HandPinchTriggerValue = VRPinchHandAction.action.ReadValue<float>();
        HandAnimation.SetFloat("Trigger", HandPinchTriggerValue);

    
        float HandGripTriggerValue = VRGripHandAction.action.ReadValue<float>();
        HandAnimation.SetFloat("Grip", HandGripTriggerValue);

    }
}
