using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverUI;
        public GameEvent togglePauseEvent;
        void Start()
        {
            // If we're coming form the Pause Menu
            Time.timeScale = 1f;
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void OnGameOverEvent()
        {
            gameOverUI.SetActive(true);
            
            togglePauseEvent.Raise();
            Time.timeScale = 0f;
        }

    }
}
