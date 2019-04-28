using System.Collections.Generic;
using System.Diagnostics;

namespace Game_Complexity
{
    public interface IRole<T> where T : INode
    {
        IEnumerable<IGameAction<T>> Day(IEnumerable<Player> players);
        IEnumerable<IGameAction<T>> Night(IEnumerable<Player> players);
        int Team { get; }
        string Name { get; }
    }
}