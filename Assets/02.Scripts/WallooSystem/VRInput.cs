using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class VRInput : MonoBehaviour
{
    public InputActionReference m_RightActivateRef;
    public InputActionAsset m_ActionAsset;
    
    private void OnEnable()
    {
        m_ActionAsset.Enable();
        
        m_RightActivateRef.action.performed += ActivateRight;
        m_RightActivateRef.action.canceled += CancleActivateRight;
    }

    public static bool InputTrigger()
    {
        bool triggerValue;

        return InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue;
    }

    private void ActivateRight(InputAction.CallbackContext obj)
    {
    }

    private void CancleActivateRight(InputAction.CallbackContext obj)
    {
    }
}
