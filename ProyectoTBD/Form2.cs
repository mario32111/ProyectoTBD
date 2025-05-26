using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace ProyectoTBD
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            con = new SqlConnection(
                 "Server =localhost;" +
                 "Initial Catalog=Tienda;" +
                 $"User= {user}; Password = {pass};" +
                 "Trust server certificate = True");

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT IS_MEMBER('Rol1');", con);
                int esMiembro = (int)cmd.ExecuteScalar();

                if (esMiembro == 1)
                {
                    MessageBox.Show("El usuario pertenece a Rol1 (acceso completo).");
                }
                else
                {
                    MessageBox.Show("El usuario NO pertenece a Rol1 (solo lectura).");
                }
                permisos menu = new permisos(esMiembro == 1); // convierte int a bool
                menu.Show();

                MessageBox.Show("Inicio de sesion con rol");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesion...." + ex.Message);
                Application.Exit();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
