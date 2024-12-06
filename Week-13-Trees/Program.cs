namespace Week_13_Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Input data
            List<int> data = new List<int> { 50, 30, 70, 20, 40, 60, 80 };

            // Step 2: Sort the data (using built-in sorting for simplicity)
            data.Sort();
            Console.WriteLine("Sorted Data: " + string.Join(", ", data));

            // Step 3: Create a Binary Search Tree
            TreeNode root = null;
            foreach (int value in data)
            {
                root = Insert(root, value);
            }

            // Step 4: Display the tree using Inorder Traversal
            Console.Write("Tree (Inorder Traversal): ");
            InOrderTraversal(root);
        }

        // Define the Node class for the Binary Search Tree
        public class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        // Insert a value into the Binary Search Tree
        public static TreeNode Insert(TreeNode root, int value)
        {
            if (root == null)
                return new TreeNode(value);

            if (value < root.Value)
                root.Left = Insert(root.Left, value);
            else if (value > root.Value)
                root.Right = Insert(root.Right, value);

            return root;
        }

        // Inorder traversal to display the tree (sorted order)
        public static void InOrderTraversal(TreeNode root)
        {
            if (root == null)
                return;

            InOrderTraversal(root.Left);
            Console.Write(root.Value + " ");
            InOrderTraversal(root.Right);
        }
    }
}
