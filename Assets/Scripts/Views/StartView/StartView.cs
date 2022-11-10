using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.SaveSystem.PlayerPrefsSaveSystem;
using Zenject;
using Core.ViewSystem;
using Core.ScoreSystem;

namespace ViewSystem.Views
{
    public class StartView : View
    {
        [SerializeField] private TMP_Text highscoreText;
        [SerializeField] private Button tapToStartButton;
        private ScoreCounter scoreCounter;

        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            this.scoreCounter = scoreCounter;
        }

        public override void Init(Action onClose)
        {
            base.Init(onClose);
            tapToStartButton.onClick.AddListener(onTapToStartButtonPress);
            SetHighScoreText();

        }

        private void onTapToStartButtonPress()
        {
            Close();
        }

        protected override void Close()
        {
            base.Close();
            tapToStartButton.onClick.RemoveAllListeners();
        }

        public void SetHighScoreText()
        {
            highscoreText.text = $"HighScore: {scoreCounter.Highscore}";
        }


    }
}