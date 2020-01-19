using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Radio
{

    public partial class Checker : Form
    {

        public Checker()
        {
            InitializeComponent();
        }
    
        public void button1_Click(object sender, EventArgs e)
        {
            Program.Form2.timeChecker();
        }
    }
}
