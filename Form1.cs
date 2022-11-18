using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KodyKreskowe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateCode test = new GenerateCode();
            String code = test.GetCheckSum(textBox1.Text);
            textBox2.Text = code;
            Image img = test.Generate(code);
            test.SaveFile(img);
            pictureBox1.Image=img;
        }


    }
}
