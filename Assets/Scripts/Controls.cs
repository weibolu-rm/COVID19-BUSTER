//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/Scripts/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""a927730d-aca9-4bed-a272-7f458df5d461"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5617bbab-0d86-43fe-8599-0b941ff98cba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5b5acb19-4dd9-4cab-b071-68e449291c11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""befee03e-3536-4ecd-843f-d33e6ea25473"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aae08f3e-c8c6-4f39-8d87-c58ae6814177"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""205dbf9f-d7eb-4c30-a7f0-2206e2cf2d88"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c95f77b-8180-40ab-88ad-8718ec170892"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1bb653f9-dd2a-4737-b888-d3d8d37f6aed"",
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
                    ""id"": ""72a7c4d5-bc73-4c1c-9c58-6c693dea7be7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Action"",
            ""id"": ""d5c105a9-d073-40e2-85c5-ca35e4069764"",
            ""actions"": [
                {
                    ""name"": ""MaskShoot"",
                    ""type"": ""Button"",
                    ""id"": ""d31f1e34-00ce-40e1-944e-6c595bdfd447"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""VaccineShoot"",
                    ""type"": ""Button"",
                    ""id"": ""26cebdcb-7c88-45a4-a36f-8b68d422be3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""IsolationInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""ecb2bbe6-ea7c-4e42-a783-356b310426bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Disinfect"",
                    ""type"": ""Button"",
                    ""id"": ""813d7dc2-c883-454e-8e75-ec074a5bc191"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scream"",
                    ""type"": ""Button"",
                    ""id"": ""fcba0d0f-ee03-4f37-8251-00df0aa0734f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpecialMode"",
                    ""type"": ""Button"",
                    ""id"": ""c782dd59-2b30-4b22-867b-878080a6ea82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d62282d-b6e9-407c-a046-d96cb8277650"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MaskShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dead9e1c-8132-4eab-9420-206965d2d2e4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VaccineShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d62a5fed-ca95-45d8-90c4-65b28698c7e7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IsolationInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30f5ebce-e572-4954-990c-c499dd6122f2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disinfect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cd5e5ff-1219-4af9-adf9-cb65d64c2ca6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scream"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f43e5517-b71c-4571-95aa-e6a698113e3e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_MaskShoot = m_Action.FindAction("MaskShoot", throwIfNotFound: true);
        m_Action_VaccineShoot = m_Action.FindAction("VaccineShoot", throwIfNotFound: true);
        m_Action_IsolationInteraction = m_Action.FindAction("IsolationInteraction", throwIfNotFound: true);
        m_Action_Disinfect = m_Action.FindAction("Disinfect", throwIfNotFound: true);
        m_Action_Scream = m_Action.FindAction("Scream", throwIfNotFound: true);
        m_Action_SpecialMode = m_Action.FindAction("SpecialMode", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_MaskShoot;
    private readonly InputAction m_Action_VaccineShoot;
    private readonly InputAction m_Action_IsolationInteraction;
    private readonly InputAction m_Action_Disinfect;
    private readonly InputAction m_Action_Scream;
    private readonly InputAction m_Action_SpecialMode;
    public struct ActionActions
    {
        private @Controls m_Wrapper;
        public ActionActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MaskShoot => m_Wrapper.m_Action_MaskShoot;
        public InputAction @VaccineShoot => m_Wrapper.m_Action_VaccineShoot;
        public InputAction @IsolationInteraction => m_Wrapper.m_Action_IsolationInteraction;
        public InputAction @Disinfect => m_Wrapper.m_Action_Disinfect;
        public InputAction @Scream => m_Wrapper.m_Action_Scream;
        public InputAction @SpecialMode => m_Wrapper.m_Action_SpecialMode;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @MaskShoot.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMaskShoot;
                @MaskShoot.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMaskShoot;
                @MaskShoot.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMaskShoot;
                @VaccineShoot.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnVaccineShoot;
                @VaccineShoot.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnVaccineShoot;
                @VaccineShoot.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnVaccineShoot;
                @IsolationInteraction.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnIsolationInteraction;
                @IsolationInteraction.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnIsolationInteraction;
                @IsolationInteraction.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnIsolationInteraction;
                @Disinfect.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnDisinfect;
                @Disinfect.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnDisinfect;
                @Disinfect.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnDisinfect;
                @Scream.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnScream;
                @Scream.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnScream;
                @Scream.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnScream;
                @SpecialMode.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnSpecialMode;
                @SpecialMode.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnSpecialMode;
                @SpecialMode.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnSpecialMode;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MaskShoot.started += instance.OnMaskShoot;
                @MaskShoot.performed += instance.OnMaskShoot;
                @MaskShoot.canceled += instance.OnMaskShoot;
                @VaccineShoot.started += instance.OnVaccineShoot;
                @VaccineShoot.performed += instance.OnVaccineShoot;
                @VaccineShoot.canceled += instance.OnVaccineShoot;
                @IsolationInteraction.started += instance.OnIsolationInteraction;
                @IsolationInteraction.performed += instance.OnIsolationInteraction;
                @IsolationInteraction.canceled += instance.OnIsolationInteraction;
                @Disinfect.started += instance.OnDisinfect;
                @Disinfect.performed += instance.OnDisinfect;
                @Disinfect.canceled += instance.OnDisinfect;
                @Scream.started += instance.OnScream;
                @Scream.performed += instance.OnScream;
                @Scream.canceled += instance.OnScream;
                @SpecialMode.started += instance.OnSpecialMode;
                @SpecialMode.performed += instance.OnSpecialMode;
                @SpecialMode.canceled += instance.OnSpecialMode;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IActionActions
    {
        void OnMaskShoot(InputAction.CallbackContext context);
        void OnVaccineShoot(InputAction.CallbackContext context);
        void OnIsolationInteraction(InputAction.CallbackContext context);
        void OnDisinfect(InputAction.CallbackContext context);
        void OnScream(InputAction.CallbackContext context);
        void OnSpecialMode(InputAction.CallbackContext context);
    }
}
