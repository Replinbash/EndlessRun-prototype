using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRun.ObstacleSpawn;
using EndlessRun.Movement;
using EndlessRun.GameManager;
using UnityEngine.Events;

namespace EndlessRun.ObjectSettings
{
    public class SpecialAbilities : MonoBehaviour
    {
        [SerializeField] private RoadSpawn _roadSpawner;
        [SerializeField] private GameController _gameController;
        [SerializeField] private Animator _animation;
        [SerializeField] private GameObject MagnetEffect;
        [SerializeField] private UnityEvent onCoin;
        [SerializeField] private UnityEvent onPower;
        [SerializeField] private UnityEvent _onFinish;
        [SerializeField] private UnityEvent _pauseSound;

        // counter: sayaç
        private int _counter;
        public bool MagnetInteraction = false;     
       

        private void OnTriggerEnter(Collider otherObj)
        {
            if (otherObj.gameObject.tag == "RoadTrigger")
            {
                _roadSpawner.MoveRoad();
            }

            if (otherObj.gameObject.tag == "obstacle")
            {
                Sounds();
                GetComponent<PlayerMovementController>().enabled = false;
                _animation.SetTrigger("fall");
                Invoke("GameOver", 2f);
            }

            if (otherObj.gameObject.tag == "gold")
            {
                onCoin.Invoke();
                _counter += 5;
                _gameController.ScoreText.text ="" + _counter;
                Destroy(otherObj.gameObject);
            }

            // magnet alýnýrsa sahnedeki tüm magnet objeleri silinir.
            if (otherObj.gameObject.tag == "magnet")
            {
                onPower.Invoke();
                MagnetInteraction = true;
                MagnetEffect.SetActive(true);

                GameObject[] magnet = GameObject.FindGameObjectsWithTag("magnet");

                foreach (var obj in magnet)
                {
                    Destroy(obj);
                }

                Destroy(otherObj.gameObject);
                Invoke("CancelCollect", 15f);
            }                       
        }

        private void Sounds()
        {
            _pauseSound.Invoke();
            _onFinish.Invoke();
        }

        void GameOver()
        {
            Time.timeScale = 0f;
            _gameController.Finish();            
        }

        void CancelCollect()
        {
            MagnetInteraction = false;
            MagnetEffect.SetActive(false);
        }
    }
}

