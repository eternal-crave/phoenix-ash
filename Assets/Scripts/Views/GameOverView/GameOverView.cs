using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ViewSystem.Views
{
    public class GameOverView : View
    {
         public event Action OnRestartButtonClick;
        public event Action OnHomeButtonClick;

        [SerializeField] private TMP_Text HighScoreText;
        [SerializeField] private TMP_Text LastScoreText;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button restartButton;

        public Button HomeButton => homeButton;
        public Button RestartButton => restartButton;

        public override void Init(Action onClose)
        {
            base.Init(onClose);
        }

        public void SetPlayerScores(int playerCurrentscore, int playerHighscore)
        {
            HighScoreText.text = $"Highscore: {playerCurrentscore}";
            LastScoreText.text = $"Highscore: {playerHighscore}";
        }

        private void OnEnable()
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            homeButton.onClick.AddListener(OnHomeButtonClicked);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveAllListeners();
            homeButton.onClick.RemoveAllListeners();
        }

        private void OnHomeButtonClicked()
        {
            OnHomeButtonClick?.Invoke();
            Close();
        }

        private void OnRestartButtonClicked()
        {
            OnRestartButtonClick?.Invoke();
            Close();
        }




    }
}