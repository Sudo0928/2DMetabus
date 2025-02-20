using System;
using UnityEngine;

namespace TopDown_Project
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public PlayerController player { get; private set; }
        private ResourceController _playerResourceController;

        [SerializeField] private int currentWaveIndex = 0;

        private EnemyManager enemyManager;

        private UIManager uiManager;
        public static bool isFirstLoading = true;

        private int waveScore = 0;
        public int WaveScore { get => waveScore; }

        private void Awake()
        {
            instance = this;
            player = FindObjectOfType<PlayerController>();
            player.Init(this);

            uiManager = FindObjectOfType<UIManager>();

            _playerResourceController = player.GetComponent<ResourceController>();
            _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
            _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);

            enemyManager = GetComponentInChildren<EnemyManager>();
            enemyManager.Init(this);
        }

        private void Start()
        {
            if (!isFirstLoading)
            {
                StartGame();
            }
            else
            {
                isFirstLoading = false;
            }
        }

        public void StartGame()
        {
            uiManager.SetPlayGame();
            StartNextWave();
        }

        private void StartNextWave()
        {
            currentWaveIndex += 1;
            uiManager.ChangeWave(currentWaveIndex);
            enemyManager.StartWave(1 + currentWaveIndex / 5);

            waveScore = currentWaveIndex;
        }

        public void EndOfWave()
        {
            StartNextWave();
        }

        public void GameOver()
        {
            enemyManager.StopWave();
            UpdateScore();
        }

        public void UpdateScore()
        {
            if (Metabus2D.GameManager.Instance.BestWaveScore < waveScore)
            {
                Debug.Log("최고 점수 갱신");
                Metabus2D.GameManager.Instance.BestWaveScore = waveScore;

                PlayerPrefs.SetInt(Metabus2D.GameManager.BestWaveScoreKey, Metabus2D.GameManager.Instance.BestWaveScore);
            }
        }
    }
}
