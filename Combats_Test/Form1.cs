using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combats_Test
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1
            string username = textBox1.Text;
            Gameform gf;
            if (username != "")
                gf = new Gameform(username);
            else MessageBox.Show("Введите имя");
        }
    }
}
