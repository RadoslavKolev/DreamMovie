using System;
using System.Windows.Forms;

namespace DreamMovie
{
    public partial class Form_MainAdmin : Form
    {
        public Form_MainAdmin()
        {
            InitializeComponent();
        }

        private void button_MoviesClick(object sender, EventArgs e)
        {
            Form_MoviesAdmin moviesAdmin = new Form_MoviesAdmin();
            moviesAdmin.Show();
            this.Hide();
        }

        private void button_AccountsClick(object sender, EventArgs e)
        {
            Form_Accounts acc = new Form_Accounts();
            acc.Show();
            this.Hide();
        }

        private void button_ExitClick(object sender, EventArgs e)
        {
            Form_Login lf = new Form_Login();
            lf.Show();
            this.Close();
        }
    }
}
