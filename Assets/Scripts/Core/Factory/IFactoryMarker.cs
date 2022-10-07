using System;

namespace Core.Factory
{
    public interface IFactoryMarker
    {
        Type ProductType { get; }
    }
}