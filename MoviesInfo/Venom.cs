using System;
using System.Windows.Forms;

namespace DreamMovie.MoviesInfo
{
    public partial class Venom : Form
    {
        public Venom()
        {
            InitializeComponent();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainUser user = new Form_MainUser();
            user.Show();
            this.Close();
        }

        private void button_MoviesClick(object sender, EventArgs e)
        {
            Form movies = new MoviesList.Form_Movies2();
            movies.Show();
            this.Close();
        }

        private void button_SearchClick(object sender, EventArgs e)
        {
            Form_Search search = new Form_Search();
            search.Show();
            this.Close();
        }
    }
}
