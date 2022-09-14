using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRun.Movement;
using EndlessRun.ObjectSettings;

namespace EndlessRun.ObstacleSpawn
{
    public class test : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 1;
        [SerializeField] private ObjectPool _objectPool = null;
        [SerializeField] private Transform _player;
        [SerializeField] private SpecialAbilities specialAbilities;
        [SerializeField] private PlayerMovementSettings _translateSettings;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);

            StartCoroutine(nameof(SpawnRoutine));

        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                int randomNumber = Random.Range(0, 7);
                GameObject obj = _objectPool.GetPooledObject(randomNumber);

                if (randomNumber < 4)
                {
                    obj.transform.position = new Vector3(-2.5f, 0.4f, _player.transform.position.z + 40f);

                    if (randomNumber == 2)
                    {
                        obj.transform.position = new Vector3(0, 0.4f, _player.transform.position.z + 40f);
                    }

                    
                }

                if (randomNumber > 4)
                {
                    obj.transform.position = new Vector3(2.5f, 0.4f, _player.transform.position.z + 40f);

                    if (randomNumber == 2)
                    {
                        obj.transform.position = new Vector3(0, 0.4f, _player.transform.position.z + 40f);
                    }

                }
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }

}
