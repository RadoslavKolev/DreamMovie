using System;
using System.Windows.Forms;

namespace DreamMovie
{
    public partial class Form_Search : Form
    {
        public Form_Search()
        {
            InitializeComponent();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainUser user = new Form_MainUser();
            user.Show();
            this.Close();
        }

        private void button_YearClick(object sender, EventArgs e)
        {
            Form year = new Search.Year();
            year.Show();
            this.Close();
        }

        private void button_GenreClick(object sender, EventArgs e)
        {
            Form genre = new Search.Genre();
            genre.Show();
            this.Close();
        }

        private void button_ActorsClick(object sender, EventArgs e)
        {
            Form actors = new Search.Actors();
            actors.Show();
            this.Close();
        }
    }
}
