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

    }
}
