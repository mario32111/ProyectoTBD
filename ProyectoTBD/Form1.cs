using Microsoft.Data.SqlClient;
using System.Data;

namespace ProyectoTBD
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(
                "Data Source=localhost;" +
                "Initial Catalog=Tienda;" +
                "Integrated Security=true;" +
                "TrustServerCertificate=True");

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();

            //esto hace que no permita hacer nada dentro de la aplicacion hasta que se le de en el boton de aceptar
            acercaDe.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 login = new Form2();
            login.ShowDialog();
        }

        private void backupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = @"c:\backups\respaldo.bak";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = $"BACKUP DATABASE Tienda TO DISK = '{ruta}' with format, init";
                    com.ExecuteNonQuery();
                    MessageBox.Show("Respaldo de la BD creado exitosamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el respaldo de la BD" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = @"c:\backups\respaldo.bak";
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

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos();
            prod.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos ped = new Pedidos();
            ped.ShowDialog();
        }

        private void restaurarConNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            respaldar2 r2 = new respaldar2();
            r2.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados emp = new Empleados();
            emp.ShowDialog();
        }
    }
}
