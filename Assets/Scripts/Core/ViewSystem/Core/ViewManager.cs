using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public class ViewManager
    {
        List<Presenter> viewPresenters = new List<Presenter>();

        public ViewManager(TestPresenter testpresenter)
        {
            viewPresenters.Add(testpresenter);
        }

        public Presenter OpenView<V>() where V : View
        {
            return viewPresenters.FirstOrDefault((p) => p.View.GetType() is V);
        }

        public P OpenView<V, P>() where V : View where P: Presenter
        {

            return (P)viewPresenters.FirstOrDefault((p) => p.View.GetType() == typeof(V));
        }
    }
}
