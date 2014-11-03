using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    
    class BinaryTree
    {
        private List<int> trees;        
        public Node Root { get; private set; }

        public BinaryTree(int data)
        {
            this.Root = new Node(data);
            this.trees = new List<int>();
        }

        public void Insert(Node root, Node newNode)
        {
            var temp = root;

            // left side
            if (newNode.Data < temp.Data)
            {
                if (temp.Left == null)
                {
                    temp.Left = newNode;
                }
                else
                {
                    temp = temp.Left;
                    Insert(temp, newNode);
                }
            }
            else // right side
                if (newNode.Data > temp.Data)
                {
                    if (temp.Right == null)
                    {
                        temp.Right = newNode;
                    }
                    else
                    {
                        temp = temp.Right;
                        Insert(temp, newNode);
                    }
                }
        }  
        
        private void setTrees(Node root)
        {
            if (root == null)
                return;

            setTrees(root.Left);
            trees.Add(root.Data);
            setTrees(root.Right);
        }

        public List<int> BinaryTrees
        {
            get
            {
                trees.Clear();
                setTrees(Root);
                return trees;
            }
        }

    }
}
