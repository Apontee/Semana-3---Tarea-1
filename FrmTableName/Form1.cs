using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrmTableName
{
    public partial class Form1 : Form
    {
       
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=instpubs;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        
        private void LoadData()
        {
            try
            {
                connection.Open(); 
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TableName", connection); 
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            finally
            {
                connection.Close(); 
            }
        }

     
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TableName (Column1, Column2) VALUES (@val1, @val2)", connection);
                cmd.Parameters.AddWithValue("@val1", textBox1.Text); 
                cmd.Parameters.AddWithValue("@val2", textBox2.Text); 
                cmd.ExecuteNonQuery(); 
                MessageBox.Show("Datos guardados correctamente.");
                LoadData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
            finally
            {
                connection.Close(); 
            }
        }

      
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open(); 
                SqlCommand cmd = new SqlCommand("DELETE FROM TableName WHERE Id = @id", connection);
                cmd.Parameters.AddWithValue("@id", textBoxId.Text); 
                cmd.ExecuteNonQuery(); 
                MessageBox.Show("Datos eliminados correctamente.");
                LoadData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar los datos: " + ex.Message);
            }
            finally
            {
                connection.Close(); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
