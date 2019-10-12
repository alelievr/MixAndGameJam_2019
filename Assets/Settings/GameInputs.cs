// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GameInputs : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""b62f8696-6b62-493a-b843-f7b0bfaa5442"",
            ""actions"": [
                {
                    ""name"": ""CameraRight"",
                    ""type"": ""Value"",
                    ""id"": ""102d62c6-e9a5-46b2-9627-6f79a56bf9eb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""6e1dff64-8ed8-4715-b2b0-2673671bd22f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8808e35d-3ee1-4516-9a12-a6bc124d96a5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""0e51e326-7bff-4c39-b74d-3053b3032ddf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d6f62711-74ea-44e0-b7d6-cf11250eb184"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""87265d90-1b45-4994-bebc-722e673be8ad"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c512719d-48cc-4e37-ad01-d57cf706bae1"",
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
        m_Game_CameraRight = m_Game.FindAction("CameraRight", throwIfNotFound: true);
        m_Game_Newaction = m_Game.FindAction("New action", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_CameraRight;
    private readonly InputAction m_Game_Newaction;
    public struct GameActions
    {
        private GameInputs m_Wrapper;
        public GameActions(GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraRight => m_Wrapper.m_Game_CameraRight;
        public InputAction @Newaction => m_Wrapper.m_Game_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                CameraRight.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCameraRight;
                CameraRight.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCameraRight;
                CameraRight.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCameraRight;
                Newaction.started -= m_Wrapper.m_GameActionsCallbackInterface.OnNewaction;
                Newaction.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnNewaction;
                Newaction.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                CameraRight.started += instance.OnCameraRight;
                CameraRight.performed += instance.OnCameraRight;
                CameraRight.canceled += instance.OnCameraRight;
                Newaction.started += instance.OnNewaction;
                Newaction.performed += instance.OnNewaction;
                Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnCameraRight(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
}
