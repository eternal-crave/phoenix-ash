using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ViewSystem.Views
{
    public class StartView : View
    {
        [SerializeField] private TMP_Text highscoreText;
        [SerializeField] private Button tapToStartButton;

        public override void Init(Action onClose)
        {
            base.Init(onClose);
            tapToStartButton.onClick.AddListener(onTapToStartButtonPress);

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

        public void SetHighScoreText(int score)
        {
            highscoreText.text = $"HighScore: {score}";
        }


    }
}