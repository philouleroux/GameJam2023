//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/PlayerInputs.inputactions
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

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""88dd793f-ebf2-429e-b4cf-303b4e1a6546"",
            ""actions"": [
                {
                    ""name"": ""Axis"",
                    ""type"": ""Value"",
                    ""id"": ""94649b09-ba03-4d70-95a6-c137136465d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bf5f5227-36c0-43e2-9936-da9ae7a1a429"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3bb379ca-043f-4fbe-9132-737ac2736783"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a969125-085f-43df-81f7-33ab49bb587a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""76552023-c323-4af5-9076-8fb29fe97c84"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b10ad257-2e2a-4020-93bc-d8c8b3673b43"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Movement_P2"",
            ""id"": ""d61046aa-d761-4475-8d6e-65520bd0bf5c"",
            ""actions"": [
                {
                    ""name"": ""Axis"",
                    ""type"": ""Value"",
                    ""id"": ""5330962d-d257-4c06-ad93-e8099f4fd252"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""693f2d8f-7ad3-4608-ba84-66329e833e72"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5bb4ee87-49e9-418a-b7d4-08fb466584d8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""00df5b91-c0cd-4f32-949d-ab35f3edf194"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a15848bc-1734-4e2b-b8ed-e7146b323ddf"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""92fcff3a-5e02-4ee6-b326-f92841c06bae"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Interactions"",
            ""id"": ""bb165186-238d-4413-a3c9-c445254df473"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7ac1e20e-4b94-491a-9f0c-dd63f5524dfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d9cdf51-8a56-40df-b46e-54d671fff0e1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interactions_P2"",
            ""id"": ""b03eab90-2d39-49a5-b162-7845a73e30f7"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d4ef7b05-3dac-4615-a365-3195d861a4ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c346e713-8422-4481-b155-290a73b08fee"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Axis = m_Movement.FindAction("Axis", throwIfNotFound: true);
        // Movement_P2
        m_Movement_P2 = asset.FindActionMap("Movement_P2", throwIfNotFound: true);
        m_Movement_P2_Axis = m_Movement_P2.FindAction("Axis", throwIfNotFound: true);
        // Interactions
        m_Interactions = asset.FindActionMap("Interactions", throwIfNotFound: true);
        m_Interactions_Interact = m_Interactions.FindAction("Interact", throwIfNotFound: true);
        // Interactions_P2
        m_Interactions_P2 = asset.FindActionMap("Interactions_P2", throwIfNotFound: true);
        m_Interactions_P2_Interact = m_Interactions_P2.FindAction("Interact", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Axis;
    public struct MovementActions
    {
        private @PlayerInputs m_Wrapper;
        public MovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Axis => m_Wrapper.m_Movement_Axis;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Axis.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAxis;
                @Axis.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAxis;
                @Axis.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAxis;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Axis.started += instance.OnAxis;
                @Axis.performed += instance.OnAxis;
                @Axis.canceled += instance.OnAxis;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Movement_P2
    private readonly InputActionMap m_Movement_P2;
    private IMovement_P2Actions m_Movement_P2ActionsCallbackInterface;
    private readonly InputAction m_Movement_P2_Axis;
    public struct Movement_P2Actions
    {
        private @PlayerInputs m_Wrapper;
        public Movement_P2Actions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Axis => m_Wrapper.m_Movement_P2_Axis;
        public InputActionMap Get() { return m_Wrapper.m_Movement_P2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement_P2Actions set) { return set.Get(); }
        public void SetCallbacks(IMovement_P2Actions instance)
        {
            if (m_Wrapper.m_Movement_P2ActionsCallbackInterface != null)
            {
                @Axis.started -= m_Wrapper.m_Movement_P2ActionsCallbackInterface.OnAxis;
                @Axis.performed -= m_Wrapper.m_Movement_P2ActionsCallbackInterface.OnAxis;
                @Axis.canceled -= m_Wrapper.m_Movement_P2ActionsCallbackInterface.OnAxis;
            }
            m_Wrapper.m_Movement_P2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Axis.started += instance.OnAxis;
                @Axis.performed += instance.OnAxis;
                @Axis.canceled += instance.OnAxis;
            }
        }
    }
    public Movement_P2Actions @Movement_P2 => new Movement_P2Actions(this);

    // Interactions
    private readonly InputActionMap m_Interactions;
    private IInteractionsActions m_InteractionsActionsCallbackInterface;
    private readonly InputAction m_Interactions_Interact;
    public struct InteractionsActions
    {
        private @PlayerInputs m_Wrapper;
        public InteractionsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interactions_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interactions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionsActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionsActions instance)
        {
            if (m_Wrapper.m_InteractionsActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InteractionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InteractionsActions @Interactions => new InteractionsActions(this);

    // Interactions_P2
    private readonly InputActionMap m_Interactions_P2;
    private IInteractions_P2Actions m_Interactions_P2ActionsCallbackInterface;
    private readonly InputAction m_Interactions_P2_Interact;
    public struct Interactions_P2Actions
    {
        private @PlayerInputs m_Wrapper;
        public Interactions_P2Actions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interactions_P2_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interactions_P2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Interactions_P2Actions set) { return set.Get(); }
        public void SetCallbacks(IInteractions_P2Actions instance)
        {
            if (m_Wrapper.m_Interactions_P2ActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_Interactions_P2ActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Interactions_P2ActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Interactions_P2ActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_Interactions_P2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public Interactions_P2Actions @Interactions_P2 => new Interactions_P2Actions(this);
    public interface IMovementActions
    {
        void OnAxis(InputAction.CallbackContext context);
    }
    public interface IMovement_P2Actions
    {
        void OnAxis(InputAction.CallbackContext context);
    }
    public interface IInteractionsActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IInteractions_P2Actions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}
