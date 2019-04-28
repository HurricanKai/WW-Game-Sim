namespace Game_Complexity
{
    public class TextNode : INode
    {
        public TextNode(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public INode[] Expand()
        {
            return new INode[0];
        }
    }
}