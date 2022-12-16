using UnityEngine;

namespace GameFeatures.PlayerFeature.Components
{
    public class PlayerComponent : MonoBehaviour
    {
        public Animator Animator { get; private set; }
        public Transform Transform { get; private set; }

        [SerializeField]
        private GameObject[] _cubes;

        public Vector3 Position => Transform.position;

        private void Awake()
        {
            Transform = transform;
            Animator = GetComponent<Animator>();

            foreach (var cube in _cubes)
                cube.SetActive(false);
        }

        public void PickUpCube()
        {
            // since it was not described on what basis the cubes are placed front or back, I used random
            _cubes[Random.Range(0, _cubes.Length)].SetActive(true);
        }

        public void DropCube()
        {
            foreach(var cube in _cubes)
                cube.SetActive(false);
        }
    }
}
