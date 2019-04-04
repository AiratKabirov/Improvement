using System;

namespace Traversal
{
    public class BinarySearchTree
    {
        public void PrintInorder(TreeNode root)
        {
            if (root == null) return;

            PrintInorder(root.LeftChild);
            Console.WriteLine(" " + root.NodeValue + ",");
            PrintInorder(root.RightChild);
        }

        public void PrintPreorder(TreeNode root)
        {
            if (root == null) return;

            Console.WriteLine(" " + root.NodeValue + ",");
            PrintPreorder(root.LeftChild);
            PrintPreorder(root.RightChild);
        }

        public void PrintPostorder(TreeNode root)
        {
            if (root == null) return;

            PrintPostorder(root.LeftChild);
            PrintPostorder(root.RightChild);
            Console.WriteLine(" " + root.NodeValue + ",");
        }

        public TreeNode DeserializePreorderTreeOptimized(int[] preorder, ref int currIndex, int min, int max)
        {
            if (currIndex >= preorder.Length) return null;

            TreeNode root = null;

            if ((preorder[currIndex] > min) && (preorder[currIndex] < max))
            {
                root = new TreeNode(preorder[currIndex]);
                currIndex += 1;
                root.LeftChild = DeserializePreorderTreeOptimized(preorder, ref currIndex, min, root.NodeValue);
                root.RightChild = DeserializePreorderTreeOptimized(preorder, ref currIndex, root.NodeValue, max);
            }

            return root;
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

        public int FindDivision(int[] preorder, int value, int low, int high)
        {
            int i;
            for (i = low; i <= high; i++)
            {
                if (value < preorder[i])
                    break;
            }
            return i;
        }

        public TreeNode DeserializeArray(int[] preorder, int low, int high)
        {
            if (low > high) return null;

            TreeNode root = new TreeNode(preorder[low]);

            int divIndex = FindDivision(preorder, root.NodeValue, low + 1, high);

            root.LeftChild = DeserializeArray(preorder, low + 1, divIndex - 1);
            root.RightChild = DeserializeArray(preorder, divIndex, high);

            return root;
        }
    }
}
