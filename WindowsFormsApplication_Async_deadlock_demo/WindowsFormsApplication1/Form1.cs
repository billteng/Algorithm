using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
            var result = GetPageStatus().Result;
            textBox1.Text = result;
        }

        /// <summary>
        /// By executing Task.ConfigureAwait(false) your effectively saying 
        /// that it ok for the task to continue its operation on another thread 
        /// than the one if was started on.
        /// 
        /// so, no deadlock here
        /// 
        /// DEADLOCK. The UI thread is blocked waiting for GetPageStatus 
        /// to complete, but this method cannot complete as it is trying 
        /// to execute the response.StatusCode.ToString()-method on the UI-thread.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPageStatus()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://www.google.com")
                .ConfigureAwait(false);
                return response.StatusCode.ToString();
            }
        }
    }
}
