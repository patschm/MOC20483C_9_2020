using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(txtA.Text, out int a);
            int.TryParse(txtB.Text, out int b);

            //int result = SpecialAdd(a, b);
            //UpdateResult(result);

            // APM-Style
            // You recognize it on Begin... and End...
            //var curThread = SynchronizationContext.Current;
            //Func<int, int, int> del = SpecialAdd;
            //del.BeginInvoke(a, b, ares => {
            //    int res = del.EndInvoke(ares);
            //    curThread.Post(UpdateResult, res);
            //    //UpdateResult(res);
            //}, null);

            // Through a Task
            //Task t1 = new Task(() => {
            //    int res = SpecialAdd(a, b);
            //    curThread.Post(UpdateResult, res);
            //});
            //t1.Start();

            int res = await SpecialAddAsync(a, b);
            UpdateResult(res);
        }

        private void UpdateResult(object result)
        {
            lblResult.Text = result.ToString();
        }

        private int SpecialAdd(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<int> SpecialAddAsync(int a, int b)
        {
            return Task.Run<int>(() => SpecialAdd(a, b));
        }
    }
}
