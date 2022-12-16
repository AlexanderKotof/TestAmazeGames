using UnityEngine;

namespace GameFeatures.CubesFeature.Components
{
    public class CubeComponent : MonoBehaviour
    {
        private Transform _tr;
        public Vector3 Position => _tr.position;
        private void Awake()
        {
            _tr = transform;
        }
    }
}
