using System.Collections.Generic;

namespace Game_Complexity
{
    public interface IGameAction<T> where T : INode
    {
        IEnumerable<T> Execute(T node);
    }
}