using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SaveSystem
{
    public interface ISaveSystem<T> where T : ISaveSystemData
    {
        void Save(T data);
        T Load();
    }
}
