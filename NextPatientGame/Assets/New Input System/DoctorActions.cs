//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/New Input System/DoctorActions.inputactions
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

public partial class @DoctorActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DoctorActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DoctorActions"",
    ""maps"": [
        {
            ""name"": ""Doktor_Map"",
            ""id"": ""2a04acea-4ace-4025-8e5b-fcad3d9d8442"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""816c3bc9-c6f9-42fb-af13-cd59fa92cfc5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b6635242-258f-4e0a-9de3-45f309e5f6a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""47dd5bf0-6ff3-4fea-9a39-6eb08fe36bd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""44143749-5e49-4fa9-9268-e10ab021727c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7449b2e0-8d78-45be-875c-b5ddcd25f057"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2f343beb-579e-47bb-9d52-d4316577dc9f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0d1e8a01-9a6d-4c9b-a895-231e4f7de7d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""38903c87-1f02-4eca-a284-91176f7897da"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bccca3f0-2004-4117-be49-6d3bd297aad3"",
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
                    ""id"": ""a2db3dc2-0407-4746-b2d6-798d0f0b79b2"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Doktor_Map
        m_Doktor_Map = asset.FindActionMap("Doktor_Map", throwIfNotFound: true);
        m_Doktor_Map_Movement = m_Doktor_Map.FindAction("Movement", throwIfNotFound: true);
        m_Doktor_Map_Jump = m_Doktor_Map.FindAction("Jump", throwIfNotFound: true);
        m_Doktor_Map_Run = m_Doktor_Map.FindAction("Run", throwIfNotFound: true);
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

    // Doktor_Map
    private readonly InputActionMap m_Doktor_Map;
    private List<IDoktor_MapActions> m_Doktor_MapActionsCallbackInterfaces = new List<IDoktor_MapActions>();
    private readonly InputAction m_Doktor_Map_Movement;
    private readonly InputAction m_Doktor_Map_Jump;
    private readonly InputAction m_Doktor_Map_Run;
    public struct Doktor_MapActions
    {
        private @DoctorActions m_Wrapper;
        public Doktor_MapActions(@DoctorActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Doktor_Map_Movement;
        public InputAction @Jump => m_Wrapper.m_Doktor_Map_Jump;
        public InputAction @Run => m_Wrapper.m_Doktor_Map_Run;
        public InputActionMap Get() { return m_Wrapper.m_Doktor_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Doktor_MapActions set) { return set.Get(); }
        public void AddCallbacks(IDoktor_MapActions instance)
        {
            if (instance == null || m_Wrapper.m_Doktor_MapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Doktor_MapActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
        }

        private void UnregisterCallbacks(IDoktor_MapActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
        }

        public void RemoveCallbacks(IDoktor_MapActions instance)
        {
            if (m_Wrapper.m_Doktor_MapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDoktor_MapActions instance)
        {
            foreach (var item in m_Wrapper.m_Doktor_MapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Doktor_MapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Doktor_MapActions @Doktor_Map => new Doktor_MapActions(this);
    public interface IDoktor_MapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
