using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int K = 6;
            int[] A = {1, 8, -3, 0, 1, 3, -2, 4, 5};

            int p = solution(6, A);

            int c = p;
        }

        public int solution(int K, int[] A)
        {
            int len = A.Length;
            int cnt = 0;

            if (A.Length == 0)
            {
                return 0;
            }

            for (var i = 0; i < len; i++) {
                for (var j = i; j < len; j++) {
                    if (A[i] + A[j] == K) {
                        if (i == j)
                        {
                            cnt++;
                        }
                        else
                        {
                            cnt += 2;
                        }
                    }
                }
            }

            return cnt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var List = new List<int>();

            listBox1.Items.Add("----------------");
            for(var i = 2; i<=100000; i++)
            {
                if (MathOne.IsPrime(i) == 1)
                {
                    List.Add(i);
                }
            }

            //Solution 1
            //for(var i = 0; i < List.Count() - 1; i++)
            //{
            //    if (List[i+1] - List[i] == 2)
            //    {
            //        listBox1.Items.Add("(" + List[i] + "," + List[i+1] +")");
            //    }
            //}

            //Solution 2
            var la = (List.Select((obj, index) => new { a = obj, b = (index > 0 ? List[index - 1] : 0) })).Where(p => p.a - p.b == 2 && p.a != 2);

            listBox1.Items.Add("==========================");
            foreach (var item in la)
            {
                listBox1.Items.Add("(" + item.b + "," + item.a + ")");
            }
        }

    }
}
