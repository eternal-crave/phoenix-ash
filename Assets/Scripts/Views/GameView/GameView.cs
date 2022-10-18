using Core.ViewSystem.Core;
using System;
using System.Collections.Generic;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;
using Views.GameView;
using Weapons;
using Zenject;

namespace ViewSystem.Views
{
    public class GameView : View
    {
        Func<WeaponType> onWeaponChange;

        [SerializeField] private TMP_Text lifesText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private List<WeaponButton> weaponButtons;


        private void OnEnable()
        {
            weaponButtons.ForEach(b => b.OnClick += onWeaponChange);
        }

        public override void Init(Action onClose)
        {
            base.Init(onClose);
        }

        public void SetValues(int lifes, int score)
        {
            lifesText.text = lifes.ToString();
            scoreText.text = score.ToString();
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void SetHealth(int score)
        {
            lifesText.text = score.ToString();
        }

        private void OnDisable()
        {
            weaponButtons.ForEach(b => b.OnClick -= onWeaponChange);
        }

        public void Close()
        {
            Close();
        }
    }
}