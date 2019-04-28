using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Game_Complexity
{
    [DebuggerDisplay("{Name}")]
    public class WerewolvesNode : INode
    {
        public string Name { get; }
        public IEnumerable<Player> Players { get; }
        public IRole<WerewolvesNode>[] Roles { get; }
        public bool LastWasNight = false;

        public WerewolvesNode(string name, IEnumerable<Player> players, IRole<WerewolvesNode>[] roles)
        {
            this.Name = name;
            this.Players = players;
            this.Roles = roles;
        }

        public INode[] Expand()
        {
            if (Players
                .Select(x => x.Role.Team)
                .Distinct()
                .Count() < 2)
                return new INode[]
                    {
                        Players.Count() == 0 ? new TextNode("Everyone is dead") : new TextNode($"The following Players won: {string.Join(", ", Players.Select(x => x.Name))}")
                    };

            var actions = new List<IGameAction<WerewolvesNode>>();
            foreach (var role in Roles)
                if (LastWasNight)
                    actions.AddRange(role.Day(Players));
                else
                    actions.AddRange(role.Night(Players));

            var nodes = new List<WerewolvesNode>();
            foreach(var action in actions)
            {
                nodes.AddRange(action.Execute(this));
            }
            return nodes.Select(x => { x.LastWasNight = !LastWasNight; return x; }).ToArray();
        }
    }
}