using FeatureSystem.Systems;
using GameFeatures.PlayerFeature.Components;
using UnityEngine;

namespace GameFeatures.PlayerFeature.Systems
{
    public class PlayerMovementSystem : ISystem, ISystemUpdate
    {
        private PlayerInputSystem _inputSystem;
        private PlayerComponent _player;

        private readonly Bounds _movingBounds;
        private readonly float _movementSpeed;
        private readonly float _rotationSpeed;

        private const string _isMovingAnimatorBoolName = "IsMoving";

        public PlayerMovementSystem(Bounds movingBounds, float movementSpeed, float rotationSpeed)
        {
            _movingBounds = movingBounds;
            _movementSpeed = movementSpeed;
            _rotationSpeed = rotationSpeed;
        }

        public void Initialize()
        {
            _inputSystem = GameSystems.GetSystem<PlayerInputSystem>();
            _player = GameSystems.GetSystem<PlayerSpawnSystem>().Player;
        }

        public void Destroy()
        {
            _inputSystem = null;
            _player = null;
        }

        public void Update()
        {
            var isMoving = _inputSystem.Input != Vector2.zero;
            _player.Animator.SetBool(_isMovingAnimatorBoolName, isMoving);

            if (!isMoving)
                return;

            var direction = new Vector3(_inputSystem.Input.x, 0, _inputSystem.Input.y).normalized;

            _player.Transform.rotation = Quaternion.Lerp(_player.Transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed);

            var desiredDestination = direction + _player.Position;
            if (!_movingBounds.Contains(desiredDestination))
                return;

            _player.Transform.Translate(direction * _movementSpeed * Time.deltaTime, Space.World);
        }
    }
}
