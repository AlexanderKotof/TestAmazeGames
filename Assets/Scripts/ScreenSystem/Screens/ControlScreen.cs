using FeatureSystem.Systems;
using GameFeatures.PlayerFeature.Systems;
using ScreenSystem.Screens;
using UI.Components;
using UnityEngine;

namespace UI.Screens
{
    public class ControlScreen : BaseScreen
    {
        public JoystickComponent joystick;

        private PlayerInputSystem _inputSystem;

        protected override void OnShow()
        {
            base.OnShow();

            _inputSystem = GameSystems.GetSystem<PlayerInputSystem>();
            joystick.JoystickInput += OnJoystickInput;
        }

        private void OnJoystickInput(Vector2 input)
        {
            _inputSystem.SetInput(input);
        }

        protected override void OnHide()
        {
            base.OnHide();

            joystick.JoystickInput -= OnJoystickInput;
            _inputSystem = null;
        }
    }
}