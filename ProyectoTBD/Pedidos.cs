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
            com.CommandText = "EliminarPedido";
            com.Parameters.AddWithValue("@PedidoID", Convert.ToInt32(textBox1.Text));

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Pedido eliminado correctamente");
            }
            catch (SqlException ex)
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
            com.CommandText = "InsertarPedido";
            com.Parameters.AddWithValue("@ClienteID", Convert.ToInt32(textBox2.Text));
            com.Parameters.AddWithValue("@FechaPedido", DateTime.Parse(textBox3.Text));
            com.Parameters.AddWithValue("@Total", Convert.ToDecimal(textBox4.Text));

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
            com.CommandText = "ActualizarPedido";
            com.Parameters.AddWithValue("@PedidoID", Convert.ToInt32(textBox1.Text));
            com.Parameters.AddWithValue("@ClienteID", Convert.ToInt32(textBox2.Text));
            com.Parameters.AddWithValue("@FechaPedido", DateTime.Parse(textBox3.Text));
            com.Parameters.AddWithValue("@Total", Convert.ToDecimal(textBox4.Text));


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

        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from dbo.ConsultarPedidos(@PedidoID)";
            com.Parameters.AddWithValue("@PedidoID", Convert.ToInt32(textBox1.Text));

            try
            {
                lector = com.ExecuteReader();
                if (lector.Read())
                {
                    textBox2.Text = lector.GetInt32(1).ToString();
                    textBox3.Text = lector.GetDateTime(2).ToString();
                    textBox4.Text = lector.GetDecimal(3).ToString();
                }
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select dbo.SumarPedidos(@ClienteID)";
            com.Parameters.AddWithValue("@ClienteID", Convert.ToInt32(textBox2.Text));

            try
            {
                decimal total = Convert.ToDecimal(com.ExecuteScalar());
                MessageBox.Show($"El cliente se ha gastado con el ID: {textBox2.Text} es : {total}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sumar los totales: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
