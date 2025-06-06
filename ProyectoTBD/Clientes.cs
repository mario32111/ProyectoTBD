﻿using System;
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
        SqlConnection conn; //objeto para hacer la conexion
        SqlCommand cmd;//objeto que ejecuta las operaciones sobre esa conexion
        SqlDataReader rdr; // Change SqlDataAdapter to SqlDataReader, operaciones de consulta
        DataTable dt; //operaciones en local en una table, pero no en la bd
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
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Ventas.Clientes";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
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
                    cmd.ExecuteNonQuery();//cuando la operacion es un insert, delete y modify
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
                cmd.CommandText = "delete from Ventas.Clientes" +
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

        private void button6_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta
            cmd.CommandText = "select * from Ventas.Clientes where Nombre like '%" +
                textBox2.Text + "%' and ClienteId in (select ClienteId from Ventas.Clientes where Email like '%@gmail.com')";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button7_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas
            cmd.CommandText = "select * from Ventas.Clientes where ClienteID in (select distinct ClienteID from Pedidos)";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button8_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID, Nombre, (select sum(Total) from Pedidos where Pedidos.ClienteID= Ventas.Clientes.ClienteID) " +
                "as TotalPeidos from Ventas.Clientes where ClienteID in (select distinct ClienteID from Pedidos)";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button9_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID, Nombre, (select avg(Total) from Pedidos where Pedidos.ClienteID= Ventas.Clientes.ClienteID) " +
                "as TotalPeidos from Ventas.Clientes where ClienteID in (select distinct ClienteID from Pedidos)";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button10_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID, (select count(*) from Pedidos where Pedidos.ClienteID = Ventas.Clientes.ClienteID) as CantidadPedidos" +
                " from Ventas.Clientes where ClienteID in (select distinct ClienteID from Pedidos)";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button11_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID, (select max(Total) from Pedidos where Pedidos.ClienteID = Ventas.Clientes.ClienteID) as PedidoMayor" +
                " from Ventas.Clientes where ClienteID in (select distinct ClienteID from Pedidos)";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button12_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select c.ClienteID, c.Nombre, sum(p.Total) as TotalPedidos from Ventas.Clientes c inner join Pedidos p on c.ClienteID = p.ClienteID group by c.ClienteID, c.Nombre";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button13_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID from Ventas.Clientes union select ClienteID from Pedidos";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button14_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID from Ventas.Clientes intersect select ClienteID from Pedidos";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button15_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "select ClienteID from Ventas.Clientes except select ClienteID from Pedidos";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "UPDATE Ventas.Clientes SET Telefono = 'SIN REGISTRO' WHERE Email LIKE '%@gmail.com'";
            try
            {
                //Variable por la que a traves se hacen las operaciones en la base de datos
                cmd.ExecuteNonQuery();//cuando la operacion es un insert, delete y modify
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

        private void button17_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "DELETE FROM Ventas.Clientes WHERE Edad < 30;";
            try
            {
                //Variable por la que a traves se hacen las operaciones en la base de datos
                cmd.ExecuteNonQuery();//cuando la operacion es un insert, delete y modify
                MessageBox.Show("Clientes eliminados correctamente");
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

        private void button18_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT * FROM Ventas.Clientes ORDER BY Nombre ASC;";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button19_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT * FROM Ventas.Clientes WHERE EDAD >=25 AND  EDAD <=35;";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button20_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT Nombre, Email FROM Ventas.Clientes WHERE Ingresos > 50000;";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button21_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT AVG(Edad) AS EdadPromedio FROM Ventas.Clientes WHERE Email LIKE '%@gmail.com';";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button22_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT Telefono FROM Ventas.Clientes WHERE Ingresos > (SELECT AVG(Ingresos) FROM Ventas.Clientes);";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button23_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT * FROM Ventas.Clientes WHERE Ingresos = (SELECT MAX(Ingresos) FROM Ventas.Clientes);";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button24_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT * FROM Ventas.Clientes WHERE Ingresos > (SELECT AVG(Ingresos) FROM Ventas.Clientes);";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button25_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT * FROM Ventas.Clientes WHERE Edad = (SELECT MIN(Edad) FROM Ventas.Clientes);";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button26_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT Nombre FROM Ventas.Clientes WHERE Ingresos > 40000 UNION SELECT Nombre FROM Ventas.Clientes WHERE Edad < 30;";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button27_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT Nombre FROM Ventas.Clientes WHERE Ingresos > 40000 INTERSECT SELECT Nombre FROM Ventas.Clientes WHERE Edad < 30;";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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

        private void button28_Click(object sender, EventArgs e)
        {
            //el data sourde es para dare valor a el combobox
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //ejemplo de subconsulta con multiples tablas, con operador de agregacion
            cmd.CommandText = "SELECT COUNT(*) AS TotalClientes FROM Ventas.Clientes;";
            try
            {
                rdr = cmd.ExecuteReader();//esto en caso de la conslta a realizar retorne una tabla, si es escalar se usa ExecuteScalar
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Load(rdr);//Se carga el datatable a partir del Datareader
                dataGridView1.DataSource = dt; //Se establece como fuente de datos del combo
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
    }
}
