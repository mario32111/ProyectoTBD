using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProyectoTBD
{
    public partial class Productos : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader lector;
        DataTable tabla;
        SqlTransaction trans;
        public Productos()
        {
            InitializeComponent();
            con = new SqlConnection(
                "Data Source=localhost;" +
                "Initial Catalog=Tienda;" +
                "Integrated Security=true;" +
                "TrustServerCertificate=True");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Esto hace referencia a el nivel de aislamiento
            trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
            com = new SqlCommand();
            try
            {
                com.CommandText = "insert into Ventas.Productos(Nombre, Precio, Existencia) values (@Nombre, @Precio, @Existencia)";
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.Transaction = trans;
                //asignacion de los parametros a el textbox
                com.Parameters.AddWithValue("@Nombre", textBox2.Text);
                com.Parameters.AddWithValue("@Precio", Convert.ToDecimal(textBox3.Text));
                com.Parameters.AddWithValue("@Existencia", Convert.ToInt32(textBox4.Text));

                //evaluar si hubo filas afectadas o no
                int res = com.ExecuteNonQuery();
                if (res > 0)
                {
                    //esto asegura que la transaccion se ejecut, puede tener una o varias operaciones   
                    trans.Commit();
                    MessageBox.Show("Producto agregado.....");
                }
                else
                {
                    trans.Rollback();
                }

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error" + ex.Message);
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
            //Esto hace referencia a el nivel de aislamiento
            trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
            com = new SqlCommand();
            try
            {
                com.CommandText = "update Ventas.Productos set Nombre = @Nombre, Precio = @Precio, Existencia = @Existencia where ProductoID = @ProductoID";
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.Transaction = trans;
                //asignacion de los parametros a el textbox
                com.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(textBox1.Text));
                com.Parameters.AddWithValue("@Nombre", textBox2.Text);
                com.Parameters.AddWithValue("@Precio", Convert.ToDecimal(textBox3.Text));
                com.Parameters.AddWithValue("@Existencia", Convert.ToInt32(textBox4.Text));

                //evaluar si hubo filas afectadas o no
                int res = com.ExecuteNonQuery();
                if (res > 0)
                {
                    //esto asegura que la transaccion se ejecut, puede tener una o varias operaciones   
                    trans.Commit();
                    MessageBox.Show("Producto actualizado.....");
                }
                else
                {
                    trans.Rollback();
                }

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error" + ex.Message);
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
            //Esto hace referencia a el nivel de aislamiento
            trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
            com = new SqlCommand();
            try
            {
                com.CommandText = "delete Ventas.Productos where ProductoID = @ProductoID";
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.Transaction = trans;
                //asignacion de los parametros a el textbox
                com.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(textBox1.Text));

                //evaluar si hubo filas afectadas o no
                int res = com.ExecuteNonQuery();
                if (res > 0)
                {
                    //esto asegura que la transaccion se ejecut, puede tener una o varias operaciones   
                    trans.Commit();
                    MessageBox.Show("Producto actualizado.....");
                }
                else
                {
                    trans.Rollback();
                }

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error" + ex.Message);
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
            trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
            com = new SqlCommand();
            try
            {
                com.CommandText = "select * from Ventas.Productos where ProductoID = @ProductoID";
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.Transaction = trans;
                com.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(textBox1.Text));

                lector = com.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    textBox2.Text = lector.GetString(1);
                    textBox3.Text = lector.GetDecimal(2).ToString();
                    textBox4.Text = lector.GetInt32(3).ToString();
                }
                else
                    MessageBox.Show("No se encontraron datos...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }
    }
}
