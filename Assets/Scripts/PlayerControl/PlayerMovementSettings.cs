using UnityEngine;

namespace EndlessRun.Movement
{
    [CreateAssetMenu(menuName = "EndlessRun/Player/Movement Controller")]

    public class PlayerMovementSettings : ScriptableObject
    {
        [Header("Character Speed")]
        public float CurrentSpeed;
        //acceleration = artýþ hýzý
        public float AccelerationSpeed;
        public float MaxSpeed;

        [Header("Lerp Speed")]
        [SerializeField] [Range(0, 10)] private float _lerp;
        public float Lerp { get { return _lerp; } }

        [Header("Jump")]
        [SerializeField] private Vector3 _jump;
        public Vector3 Jump { get { return _jump; } }


        [SerializeField] private int _jumpForce;
        public float Force { get { return _jumpForce; } }
    }
}

