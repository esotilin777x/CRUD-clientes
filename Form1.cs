using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace CRUDClientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CargarClientes();

            // Estilos
            Estilos.EstilizarLabel(labelNombre);
            Estilos.EstilizarLabel(labelCorreo);
            Estilos.EstilizarTextBox(txtNombre);
            Estilos.EstilizarTextBox(txtCorreo);

            Estilos.AplicarEstiloDataGrid(dgvClientes);
            // Estilizar botones
            Estilos.EstilizarBoton(btnAgregar, "agregar");
            Estilos.EstilizarBoton(btnActualizar, "actualizar");
            Estilos.EstilizarBoton(btnEliminar, "eliminar");
            Estilos.EstilizarBoton(btnCargar, "cargar");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=esotilin;database=test_crud";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Clientes";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvClientes.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            if (nombre.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.");
                return;
            }

            if (!correo.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                return;
            }

            string connectionString = "server=localhost;user id=root;password=esotilin;database=test_crud";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Clientes (Nombre, Correo) VALUES (@nombre, @correo)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Cliente agregado correctamente.");
                    txtNombre.Clear();
                    txtCorreo.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cliente: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=esotilin;database=test_crud";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    int id = Convert.ToInt32(txtId.Text); 
                    string nombre = txtNombre.Text;
                    string correo = txtCorreo.Text;

                    string query = "UPDATE Clientes SET Nombre = @nombre, Correo = @correo WHERE Id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Cliente actualizado correctamente.");
                    txtId.Clear();
                    txtNombre.Clear();
                    txtCorreo.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                }
            }
        }

        private void CargarClientes()
        {
            string connectionString = "server=localhost;user id=root;password=esotilin;database=test_crud";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Clientes";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvClientes.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=esotilin;database=test_crud";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    int id = Convert.ToInt32(txtId.Text);

                    string query = "DELETE FROM Clientes WHERE Id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Cliente eliminado correctamente.");

                    // Limpiar los campos
                    txtId.Clear();
                    txtNombre.Clear();
                    txtCorreo.Clear();

                    CargarClientes(); 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no es el encabezado
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
            }

        }
    }
}

