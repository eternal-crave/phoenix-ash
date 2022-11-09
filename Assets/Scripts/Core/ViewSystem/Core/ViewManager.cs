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
        List<View> views;

        public ViewManager(List<View> presenters)
        {
            views = presenters;
        }

        public V OpenView<V>() where V : View
        {
            return (V)views.FirstOrDefault((p) => GetType() == typeof(V));
        }
    }
}
