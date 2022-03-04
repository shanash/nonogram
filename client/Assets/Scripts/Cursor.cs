using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Cursor : MonoBehaviour
{

    public void OnPaint(InputAction.CallbackContext context)
    {
        Debug.Log($"OnPaint : {context}");
    }

    public void OnX(InputAction.CallbackContext context)
    {
        Debug.Log($"OnX : {context}");
    }

    public void OnUpArrow(InputAction.CallbackContext context)
    {
        
    }

    public void OnDownArrow(InputAction.CallbackContext context)
    {

    }

    public void OnLeftArrow(InputAction.CallbackContext context)
    {

    }

    public void OnRightArrow(InputAction.CallbackContext context)
    {

    }
}
