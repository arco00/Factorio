//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Script/Input/AllInputs.inputactions
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

public partial class @AllInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @AllInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AllInputs"",
    ""maps"": [
        {
            ""name"": ""InputTest"",
            ""id"": ""e7ffda0b-93d4-4027-8ba4-b4529c80f4d6"",
            ""actions"": [
                {
                    ""name"": ""LaunchCraft"",
                    ""type"": ""Button"",
                    ""id"": ""cb17eb80-6981-4219-8800-ca0229a80b58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlaceObject"",
                    ""type"": ""Button"",
                    ""id"": ""3d03736c-1cf1-4a79-94a6-ce9982fd8542"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72382144-6211-4e34-b70c-0379a5fd6605"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LaunchCraft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9591cd7-9a3f-4825-820a-60bd5e9318f0"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputTest
        m_InputTest = asset.FindActionMap("InputTest", throwIfNotFound: true);
        m_InputTest_LaunchCraft = m_InputTest.FindAction("LaunchCraft", throwIfNotFound: true);
        m_InputTest_PlaceObject = m_InputTest.FindAction("PlaceObject", throwIfNotFound: true);
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

    // InputTest
    private readonly InputActionMap m_InputTest;
    private List<IInputTestActions> m_InputTestActionsCallbackInterfaces = new List<IInputTestActions>();
    private readonly InputAction m_InputTest_LaunchCraft;
    private readonly InputAction m_InputTest_PlaceObject;
    public struct InputTestActions
    {
        private @AllInputs m_Wrapper;
        public InputTestActions(@AllInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LaunchCraft => m_Wrapper.m_InputTest_LaunchCraft;
        public InputAction @PlaceObject => m_Wrapper.m_InputTest_PlaceObject;
        public InputActionMap Get() { return m_Wrapper.m_InputTest; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputTestActions set) { return set.Get(); }
        public void AddCallbacks(IInputTestActions instance)
        {
            if (instance == null || m_Wrapper.m_InputTestActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputTestActionsCallbackInterfaces.Add(instance);
            @LaunchCraft.started += instance.OnLaunchCraft;
            @LaunchCraft.performed += instance.OnLaunchCraft;
            @LaunchCraft.canceled += instance.OnLaunchCraft;
            @PlaceObject.started += instance.OnPlaceObject;
            @PlaceObject.performed += instance.OnPlaceObject;
            @PlaceObject.canceled += instance.OnPlaceObject;
        }

        private void UnregisterCallbacks(IInputTestActions instance)
        {
            @LaunchCraft.started -= instance.OnLaunchCraft;
            @LaunchCraft.performed -= instance.OnLaunchCraft;
            @LaunchCraft.canceled -= instance.OnLaunchCraft;
            @PlaceObject.started -= instance.OnPlaceObject;
            @PlaceObject.performed -= instance.OnPlaceObject;
            @PlaceObject.canceled -= instance.OnPlaceObject;
        }

        public void RemoveCallbacks(IInputTestActions instance)
        {
            if (m_Wrapper.m_InputTestActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputTestActions instance)
        {
            foreach (var item in m_Wrapper.m_InputTestActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputTestActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputTestActions @InputTest => new InputTestActions(this);
    public interface IInputTestActions
    {
        void OnLaunchCraft(InputAction.CallbackContext context);
        void OnPlaceObject(InputAction.CallbackContext context);
    }
}
