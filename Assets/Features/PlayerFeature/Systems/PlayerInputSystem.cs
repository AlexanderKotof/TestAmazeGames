using FeatureSystem.Systems;
using UnityEngine;

namespace GameFeatures.PlayerFeature.Systems
{
    public class PlayerInputSystem : ISystem
    {
        public Vector2 Input { get; private set; }

        public void Initialize()
        {
            Input = Vector2.zero;
        }

        public void SetInput(Vector2 input)
        {
            Input = input;
        }

        public void Destroy()
        {
            Input = Vector2.zero;
        }
    }
}
