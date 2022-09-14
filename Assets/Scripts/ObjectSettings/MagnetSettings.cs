using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRun.ObjectSettings
{
    public class MagnetSettings : MonoBehaviour
    {
        private Transform _player;
        private SpecialAbilities _specialAbilities;

        void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Transform>();
            _specialAbilities = GameObject.Find("Player").GetComponent<SpecialAbilities>();
        }

        void Update()
        {            
            CollectGold();            
        }

        private void CollectGold()
        {
            var distance = Vector3.Distance(_player.transform.position, transform.position);

            if (distance < 10 && _specialAbilities.MagnetInteraction)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * 20);                
            }        
        }       
    }
}

