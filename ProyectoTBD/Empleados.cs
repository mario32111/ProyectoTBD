using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ProyectoTBD
{
    public partial class Empleados : Form
    {
        OleDbConnection con;
        OleDbCommand com;
        OleDbDataReader lector;
        public Empleados()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\Mario\\Documents\\Ejemplo.accdb");
        }

        private void Empleados_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new OleDbCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into Empleados (Nombre, Area, Telefono) values (@nombre, @area, @telefono)";
            com.Parameters.AddWithValue("@nombre", (textBox2.Text));
            com.Parameters.AddWithValue("@area", (textBox3.Text));
            com.Parameters.AddWithValue("@telefono", (textBox4.Text));

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Datos almacenados correctamente");
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
            com = new OleDbCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Empleados where EmpleadoID = @empleado_id";
            com.Parameters.AddWithValue("@empleado_id", Convert.ToInt32(textBox1.Text));
            try
            {
                lector = com.ExecuteReader();
                while (lector.Read())
                {
                    textBox2.Text = lector.GetString(1);
                    textBox3.Text = lector.GetString(2);
                    textBox4.Text = lector.GetString(3);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new OleDbCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "update Empleados set Nombre = ?, Area = ?, Telefono = ? where EmpleadoID = ?";
            com.Parameters.AddWithValue("nombre", (textBox2.Text));
            com.Parameters.AddWithValue("area", (textBox3.Text));
            com.Parameters.AddWithValue("telefono", (textBox4.Text));
            com.Parameters.AddWithValue("empleado_id", Convert.ToInt32(textBox1.Text));


            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Datos modificados correctamente");
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            com = new OleDbCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "delete from Empleados where EmpleadoID = @empleado_id";
            com.Parameters.AddWithValue("empleado_id", Convert.ToInt32(textBox1.Text));


            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Datos modificados correctamente");
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
    }
}
