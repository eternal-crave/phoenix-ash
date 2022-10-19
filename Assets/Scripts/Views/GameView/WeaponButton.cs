using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace Views.GameView
{
    [RequireComponent(typeof(Button))]
    public class WeaponButton : MonoBehaviour
    {
        public event Action<WeaponType> OnClick;

        [SerializeField] private Button button;
        [SerializeField] private WeaponType weaponType;

        private void OnValidate()
        {
            button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        private void OnButtonClick()
        {
            OnClick?.Invoke(weaponType);
        }
    }
}
