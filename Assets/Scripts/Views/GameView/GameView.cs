using Core.ViewSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Action<WeaponType> OnWeaponChange;

        [SerializeField] private TMP_Text lifesText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private List<WeaponButton> weaponButtons;


        private void OnEnable()
        {
            weaponButtons.ForEach(b => b.OnClick += WeaponChangeInput);
        }

        

        private void WeaponChangeInput(WeaponType obj)
        {
            OnWeaponChange?.Invoke(obj);
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
            weaponButtons.ForEach(b => b.OnClick -= WeaponChangeInput);
        }

        public void CloseView()
        {
            Close();
        }

        public void UnlockWeapon(WeaponType weaponType)
        {
            weaponButtons.FirstOrDefault((b) => b.WeaponType == weaponType).Activate();
        }
    }
}