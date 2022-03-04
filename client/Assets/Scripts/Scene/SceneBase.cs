using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SceneBase : MonoBehaviour, PlayerControls.ICursorActions
{
    private PlayerControls m_controls = null;

    protected virtual void Awake()
    {
        m_controls = new PlayerControls();
        m_controls.Cursor.SetCallbacks(this);
    }

    protected virtual void OnEnable()
    {
        m_controls.Cursor.Enable();
    }

    protected virtual void OnDisable()
    {
        m_controls.Cursor.Disable();
    }

    private void PrintContext(string Label, InputAction.CallbackContext context)
    {
        //Debug.Log($"{Label} : {context}");
    }

    public virtual void OnOK(InputAction.CallbackContext context)
    {
        PrintContext("OnOK", context);
    }

    public virtual void OnCancel(InputAction.CallbackContext context)
    {
        PrintContext("OnCancel", context);
    }

    public virtual void OnUp(InputAction.CallbackContext context)
    {
        PrintContext("OnUp", context);
    }

    public virtual void OnLeft(InputAction.CallbackContext context)
    {
        PrintContext("OnLeft", context);
    }

    public virtual void OnDown(InputAction.CallbackContext context)
    {
        PrintContext("OnDown", context);
    }

    public virtual void OnRight(InputAction.CallbackContext context)
    {
        PrintContext("OnRight", context);
    }
}
