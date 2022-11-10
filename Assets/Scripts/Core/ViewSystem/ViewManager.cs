using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ViewSystem.Views;

namespace Core.ViewSystem
{
    public class ViewManager
    {
        List<View> views;

        public ViewManager(List<View> views)
        {
            this.views = views;
        }

        public V OpenView<V>() where V : View
        {
            return (V)views.FirstOrDefault((p) => p.GetType() == typeof(V));
        }
    }
}
