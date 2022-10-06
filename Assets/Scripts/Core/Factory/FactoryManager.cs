using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Factory
{
    public class FactoryManager
    {
        List<Factory<IFactoryItemPlaceHolder>> factories = new List<Factory<IFactoryItemPlaceHolder>>();
        public FactoryManager(List<Factory<IFactoryItemPlaceHolder>> factories)
        {
            this.factories = factories;
        }

       public Factory<IFactoryItemPlaceHolder> GetFactory<F>() where F : IFactoryItemPlaceHolder
        {
            return factories.FirstOrDefault((f) => f.ProductType == typeof(F));
        }
    }
}
