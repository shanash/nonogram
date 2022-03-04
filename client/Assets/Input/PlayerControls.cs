//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Cursor"",
            ""id"": ""bc914028-c4b3-4709-83b0-cbe85c99c5a1"",
            ""actions"": [
                {
                    ""name"": ""OK"",
                    ""type"": ""Button"",
                    ""id"": ""e6045198-e249-4223-ab45-84dfd8783a7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""963df8f7-4391-47df-a4ca-4cea52a28f71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""4e665a55-8c76-4cf5-ba0c-b94df41828f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""3233327d-4d66-4123-b2c8-28bc59f3fda8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""869a7fd3-4b9e-4ad9-a856-8a71df77ea80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""03624143-74ea-420d-971d-11edb9fa98a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""667149dd-dc97-4f5e-9b7b-80d5c498a68a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1de6e660-1b67-4aa2-a789-972d8879341f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b24c54d-c377-456b-8b85-520838863976"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05dbcbbf-954a-42f6-8829-d5ebdfec4829"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ab9d4aa-d817-4e60-982f-65f93ad3ff86"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5666ef83-6af8-4c90-965d-125b532612c9"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""396543f7-6341-4db8-90b9-d1db9c739942"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfcb706d-8fb0-4200-924f-3aab2a8e8b77"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""532b1923-8d80-4171-881e-970a61e99501"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2a49c84-5726-4516-bb42-3d97dc9a44bd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be27b406-4f3a-4ce5-8e5a-eec45594db59"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2e5a671-a79e-4656-a628-143fc97986cb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cursor
        m_Cursor = asset.FindActionMap("Cursor", throwIfNotFound: true);
        m_Cursor_OK = m_Cursor.FindAction("OK", throwIfNotFound: true);
        m_Cursor_Cancel = m_Cursor.FindAction("Cancel", throwIfNotFound: true);
        m_Cursor_Up = m_Cursor.FindAction("Up", throwIfNotFound: true);
        m_Cursor_Left = m_Cursor.FindAction("Left", throwIfNotFound: true);
        m_Cursor_Down = m_Cursor.FindAction("Down", throwIfNotFound: true);
        m_Cursor_Right = m_Cursor.FindAction("Right", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Cursor
    private readonly InputActionMap m_Cursor;
    private ICursorActions m_CursorActionsCallbackInterface;
    private readonly InputAction m_Cursor_OK;
    private readonly InputAction m_Cursor_Cancel;
    private readonly InputAction m_Cursor_Up;
    private readonly InputAction m_Cursor_Left;
    private readonly InputAction m_Cursor_Down;
    private readonly InputAction m_Cursor_Right;
    public struct CursorActions
    {
        private @PlayerControls m_Wrapper;
        public CursorActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @OK => m_Wrapper.m_Cursor_OK;
        public InputAction @Cancel => m_Wrapper.m_Cursor_Cancel;
        public InputAction @Up => m_Wrapper.m_Cursor_Up;
        public InputAction @Left => m_Wrapper.m_Cursor_Left;
        public InputAction @Down => m_Wrapper.m_Cursor_Down;
        public InputAction @Right => m_Wrapper.m_Cursor_Right;
        public InputActionMap Get() { return m_Wrapper.m_Cursor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CursorActions set) { return set.Get(); }
        public void SetCallbacks(ICursorActions instance)
        {
            if (m_Wrapper.m_CursorActionsCallbackInterface != null)
            {
                @OK.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnOK;
                @OK.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnOK;
                @OK.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnOK;
                @Cancel.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnCancel;
                @Up.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnUp;
                @Left.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnLeft;
                @Down.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnDown;
                @Right.started -= m_Wrapper.m_CursorActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_CursorActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_CursorActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_CursorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OK.started += instance.OnOK;
                @OK.performed += instance.OnOK;
                @OK.canceled += instance.OnOK;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public CursorActions @Cursor => new CursorActions(this);
    public interface ICursorActions
    {
        void OnOK(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
