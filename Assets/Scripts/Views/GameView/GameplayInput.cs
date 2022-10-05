using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ViewSystem.Views
{
    public class GameplayInput : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public event Action<Vector3> OnPlayerInput;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPlayerInput?.Invoke(Camera.main.ScreenToWorldPoint(eventData.position));
        }
            
        public void OnDrag(PointerEventData eventData)
        {
            OnPlayerInput?.Invoke(Camera.main.ScreenToWorldPoint(eventData.position));
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