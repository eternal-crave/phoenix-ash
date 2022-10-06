using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Factory
{
    public abstract class Factory<T> where T : IFactoryItemPlaceHolder
    {
        protected abstract string path { get; }
        protected abstract T Instance { get; }
        public abstract Type ProductType { get; }
        public abstract T Create();
    }
}
