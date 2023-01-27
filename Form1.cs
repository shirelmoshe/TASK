using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RestSharp;
using System.Timers;
using System.Windows.Forms;


namespace Task_HW_25012023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ex01
        private void ex01_Click(object sender, EventArgs e)
        {
            Task.Run(Ex1.EX1.WriteToFile);
        }


        //ex02
        private async void ex02_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                label1.Text = await Ex02.EX2.ShowNumbers(i);
            }
        }


        //ex 05
        private async void ex05_Click(object sender, EventArgs e)
        {
            var t = await Ex5.EX5.GetDataAsync();
            int sizeInBytes = Encoding.UTF8.GetByteCount(t.ToString());
            label2.Text= sizeInBytes.ToString();
        }




        //ex06
        public bool stopLoop { get; set; } = true;
        private async void ex06_Click(object sender, EventArgs e)
        {
            var ct = new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token;
            while (stopLoop)
            {
                richTextBox1.Text = await Ex6.EX6.loop();
                if (ct.IsCancellationRequested)
                {
                    stopLoop = false;
                    Application.Exit();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}