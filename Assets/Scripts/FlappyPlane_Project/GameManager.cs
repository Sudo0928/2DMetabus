using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane_Project
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager gameManager;
        private static UIManager uiManager;

        public static GameManager Instance
        {
            get { return gameManager; }
        }

        public UIManager UIManager
        {
            get { return uiManager; }
        }

        private int currentScore = 0;

        private void Awake()
        {
            gameManager = this;
            uiManager = FindObjectOfType<UIManager>();

            Time.timeScale = 0;
        }

        private void Start()
        {
            uiManager.UpdateScore(0);
        }

        public void GameStart()
        {
            Time.timeScale = 1;
            uiManager.restartText.gameObject.SetActive(false);
        }

        public void GameOver()
        {
            Debug.Log("Game Over");

            uiManager.UpdatePanel(currentScore);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoTitle(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            uiManager.UpdateScore(currentScore);
            Debug.Log("Score: " + currentScore);
        }
    }
}