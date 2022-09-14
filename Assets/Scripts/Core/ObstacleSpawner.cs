using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRun.Movement;
using EndlessRun.ObjectSettings;

namespace EndlessRun.ObstacleSpawn
{
    public class ObstacleSpawner : MonoBehaviour
    {
        // objects
        [SerializeField] private GameObject _roadBlocksB;
        [SerializeField] private GameObject _roadBlocker2;
        [SerializeField] private GameObject _roadBlocksD;
        [SerializeField] private GameObject _roadConeD;
        [SerializeField] private GameObject _gold;
        [SerializeField] private GameObject _magnet;
        [SerializeField] private GameObject _car;
        [SerializeField] private GameObject _motor;

        // scripts
        [SerializeField] private PlayerMovementSettings _translateSettings;
        [SerializeField] private Transform _player;
        [SerializeField] private SpecialAbilities _specialAbilities;

        private float _timeOfDeletion = 5f;
        private float[] xCoordinate = { -2.5f, 2.5f };

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);

            // spawnObject methodunu 0.2 sn ile çağırıyoruz.
            InvokeRepeating("SpawnObject", 0, 0.2f);
        }

        public void SpawnObject()
        {
            var randomNumber = Random.Range(0, 100);

            if (randomNumber > 0 && randomNumber < 40)
            {
                Spawn(_gold, -0.4f);
            }

            if (randomNumber > 40 && randomNumber < 42 && !_specialAbilities.MagnetInteraction)
            {
                Spawn(_magnet, 0.45f);
            }

            if (randomNumber > 44 && randomNumber < 48)
            {
                Spawn(_motor, 0.45f);
            }

            if (randomNumber > 50 && randomNumber < 60)
            {
                Spawn(_roadBlocksB, 0.45f);
            }

            if (randomNumber > 60 && randomNumber < 70)
            {
                Spawn(_roadBlocker2, 0.45f);
            }

            if (randomNumber > 70 && randomNumber < 80)
            {
                Spawn(_roadBlocksD, 0.45f);
            }

            if (randomNumber > 80 && randomNumber < 90)
            {
                Spawn(_roadConeD, 0.45f);
            }

            if (randomNumber > 90 && randomNumber < 100 && _translateSettings.CurrentSpeed == 20)
            {
                Spawn(_car, 0.4f);
            }
        }

        // objelerin random kordinatla hangi konumda spawn olucağını belirliyoruz.
        public void Spawn(GameObject _object, float _yCoordinate)
        {
            GameObject newSpawn = Instantiate(_object);

            var randomCoordinate = Random.Range(0, xCoordinate.Length);
            
            newSpawn.transform.position = new Vector3(xCoordinate[randomCoordinate], _yCoordinate, _player.transform.position.z + 40f);

            if (_object == _motor)
            {
                newSpawn.transform.position = new Vector3(0, _yCoordinate, _player.transform.position.z + 40f);
            }            

            Destroy(newSpawn, _timeOfDeletion);
        }
    }
}

