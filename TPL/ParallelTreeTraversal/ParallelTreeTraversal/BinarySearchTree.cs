using System;
using System.Threading.Tasks;

namespace ParallelTreeTraversal
{
    public class BinarySearchTree
    {
        public void ProcessTreeInParallel(TreeNode root, Action<int> action)
        {
            if (root == null) return;

            Parallel.Invoke(
                () => ProcessTreeInParallel(root.LeftChild, action),
                () => ProcessTreeInParallel(root.RightChild, action),
                () => action(root.NodeValue)
                );
        }

        public TreeNode DeserializePostorderTreeOptimized(int[] postorder, ref int currIndex, int min, int max)
        {
            if (currIndex < 0) return null;

            TreeNode root = null;

            if ((postorder[currIndex] > min) && (postorder[currIndex] < max))
            {
                root = new TreeNode(postorder[currIndex]);
                currIndex -= 1;
                root.RightChild = DeserializePostorderTreeOptimized(postorder, ref currIndex, root.NodeValue, max);
                root.LeftChild = DeserializePostorderTreeOptimized(postorder, ref currIndex, min, root.NodeValue);
            }

            return root;
        }
    }
}
