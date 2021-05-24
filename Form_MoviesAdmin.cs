using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace DreamMovie
{
    public partial class Form_MoviesAdmin : Form
    {
        public Form_MoviesAdmin()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();

        private void DisplayData()
        {
            myConnection = new SqlConnection(lf.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Movies", myConnection);
            adapter2 = new SqlDataAdapter("SELECT * FROM Genre", myConnection);
            adapter.Fill(dataTable);
            adapter2.Fill(dataTable2);
            dataGridView1.DataSource = dataTable;
            dataGridView2.DataSource = dataTable2;
            myConnection.Close();
        }

        private void Form_MoviesAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.moviesDataSet.Movies);
            // TODO: This line of code loads data into the 'moviesDataSet1.Genre' table. You can move, or remove it, as needed.
            this.genreTableAdapter.Fill(this.moviesDataSet1.Genre);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainAdmin admin = new Form_MainAdmin();
            admin.Show();
            this.Close();
        }

        private void button_InsertClick(object sender, EventArgs e)
        {
            try
            {
                string check = "[A-Za-z]";
                if (textBox2.Text == "" || textBox3.Text == "")
                    MessageBox.Show("The second and third fields cannot be empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Regex.IsMatch(textBox1.Text, check))
                    MessageBox.Show("The movie code must contains only numbers!", "Code error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myConnection = new SqlConnection(lf.connection);
                    myCommand = new SqlCommand("INSERT INTO Movies(name, genre_id, year, actors, summary) VALUES(@name, @genre, @year, @actors, @summary)", myConnection);

                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@name", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@genre", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@year", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@actors", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@summary", richTextBox1.Text);

                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Movie added successfully!");

                    myConnection.Close();
                    DisplayData();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    richTextBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_UpdateClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("UPDATE Movies SET name = @name, genre_id = @genre, year = @year, actors = @actors, summary = @summary WHERE id = @id", myConnection);
                SqlCommand checkCode = new SqlCommand("SELECT id FROM Movies WHERE id = @id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@id", textBox1.Text);
                myCommand.Parameters.AddWithValue("@name", textBox2.Text);
                myCommand.Parameters.AddWithValue("@genre", textBox3.Text);
                myCommand.Parameters.AddWithValue("@year", textBox4.Text);
                myCommand.Parameters.AddWithValue("@actors", textBox5.Text);
                myCommand.Parameters.AddWithValue("@summary", richTextBox1.Text);

                checkCode.Parameters.AddWithValue("@id", textBox1.Text);

                SqlDataReader sdr = checkCode.ExecuteReader();

                if (!sdr.HasRows)
                    MessageBox.Show("ID not found", "Update Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    sdr.Close();

                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && richTextBox1.Text == "")
                    MessageBox.Show("Fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Movie updated successfully!");
                    DisplayData();
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_DeleteClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("DELETE Movies WHERE id = @id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@id", textBox1.Text);

                if (textBox1.Text == "")
                    MessageBox.Show("ID Field cannot be empty!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Movie deleted successfully!");
                    DisplayData();
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataTableToTextFile(DataTable dt, string outputFilePath)
        {
            int[] maxLengths = new int[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;
                        if (length > maxLengths[i])
                            maxLengths[i] = length;
                    }
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(outputFilePath, false))
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                        sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));

                    sw.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (!row.IsNull(i))
                                sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                            else
                                sw.Write(new string(' ', maxLengths[i] + 2));
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                }
            }
            catch { }
        }

        private void button_SaveToTxtClick(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = lf.connection;

            DataTable dt = new DataTable();
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                dt.Columns.Add(column.Name, column.ValueType);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                    if (row.Cells[column.Name].Value != null)
                        dr[column.Name] = row.Cells[column.Name].Value.ToString();
                dt.Rows.Add(dr);
            }

            string filePath = "D:\\ТУ Варна\\Семестър 6\\Управление на софтуерни проекти\\Проект\\DreamMovie\\Справки\\Movies.txt";
            DataTableToTextFile(dt, filePath);
            MessageBox.Show("Data saved successfully!", "Data saved!");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
