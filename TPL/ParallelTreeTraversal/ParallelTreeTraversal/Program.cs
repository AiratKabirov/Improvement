using System;

namespace ParallelTreeTraversal
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

            int[] postorder = { 1, 4, 3, 2, 6, 8, 7, 5 };

            BinarySearchTree binarySearchTree = new BinarySearchTree();

            int currIndexPostorder = postorder.Length - 1;

            int min = int.MinValue;
            int max = int.MaxValue;

            TreeNode rootPostorder = binarySearchTree.DeserializePostorderTreeOptimized(postorder, ref currIndexPostorder, min, max);

            Console.WriteLine("Postorder array for constructed BST is:");
            binarySearchTree.ProcessTreeInParallel(rootPostorder, x => Console.WriteLine("My value is: " + x));
        }
    }
}
