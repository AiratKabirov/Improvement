using System;

namespace Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
        5
  2            7
1   3        6    8
      4
*/

            int[] preorder = { 5, 2, 1, 3, 4, 7, 6, 8 };

            BinarySearchTree binarySearchTree = new BinarySearchTree();

            int[] currIndex = new int[1];
            currIndex[0] = 0;

            int min = int.MinValue;
            int max = int.MaxValue;

            TreeNode root = binarySearchTree.DeserializeTreeOptimized(preorder, currIndex, min, max);

            // TreeNode root = solution.deserializeArray(preorder, 0, preorder.length - 1);

            Console.WriteLine("Inorder array for constructed BST is:");
            binarySearchTree.PrintInorder(root);

            Console.WriteLine("");

            Console.WriteLine("Preorder array for constructed BST is:");
            binarySearchTree.PrintPreorder(root);
        }
    }
}
