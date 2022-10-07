using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Factory
{
    public class FactoryManager
    {
        List<IFactoryMarker> factories = new List<IFactoryMarker>();
        public FactoryManager(List<IFactoryMarker> factories)
        {
            this.factories = factories;
        }

       public Factory<PRODUCT> GetFactory<PRODUCT>() where PRODUCT : IFactoryItemPlaceHolder
        {
            return (Factory<PRODUCT>)factories.FirstOrDefault((f) => f.ProductType == typeof(PRODUCT));
        }
    }
}
