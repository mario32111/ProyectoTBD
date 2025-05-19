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
    public partial class Pedidos : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader lector;
        DataTable tabla;
        public Pedidos()
        {
            InitializeComponent();
            con = new SqlConnection(
                "Data Source=localhost;" +
                "Initial Catalog=Tienda;" +
                "Integrated Security=true;" +
                "TrustServerCertificate=True");
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "EliminarPedidos";
            com.Parameters.AddWithValue("@pedido_id", Convert.ToInt32(textBox2.Text));

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Pedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pedido: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "InsertarPedidos";
            com.Parameters.AddWithValue("@cliente_id", Convert.ToInt32(textBox2.Text));
            com.Parameters.AddWithValue("@fecha", textBox3.Text);
            com.Parameters.AddWithValue("@total", Convert.ToDecimal(textBox4.Text));

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Pedido registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "ActualizarPedidos";
            com.Parameters.AddWithValue("@pedido_id", Convert.ToInt32(textBox1.Text));
            com.Parameters.AddWithValue("@cliente_id", Convert.ToInt32(textBox2.Text));
            com.Parameters.AddWithValue("@fecha", textBox3.Text);
            com.Parameters.AddWithValue("@total", Convert.ToDecimal(textBox4.Text));

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Pedido actualizado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pedido: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
