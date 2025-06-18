using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ProyectoTBD
{
    public partial class Detalles : Form
    {
        OdbcConnection con;
        OdbcCommand com;
        OdbcDataReader lector;
        int pedido;
        public Detalles(int id)
        {
            InitializeComponent();
            con = new OdbcConnection("Driver={ODBC Driver 17 for SQL Server};Server=localhost;Database=Tienda;Trusted_Connection=Yes;");


            pedido = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new OdbcCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "INSERT INTO DetallePedidos(PedidoID, Cantidad, Precio, ProductoID) VALUES (?, ?, ?, ?)";
            com.Parameters.AddWithValue("", Convert.ToInt32(textBox2.Text));
            com.Parameters.AddWithValue("", Convert.ToInt32(textBox3.Text));
            com.Parameters.AddWithValue("", Convert.ToDecimal(textBox4.Text));
            com.Parameters.AddWithValue("", Convert.ToDecimal(textBox5.Text));

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

        private void Detalles_Load(object sender, EventArgs e)
        {
            textBox2.Text = pedido.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
