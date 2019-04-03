using System;

namespace Traversal
{
    public class BinarySearchTree
    {
        public void PrintInorder(TreeNode root)
        {
            if (root == null) return;

            PrintInorder(root.LeftChild);
            Console.WriteLine( " " + root.NodeValue + "," );
            PrintInorder(root.RightChild);
        }

        public void PrintPreorder(TreeNode root)
        {
            if (root == null) return;

            Console.WriteLine(" " + root.NodeValue + ",");
            PrintPreorder(root.LeftChild);
            PrintPreorder(root.RightChild);
        }

        public TreeNode DeserializeTreeOptimized(int[] preorder, int[] currIndex, int min, int max)
        {
            if (currIndex[0] >= preorder.Length) return null;

            TreeNode root = null;

            if ((preorder[currIndex[0]] > min) && (preorder[currIndex[0]] < max))
            {
                root = new TreeNode(preorder[currIndex[0]]);
                currIndex[0] += 1;
                root.LeftChild = DeserializeTreeOptimized(preorder, currIndex, min, root.NodeValue);
                root.RightChild = DeserializeTreeOptimized(preorder, currIndex, root.NodeValue, max);
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
