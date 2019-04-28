using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game_Complexity.Roles
{
    [DebuggerDisplay("{Name}")]
    public class Innocent : IRole<WerewolvesNode>
    {
        public string Name => "Innocent";
        public int Team => Teams.Innocent;

        public IEnumerable<IGameAction<WerewolvesNode>> Day(IEnumerable<Player> players)
        {
            yield return new KillAction("Lynch", players, true);
        }

        public IEnumerable<IGameAction<WerewolvesNode>> Night(IEnumerable<Player> players)
        {
            yield break;
        }
    }
}
