using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A x = new B(); 
            x.Do();

            x.Do1();
        }

        public class A
        {
            public void Do()
            {
                Console.WriteLine("A");
            }

            public virtual void Do1() 
            { 
                Console.WriteLine("A"); 
            }
        }

        public class B : A 
        { 
            public new void Do() 
            { 
                Console.WriteLine("B"); 
            }

            public override void Do1() 
            { 
                Console.WriteLine("B");

                //base.Do1();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var btree = new BinaryTree(50);

            btree.Insert(btree.Root, new Node(10));
            btree.Insert(btree.Root, new Node(11));
            btree.Insert(btree.Root, new Node(100));
            btree.Insert(btree.Root, new Node(30));
            btree.Insert(btree.Root, new Node(60));
            btree.Insert(btree.Root, new Node(40));
            btree.Insert(btree.Root, new Node(10));

            var result = string.Empty;

            foreach(var item in btree.BinaryTrees)
            {
                result += item + " ";
            }

            label1.Text = result;
        }

    }
}
