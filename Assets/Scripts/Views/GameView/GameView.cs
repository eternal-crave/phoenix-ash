using Core.ViewSystem.Core;
using GameFlow.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;
using Views.GameView;
using ViewSystem.Views.Gameplay;
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
        private WeaponManager weaponManager;
        private Player player;
        private GameplayManager gameplayManager;

        [Inject]
        private void Construct(WeaponManager weaponManager, Player player, GameplayManager gameplayManager)
        {
            this.weaponManager = weaponManager;
            this.player = player;
            this.gameplayManager = gameplayManager;
        }


        private void OnEnable()
        {
            weaponButtons.ForEach(b => b.OnClick += WeaponChangeInput);
        }

        

        private void WeaponChangeInput(WeaponType type)
        {
            weaponManager.ChangeWeapon(type);
        }

        public override void Init(Action onClose)
        {
            base.Init(onClose);
            setValues((int)player.Health, 0);
            ResetWeapons(weaponManager.DefaultWeaponType);
            player.OnGetDamage += UpdateHealtText;
            player.OnDead += OnPlayerDead;
            gameplayManager.OnScoreChange += SetScore;
            weaponManager.OnNewWeaponUnlock += UnlockWeapon;

        }

        private void setValues(int lifes, int score)
        {
            lifesText.text = lifes.ToString();
            scoreText.text = score.ToString();
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void UpdateHealtText(float damage)
        {
            lifesText.text = player.Health.ToString();  
        }

        private void OnDisable()
        {
            weaponButtons.ForEach(b => b.OnClick -= WeaponChangeInput);
        }

        public void OnPlayerDead()
        {
            player.OnGetDamage -= UpdateHealtText;
            player.OnDead -= OnPlayerDead;
            gameplayManager.OnScoreChange -= SetScore;
            weaponManager.OnNewWeaponUnlock += UnlockWeapon;


            Close();
        }

        private void UnlockWeapon(WeaponType weaponType)
        {
            weaponButtons.FirstOrDefault((b) => b.WeaponType == weaponType).Activate();
        }

        public void ResetWeapons(WeaponType type)
        {
            foreach (WeaponButton b in weaponButtons)
            {
                if(b.WeaponType == type)
                {
                    continue;
                }
                b.Deactivate();
            }
        }
    }
}