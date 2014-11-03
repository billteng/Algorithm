using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Node
    {
        public int Data { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }
}
