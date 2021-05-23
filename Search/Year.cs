using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace DreamMovie.Search
{
    public partial class Year : Form
    {
        public Year()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        Form_Login lf = new Form_Login();

        private void Year_Load(object sender, EventArgs e)
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
                myCommand = new SqlCommand("SELECT name, year FROM Movies WHERE year = @year", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@year", textBox1.Text);

                if(textBox1.Text.Length == 0)
                    MessageBox.Show("The textbox field cannot be empty!", "Refresh Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if(int.Parse(textBox1.Text) < 1800 || int.Parse(textBox1.Text) > 2021)
                    MessageBox.Show("There are no movies before 1800 or after 2021", "Refresh Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
