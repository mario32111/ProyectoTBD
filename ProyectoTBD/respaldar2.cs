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
using System.Data;
namespace ProyectoTBD
{
    public partial class respaldar2 : Form
    {
        SqlConnection con;
        SqlCommand com;
        public respaldar2()
        {
            InitializeComponent();
            InitializeComponent();
            con = new SqlConnection(
                "Data Source=localhost;" +
                "Initial Catalog=Tienda;" +
                "Integrated Security=true;" +
                "TrustServerCertificate=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = @"c:\backups\"+textBox1.Text+".bak";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = $"use master; alter database Tienda set single_user with rollback immediate; restore database Tienda from disk = '{ruta}' with replace; alter database Tienda set multi_user ";
                    com.ExecuteNonQuery();
                    MessageBox.Show("Restauracion de la BD exitosa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la BD" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
