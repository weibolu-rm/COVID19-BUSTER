using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {

        [SerializeField] private GameObject pauseUI;
        private static bool _isPaused = false;

        public GameEvent togglePauseEvent;


        private void Resume()
        {
            _isPaused = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;

        }
        private void Pause()
        {
            _isPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        public void OnPauseInput()
        {
            togglePauseEvent.Raise();
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    
    }
}
