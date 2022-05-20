//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_Game/04Data/Input.inputactions
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

namespace ghostly
{
    public partial class @Input : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Input()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""0405e7cf-395a-42c6-b775-d46da07052b6"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""e502121a-ade0-46b8-b7aa-3fd1dc8ee0a4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""5477d82e-e444-4463-b657-86bf1092e00a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae5f94c6-bf5b-4760-bc09-e7b97d2b6dab"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""cc6f7422-d239-4da0-8257-f0371e359395"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b2d9f54f-abad-4176-9277-18b1abb76ee5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dfe1f836-c3b7-40d3-92d7-f6cf0fabf133"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ecfecfcd-82df-4c6a-bbdd-1419361164fc"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""2cd6d614-f128-4df9-a919-539358f6d5de"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2a22602b-87ef-42e3-a8ca-b425b5edb977"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a9b1bdee-6c92-4060-b727-4cb3a6209a89"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""d36c7349-b07b-4c67-9348-ca2147dde216"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""1ed415ac-4272-4fcb-9ac1-38091be3fed9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f42bb5d-87d5-4343-9131-754ff97aa560"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_Horizontal = m_Game.FindAction("Horizontal", throwIfNotFound: true);
            m_Game_Vertical = m_Game.FindAction("Vertical", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
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

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_Horizontal;
        private readonly InputAction m_Game_Vertical;
        public struct GameActions
        {
            private @Input m_Wrapper;
            public GameActions(@Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Horizontal => m_Wrapper.m_Game_Horizontal;
            public InputAction @Vertical => m_Wrapper.m_Game_Vertical;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @Horizontal.started -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal;
                    @Horizontal.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal;
                    @Horizontal.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal;
                    @Vertical.started -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical;
                    @Vertical.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical;
                    @Vertical.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Horizontal.started += instance.OnHorizontal;
                    @Horizontal.performed += instance.OnHorizontal;
                    @Horizontal.canceled += instance.OnHorizontal;
                    @Vertical.started += instance.OnVertical;
                    @Vertical.performed += instance.OnVertical;
                    @Vertical.canceled += instance.OnVertical;
                }
            }
        }
        public GameActions @Game => new GameActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Newaction;
        public struct MenuActions
        {
            private @Input m_Wrapper;
            public MenuActions(@Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        public interface IGameActions
        {
            void OnHorizontal(InputAction.CallbackContext context);
            void OnVertical(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}