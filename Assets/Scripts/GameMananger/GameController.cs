using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRun.ObjectSettings;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace EndlessRun.GameManager
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onBackground;
        
        public TextMeshProUGUI ScoreText;
        public TextMeshProUGUI GameOverText;
        public TextMeshProUGUI RestartText;
        public TextMeshProUGUI QuitText;
        public TextMeshProUGUI Action;

        private bool StartGame = true;
        public bool GameOver = false;    


        private void Awake()
        {
            Time.timeScale = 0f;
        }

        void Start()
        {
            Action.text = "Jump to the Game!";
            GameOverText.text = "";
            RestartText.text = "";
            QuitText.text = "";
        }

        void Update()
        {
            if (StartGame && Input.GetKeyDown(KeyCode.Space))
            {
                _onBackground.Invoke();
                Action.text = "";
                Time.timeScale = 1f;
                Debug.Log("basla");
                StartGame = false;
            }

            if (GameOver)
            {                             
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    Application.Quit();
                    Debug.Log("Oyun Kapandi!");
                }
            }
        }

        // SpecialAbilities scriptinden referans alýyor.
        public void Finish()
        {
            GameOverText.text = "GAME OVER!";
            RestartText.text = "Press 'R' for Restart";
            QuitText.text = "Press 'Q' for Quit";
            GameOver = true;
        }
    }
}
