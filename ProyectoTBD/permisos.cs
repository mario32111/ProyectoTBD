using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTBD
{
    public partial class permisos : Form
    {
        public permisos(bool accesoCompleto)
        {
            InitializeComponent();

            if (accesoCompleto)
            {
                button1.Enabled= true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void permisos_Load(object sender, EventArgs e)
        {

        }
    }
}
