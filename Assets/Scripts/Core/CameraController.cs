using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRun.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private Vector3 _distance;

        void Start()
        {
            _distance = transform.position - _player.transform.position;
        }


        void LateUpdate()
        {
            transform.position = _player.transform.position + _distance;
        }
    }
}

