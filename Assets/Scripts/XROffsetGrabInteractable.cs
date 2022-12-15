using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    public Vector3 InitialLocalPosition;
    public Quaternion InitialLocalRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }

        else
        {
            InitialLocalPosition = attachTransform.localPosition;
            InitialLocalRotation = attachTransform.localRotation;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }

        else
        {
            attachTransform.localPosition = InitialLocalPosition;
            attachTransform.localRotation = InitialLocalRotation;
        }

        base.OnSelectEntered(args);
    }

}
