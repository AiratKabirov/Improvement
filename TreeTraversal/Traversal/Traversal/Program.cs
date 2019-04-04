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

            int[] postorder = { 1, 4, 3, 2, 6, 8, 7, 5 };

            BinarySearchTree binarySearchTree = new BinarySearchTree();

            int currIndexPreorder = 0;

            int currIndexPostorder = postorder.Length - 1;

            int min = int.MinValue;
            int max = int.MaxValue;

            TreeNode rootPreorder = binarySearchTree.DeserializePreorderTreeOptimized(preorder, ref currIndexPreorder, min, max);

            TreeNode rootPostorder = binarySearchTree.DeserializePostorderTreeOptimized(postorder, ref currIndexPostorder, min, max);

            // TreeNode root = solution.deserializeArray(preorder, 0, preorder.length - 1);

            Console.WriteLine("Inorder array for constructed BST is:");
            binarySearchTree.PrintInorder(rootPreorder);

            Console.WriteLine("");

            Console.WriteLine("Preorder array for constructed BST is:");
            binarySearchTree.PrintPreorder(rootPreorder);

            Console.WriteLine("");

            Console.WriteLine("Postorder array for constructed BST is:");
            binarySearchTree.PrintPostorder(rootPreorder);
        }
    }
}
