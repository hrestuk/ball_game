//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/Controller.inputactions
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

public partial class @Controller: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""a07e2b00-48bd-464e-acee-b1f65fba20a7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d33f29d1-b202-4199-a6ce-92c3a455bf4f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a6cf7a89-ccc8-43d0-af76-4c2e11de2e5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchToNormalMode"",
                    ""type"": ""Button"",
                    ""id"": ""3b7ac7a5-24f3-4a66-949f-763ff37dac88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchToHeavyMode"",
                    ""type"": ""Button"",
                    ""id"": ""92694eaa-4114-4199-a046-487cf0e8e888"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchToMagneticMode"",
                    ""type"": ""Button"",
                    ""id"": ""b1d1ad9d-9c51-447d-a037-cb0a8bbf7aa3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f38e8c1-ba72-4ced-89f6-55d6f6389c12"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7dcb0b00-7d68-4792-8c6b-cfb3f7033e17"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""24ab1d2b-0e70-4c53-b0f3-ec23ae3d218f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""da556fd2-fbaa-4683-9bdb-28db2c0589d7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""f9993a76-1f16-4dd1-8066-a90c26821085"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""56901c81-5e02-4191-b598-a4fe1f498499"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e32f328-f5c9-4b78-8598-fc61fc38731c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffb44aec-bd9a-4856-bf2f-70b801331344"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchToNormalMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e387afd-16fa-453e-96ca-b67b198a0e5d"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchToHeavyMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3c2fae6-9ad6-44ca-870d-f2fdcc7bd6b3"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchToMagneticMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_SwitchToNormalMode = m_Player.FindAction("SwitchToNormalMode", throwIfNotFound: true);
        m_Player_SwitchToHeavyMode = m_Player.FindAction("SwitchToHeavyMode", throwIfNotFound: true);
        m_Player_SwitchToMagneticMode = m_Player.FindAction("SwitchToMagneticMode", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_SwitchToNormalMode;
    private readonly InputAction m_Player_SwitchToHeavyMode;
    private readonly InputAction m_Player_SwitchToMagneticMode;
    public struct PlayerActions
    {
        private @Controller m_Wrapper;
        public PlayerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @SwitchToNormalMode => m_Wrapper.m_Player_SwitchToNormalMode;
        public InputAction @SwitchToHeavyMode => m_Wrapper.m_Player_SwitchToHeavyMode;
        public InputAction @SwitchToMagneticMode => m_Wrapper.m_Player_SwitchToMagneticMode;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @SwitchToNormalMode.started += instance.OnSwitchToNormalMode;
            @SwitchToNormalMode.performed += instance.OnSwitchToNormalMode;
            @SwitchToNormalMode.canceled += instance.OnSwitchToNormalMode;
            @SwitchToHeavyMode.started += instance.OnSwitchToHeavyMode;
            @SwitchToHeavyMode.performed += instance.OnSwitchToHeavyMode;
            @SwitchToHeavyMode.canceled += instance.OnSwitchToHeavyMode;
            @SwitchToMagneticMode.started += instance.OnSwitchToMagneticMode;
            @SwitchToMagneticMode.performed += instance.OnSwitchToMagneticMode;
            @SwitchToMagneticMode.canceled += instance.OnSwitchToMagneticMode;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @SwitchToNormalMode.started -= instance.OnSwitchToNormalMode;
            @SwitchToNormalMode.performed -= instance.OnSwitchToNormalMode;
            @SwitchToNormalMode.canceled -= instance.OnSwitchToNormalMode;
            @SwitchToHeavyMode.started -= instance.OnSwitchToHeavyMode;
            @SwitchToHeavyMode.performed -= instance.OnSwitchToHeavyMode;
            @SwitchToHeavyMode.canceled -= instance.OnSwitchToHeavyMode;
            @SwitchToMagneticMode.started -= instance.OnSwitchToMagneticMode;
            @SwitchToMagneticMode.performed -= instance.OnSwitchToMagneticMode;
            @SwitchToMagneticMode.canceled -= instance.OnSwitchToMagneticMode;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSwitchToNormalMode(InputAction.CallbackContext context);
        void OnSwitchToHeavyMode(InputAction.CallbackContext context);
        void OnSwitchToMagneticMode(InputAction.CallbackContext context);
    }
}
