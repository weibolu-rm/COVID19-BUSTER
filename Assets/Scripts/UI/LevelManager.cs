using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelManager : MonoBehaviour
    {
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

    }
}
