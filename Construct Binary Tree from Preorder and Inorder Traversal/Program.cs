using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        static void Main(string[] args)
        {
            var preorder = new int[] {  3, 9, 20, 15, 7};
            var inorder = new int[] { 9, 3, 15, 20, 7 };
            var result = buildTree(preorder, inorder);
        }


        // reference - https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/discuss/34543/Simple-O(n)-without-map
        // open the link and check for the java solution 
        static TreeNode buildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0) return null;
            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode root = new TreeNode(preorder[0]), cur = root;
            for (int i = 1, j = 0; i < preorder.Length; i++)
            {
                // when below condition satisfied means we have left node
                if (cur.val != inorder[j])
                {
                    cur.left = new TreeNode(preorder[i]);
                    s.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    j++;
                    // here we dont have more left node, so will be going up and cheking with the root of the left node.
                    while (s.Count > 0 && s.Peek().val == inorder[j])
                    {
                        cur = s.Pop();
                        j++;
                    }
                    cur = cur.right = new TreeNode(preorder[i]);
                }
            }
            return root;
        }
    }
}
