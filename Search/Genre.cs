using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DreamMovie.Search
{
    public partial class Genre : Form
    {
        public Genre()
        {
            InitializeComponent();
        }

        private void Genre_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet1.Genre' table. You can move, or remove it, as needed.
            this.genreTableAdapter.Fill(this.moviesDataSet1.Genre);
            // TODO: This line of code loads data into the 'moviesDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.moviesDataSet.Movies);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        Form_Login lf = new Form_Login();

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
                myCommand = new SqlCommand("SELECT m.name, m.year, m.actors, g.genre FROM Movies m, Genre g WHERE g.genre = @genre AND m.genre_id = g.id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@genre", textBox1.Text);

                if (textBox1.Text.Length == 0)
                    MessageBox.Show("The textbox field cannot be empty!", "Refresh Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
