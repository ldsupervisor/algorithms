var tree = TreeExample.Create();
Console.WriteLine("Tree in traversal order:");
tree.InOrderTraversal();
public class TreeNode
{
    public int Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
public class BinaryTree
{
    public TreeNode? Root;

    public BinaryTree(TreeNode? root = null)
    {
        Root = root;
    }

    public void InOrderTraversal()
    {
        InOrderTraversal(Root);
    }

    private void InOrderTraversal(TreeNode? node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }
    }

}

public static class TreeExample
{
    public static BinaryTree Create()
    {
        var tree = new BinaryTree();

        tree.Root = new TreeNode(1);
        tree.Root.Left = new TreeNode(2);
        tree.Root.Right = new TreeNode(3);
        tree.Root.Left.Left = new TreeNode(4);
        tree.Root.Left.Right = new TreeNode(5);

        return tree;
    }
}



