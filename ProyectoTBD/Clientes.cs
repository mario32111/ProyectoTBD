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
    public partial class Clientes : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr; // Change SqlDataAdapter to SqlDataReader
        DataTable dt;
        public Clientes()
        {
            InitializeComponent();
            conn = new SqlConnection(
                             "Data Source=localhost;" +
                             "Initial Catalog=Tienda;" +
                             "Integrated Security=true;" +
                             "Trust Server Certificate= True");
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Ventas.Clientes";
            try
            {
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr.GetSqlString(1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
