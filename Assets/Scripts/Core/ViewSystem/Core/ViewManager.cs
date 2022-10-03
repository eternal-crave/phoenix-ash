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

        /*public static P SetupView<P,V>() where P : Presenter, new() where V : View
        {
            V view = ((GameObject)Instantiate(Resources.Load(typeof(V).Name),instantiateContainer)).GetComponent<V>();
            P presenter = new P();
            return presenter;
        }*/

        public void InstantiateViews(DiContainer diContainer)
        {
            views = Resources.LoadAll<View>(path).ToList();
            /*foreach (View view in views)
              {
                  View obj = diContainer.InstantiatePrefabForComponent<View>(view, instantiateContainer);
                  diContainer.Bind<View>().FromInstance(obj).AsSingle();
              }*/
            /* diContainer.Bind<View>().To<TestView>().FromComponentInNewPrefab(views[0]).WhenInjectedInto<TestPresenter>();
             diContainer.Bind<Presenter>().To<TestPresenter>().WhenInjectedInto<TestView>();*/

            diContainer.Bind<View>().To<TestView>().FromComponentInNewPrefab(views[0]).AsSingle().WhenInjectedInto<TestPresenter>().NonLazy();
            diContainer.Bind<Presenter>().To<TestPresenter>().AsSingle().WhenInjectedInto<TestView>();


            View view = diContainer.InstantiatePrefabForComponent<View>(views[0], instantiateContainer);
            /*diContainer.Bind<View>().FromInstance(view).NonLazy();*/


        }


    }
}
