using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DreamMovie.Search
{
    public partial class Actors : Form
    {
        public Actors()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        Form_Login lf = new Form_Login();

        private void Actors_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.moviesDataSet.Movies);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainUser user = new Form_MainUser();
            user.Show();
            this.Close();
        }

        private void button_MoviesClick(object sender, EventArgs e)
        {
            Form_Movies movie = new Form_Movies();
            movie.Show();
            this.Close();
        }

        private void button_SearchClick(object sender, EventArgs e)
        {
            Form_Search search = new Form_Search();
            search.Show();
            this.Close();
        }

        private void button_ShowClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("SELECT name, actors FROM Movies WHERE actors = @actors", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@actors", textBox1.Text);

                if (textBox1.Text.Length == 0)
                    MessageBox.Show("The textbox field cannot be empty!", "Refresh Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!textBox1.Text.Contains(""))
                    MessageBox.Show("Fullname required!", "Refresh Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    myCommand.ExecuteNonQuery();

                SqlDataReader rdr = myCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(rdr);
                dataGridView1.DataSource = dataTable;
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
