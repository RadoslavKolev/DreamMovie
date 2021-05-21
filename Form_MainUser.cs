using System;
using System.Windows.Forms;

namespace DreamMovie
{
    public partial class Form_MainUser : Form
    {
        public Form_MainUser()
        {
            InitializeComponent();
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
            this.Hide();
        }

        private void button_BackToLoginClick(object sender, EventArgs e)
        {
            Form_Login lf = new Form_Login();
            lf.Show();
            this.Close();
        }
    }
}
