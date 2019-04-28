using Game_Complexity.Roles;
using System;
using System.Linq;

namespace Game_Complexity
{
    public class Program
    {
        private const string _cross = " ├─";
        private const string _corner = " └─";
        private const string _vertical = " │ ";
        private const string _space = "   ";

        public static void Main(string[] args)
        {
            var root = new WerewolvesNode("root", new Player[]
            {
                new Player("Kai", new Werewolf()),
                new Player("Hipster Melon Man", new Innocent()),
                new Player("Gen Meow Meow", new Innocent()),
            },
            new IRole<WerewolvesNode>[]
            {
                new Werewolf(),
                new Innocent()
            });

            Console.WriteLine("Setup:");
            Console.WriteLine("  Roles:");
            foreach (var role in root.Roles)
                Console.WriteLine($"    {role.Name} x{root.Players.Where(x => x.Role.Name == role.Name).Count()}");
            Console.WriteLine();
            Console.WriteLine("  Players:");
            foreach (var player in root.Players)
                Console.WriteLine($"    {player.Name} - {player.Role.Name}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Graph");
            PrintNode(root, "", true);
            Console.ReadLine();
        }

        private static void PrintNode(INode node, string indent, bool isLast, int depth = 0)
        {
            Console.Write(indent);

            if (isLast)
            {
                Console.Write(_corner);
                indent += _space;
            }
            else
            {
                Console.Write(_cross);
                indent += _vertical;
            }

            Console.WriteLine(node.Name);

            var children = node.Expand();
            var numberOfChildren = children.Length;
            for (var i = 0; i < numberOfChildren; i++)
            {
                var child = children[i];
                var isLastChild = (i == (numberOfChildren - 1));
                PrintNode(child, indent, isLastChild, depth+1);
            }
        }
    }
}
