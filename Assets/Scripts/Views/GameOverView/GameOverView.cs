using Core.ScoreSystem;
using Core.ViewSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ViewSystem.Views.Gameplay;
using Zenject;

namespace ViewSystem.Views
{
    public class GameOverView : View
    {
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private TMP_Text lastScoreText;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button restartButton;
        private ScoreCounter scoreCounter;

        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            this.scoreCounter = scoreCounter;
        }
        public override void Init(Action onClose)
        {
            base.Init(onClose);
            SetPlayerScores();
        }

        public void SetPlayerScores()
        {
            scoreCounter.GetScoreInfo(out float playerCurrentscore, out float playerHighscore);
            highScoreText.text = $"Highscore: {playerHighscore}";
            lastScoreText.text = $"Score: {playerCurrentscore}";
        }

        public void AddListenerToHomeButton(UnityAction onClick)
        {
            homeButton.onClick.AddListener(onClick);
            Close();
        }

        public void AddListenerToRestartButton(UnityAction onClick)
        {
            restartButton.onClick.AddListener(onClick);
            Close();
        }

        public void RemoveButtonsLiateners()
        {
            homeButton.onClick.RemoveAllListeners();
            restartButton.onClick.RemoveAllListeners();
        }






    }
}