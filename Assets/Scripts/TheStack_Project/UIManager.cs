using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheStack_Project
{
    public enum UIState
    {
        Home,
        Game,
        Score,
    }

    public class UIManager : MonoBehaviour
    {
        private static UIManager instance;
        public static UIManager Instance { get { return instance; } }

        private UIState currentState = UIState.Home;

        private HomeUI homeUI;
        private GameUI gameUI;
        private ScoreUI scoreUI;

        private TheStack theStack;

        private void Awake()
        {
            instance = this;

            theStack = FindObjectOfType<TheStack>();

            homeUI = GetComponentInChildren<HomeUI>(true);
            homeUI?.Init(this);
            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI?.Init(this);
            scoreUI = GetComponentInChildren<ScoreUI>(true);
            scoreUI?.Init(this);

            ChangeState(UIState.Home);
        }

        public void ChangeState(UIState state)
        {
            currentState = state;
            homeUI?.SetActive(currentState);
            gameUI?.SetActive(currentState);
            scoreUI?.SetActive(currentState);
        }

        public void OnClickStart()
        {
            theStack.Restart();
            ChangeState(UIState.Game);
        }

        public void OnClickExit()
        {
            SceneManager.LoadScene("Metabus2D");
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#else
//        Application.Quit();
//#endif
        }

        public void UpdateScore()
        {
            gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
        }

        public void SetScoreUI()
        {
            scoreUI.SetUI(theStack.Score, theStack.Combo, Metabus2D.GameManager.Instance.BestStackScore, Metabus2D.GameManager.Instance.BestStackCombo);

            ChangeState(UIState.Score);
        }
    }
}