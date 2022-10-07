using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Factory
{
    public abstract class Factory<T> : IFactoryMarker where T : IFactoryItemPlaceHolder
    {
        protected abstract string path { get; }
        protected T Instance => instance;
        public Type ProductType => Instance.GetType();
        public abstract T Create();
        protected T instance;
    }
}
