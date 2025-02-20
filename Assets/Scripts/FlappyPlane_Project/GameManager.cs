using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane_Project
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager gameManager;
        private static UIManager uiManager;

        private int flappyScore = 0;

        public static GameManager Instance
        {
            get { return gameManager; }
        }

        public UIManager UIManager
        {
            get { return uiManager; }
        }

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
            UpdateScore();
            uiManager.UpdatePanel(flappyScore);
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
            flappyScore += score;
            uiManager.UpdateScore(flappyScore);
            Debug.Log("Score: " + flappyScore);
        }

        public void UpdateScore()
        {
            if (Metabus2D.GameManager.Instance.BestFlappyScore < flappyScore)
            {
                Debug.Log("최고 점수 갱신");
                Metabus2D.GameManager.Instance.BestFlappyScore = flappyScore;

                PlayerPrefs.SetInt(Metabus2D.GameManager.BestFlappyScoreKey, Metabus2D.GameManager.Instance.BestFlappyScore);
            }
        }
    }
}