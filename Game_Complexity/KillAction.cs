using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Complexity
{
    public class KillAction : IGameAction<WerewolvesNode>
    {
        public KillAction(string killer, IEnumerable<Player> possibleTargets, bool allowNone = false)
        {
            this.Killer = killer;
            this.PossibleTargets = possibleTargets;
            this.AllowNone = allowNone;
        }

        public string Killer { get; }
        public IEnumerable<Player> PossibleTargets { get; }
        public bool AllowNone { get; }

        public IEnumerable<WerewolvesNode> Execute(WerewolvesNode node)
        {
            if (AllowNone)
            {
                yield return new WerewolvesNode(
                    $"No one is killed by {Killer}",
                    node.Players,
                    node.Roles
                    );
            }

            foreach (var target in PossibleTargets)
            {
                yield return new WerewolvesNode(
                    $"{target.Name} is killed by {Killer}",
                    node.Players.Where(x => x != target),
                    node.Roles
                    );
            }
        }
    }
}
