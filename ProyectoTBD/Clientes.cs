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
            dt = new DataTable();

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Ventas.Clientes";
            try
            {
                rdr = cmd.ExecuteReader();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                comboBox1.DataSource = dt; //Se establece como fuente de datos del combo
                comboBox1.DisplayMember = "Nombre";//Se configura al combo para que muestre el campo nombre
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            limpiar();
        }
        private void limpiar()
        {
            comboBox1.Text = ""; //Mostrar en blanco
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                //Agregar los datos a cada campo al seleccionar algun nombre
                textBox1.Text = dt.Rows[comboBox1.SelectedIndex][0].ToString();
                textBox2.Text = dt.Rows[comboBox1.SelectedIndex][1].ToString();
                textBox3.Text = dt.Rows[comboBox1.SelectedIndex][2].ToString();
                textBox4.Text = dt.Rows[comboBox1.SelectedIndex][3].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Limpiar los campos para poder crear un nuevo usuario
            limpiar();
            //Habilitar o deshabilitar el control de un boton
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("No se pueden guardar registros con campos en blanco...");
            }
            else
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //Ingresar un nuevo usuario 
                cmd.CommandText = "insert into Ventas.Clientes (Nombre, email, Telefono) values ('" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "')";

                try
                {
                    //Variable por la que a traves se hacen las operaciones en la base de datos
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente agregado correctamente...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                limpiar();

                //Ejecutar el evento load para poder agregar el nuevo registro al comboBox
                Clientes_Load(sender, e);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("No se pueden guardar registros con campos en blanco...");
            }
            else
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //Modificar un usuario existente 
                cmd.CommandText = "update Ventas.Clientes set Nombre = '" + textBox2.Text + "', " +
                    "email = '" + textBox3.Text + "', Telefono = '" + textBox4.Text + "'" +
                    " where ClienteID = " + Convert.ToInt32(textBox1.Text);

                try
                {
                    //Variable por la que a traves se hacen las operaciones en la base de datos
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Informacion del cliente modificada correctamente...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                limpiar();

                //Ejecutar el evento load para poder agregar el nuevo registro al comboBox
                Clientes_Load(sender, e);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("No se pueden eliminar registros con campos en blanco...");
            }
            else
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //Modificar un usuario existente 
                cmd.CommandText = "delete from Ventas.Clientes"+ 
                    " where ClienteID = " + Convert.ToInt32(textBox1.Text);

                try
                {
                    //Variable por la que a traves se hacen las operaciones en la base de datos
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Informacion del cliente eliminada correctamente...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                limpiar();

                //Ejecutar el evento load para poder agregar el nuevo registro al comboBox
                Clientes_Load(sender, e);
            }

        }
    }
}
