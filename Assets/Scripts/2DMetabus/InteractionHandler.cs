using FlappyPlane_Project;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Metabus2D
{
    public enum GameScore
    {
        Flappy,
        TheStack,
        TopDown
    }

    public class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private GameScore score;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI bestScoreText;

        private void Awake()
        {
            canvasGroup.alpha = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                UpdateScore();
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                UpdateScore();
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
            }
        }

        private void UpdateScore()
        {
            switch (score)
            {
                case GameScore.Flappy:
                    bestScoreText.text = "BestScore : " + PlayerPrefs.GetInt(GameManager.BestFlappyScoreKey, 0);
                    break;
                case GameScore.TheStack:
                    bestScoreText.text = "BestScore : " + PlayerPrefs.GetInt(GameManager.BestStackScoreKey, 0);
                    break;
                case GameScore.TopDown:
                    bestScoreText.text = "BestScore : " + PlayerPrefs.GetInt(GameManager.BestWaveScoreKey, 0);
                    break;
            }
        }
    }
}
