using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Game_Complexity.Roles
{
    [DebuggerDisplay("{Name}")]
    public class Werewolf : IRole<WerewolvesNode>
    {
        public string Name => "Werewolf";
        public int Team => Teams.Werewolves;

        public IEnumerable<IGameAction<WerewolvesNode>> Day(IEnumerable<Player> players)
        {
            yield break;
        }

        public IEnumerable<IGameAction<WerewolvesNode>> Night(IEnumerable<Player> players)
        {
            yield return new KillAction("Werewolves", players.Where(x => x.Role.Team != Teams.Werewolves));
        }
    }
}
