using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRun.ObjectSettings
{
    public class VehicleSettings : MonoBehaviour
    {
        public float Speed = 25f;
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }

        private void Start()
        {
            //RandomColor();
        }

        private void RandomColor()
        {
            this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f);
        }
    }
}

