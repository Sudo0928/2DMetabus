using TMPro;
using UnityEngine;

namespace FlappyPlane_Project
{
    public class UIManager : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI scorePanelText;
        public TextMeshProUGUI bestScorePanelText;
        public TextMeshProUGUI restartText;

        private void Start()
        {
            OffPanel();
        }

        public void SetRestart()
        {
            restartText.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void UpdatePanel(int score)
        {
            scorePanelText.text = score.ToString();
            bestScorePanelText.text = Metabus2D.GameManager.Instance.BestFlappyScore.ToString();
        }

        public void OnPanel()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }

        public void OffPanel()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }
    }
}