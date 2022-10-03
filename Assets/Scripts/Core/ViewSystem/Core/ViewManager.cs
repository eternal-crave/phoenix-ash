using Core.ViewSystem.Test.TestPool;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class ViewManager : MonoBehaviour
    {
        private const string path = "ViewPrefabs";
        [SerializeField] private Transform instantiateContainer;
        private List<View> views = new List<View>();
        private void Awake()
        {
            instantiateContainer = FindObjectOfType<Canvas>().transform.GetChild(0);
        }

        /*public static P SetupView<P,V>() where P : Presenter, new() where V : View
        {
            V view = ((GameObject)Instantiate(Resources.Load(typeof(V).Name),instantiateContainer)).GetComponent<V>();
            P presenter = new P();
            return presenter;
        }*/

        public void InstantiateViews(DiContainer diContainer)
        {
            views = Resources.LoadAll<View>(path).ToList();
            foreach (View view in views)
            {
                diContainer.InstantiatePrefab(view);
            }
        }


    }
}
