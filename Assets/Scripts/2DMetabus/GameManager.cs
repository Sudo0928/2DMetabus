using TopDown_Project;
using UnityEngine;

namespace Metabus2D
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance != null) return instance;
                else
                {
                    GameObject gameObject = new GameObject("GameManager");
                    GameManager gameManager = gameObject.AddComponent<GameManager>();
                    instance = gameManager;
                    return gameManager;
                }
            }
        }

        public PlayerController player { get; private set; }

        public static bool isFirstLoading = true;

        [Header("Flappy")]
        private int bestFlappyScore = 0;
        public int BestFlappyScore { get => bestFlappyScore; set => bestFlappyScore = value; }

        [Header("TheStack")]
        private int bestStackScore = 0;
        public int BestStackScore { get => bestStackScore; set => bestStackScore = value; }

        private int bestStackCombo = 0;
        public int BestStackCombo { get => bestStackCombo; set => bestStackCombo = value; }

        [Header("TopDown")]
        private int bestWaveScore = 0;
        public int BestWaveScore { get => bestWaveScore; set => bestWaveScore = value; }

        public const string BestFlappyScoreKey = "BestFlappyScore";
        public const string BestStackScoreKey = "BestStackScore";
        public const string BestStackComboKey = "BestStackCombo";
        public const string BestWaveScoreKey = "BestWaveScore";

        private void Awake()
        {
            if (!instance) instance = this;
            else Destroy(gameObject);

            bestFlappyScore = PlayerPrefs.GetInt(BestFlappyScoreKey, 0);
            bestStackScore = PlayerPrefs.GetInt(BestStackScoreKey, 0);
            bestStackCombo = PlayerPrefs.GetInt(BestStackComboKey, 0);
            bestWaveScore = PlayerPrefs.GetInt(BestWaveScoreKey, 0);

            player = FindObjectOfType<PlayerController>();
            player.Init(this);

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (!isFirstLoading)
            {
                
            }
            else
            {
                isFirstLoading = false;
            }
        }
    }
}
