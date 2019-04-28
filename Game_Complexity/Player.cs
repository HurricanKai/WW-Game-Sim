using System.Diagnostics;

namespace Game_Complexity
{
    [DebuggerDisplay("{Name}")]
    public sealed class Player
    {
        public string Name { get; }
        public IRole<WerewolvesNode> Role { get; }

        public Player(string name, IRole<WerewolvesNode> role)
        {
            this.Name = name;
            this.Role = role;
        }
    }
}