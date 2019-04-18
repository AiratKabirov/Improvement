namespace ParallelTreeTraversal
{
    public class TreeNode
    {
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public int NodeValue { get; set; }

        public TreeNode(int value)
        {
            this.NodeValue = value;
        }
    }
}
