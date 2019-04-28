
namespace Game_Complexity
{
    public interface INode
    {
        string Name { get; }
        INode[] Expand();
    }
}
