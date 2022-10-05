using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ViewSystem.Views
{
    public class GameplayInput : MonoBehaviour, IPointerUpHandler, IDragHandler
    {
        public event Action<Vector3> OnPlayerInput;

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPlayerInput?.Invoke(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnPlayerInput?.Invoke(eventData.position);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}