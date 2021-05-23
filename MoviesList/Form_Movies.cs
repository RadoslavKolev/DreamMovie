using System;
using System.Windows.Forms;

using DreamMovie;

namespace DreamMovie
{
    public partial class Form_Movies : Form
    {
        public Form_Movies()
        {
            InitializeComponent();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainUser mainUser = new Form_MainUser();
            mainUser.Show();
            this.Close();
        }

        private void button_F9Click(object sender, EventArgs e)
        {
            Form f9 = new MoviesInfo.F9();
            f9.Show();
            this.Hide();
        }

        private void button_NobodyClick(object sender, EventArgs e)
        {
            Form nobody = new MoviesInfo.Nobody();
            nobody.Show();
            this.Hide();
        }

        private void button_MortalKombatClick(object sender, EventArgs e)
        {
            Form mk = new MoviesInfo.Mortal_Kombat();
            mk.Show();
            this.Hide();
        }

        private void button_KillerAmongUsClick(object sender, EventArgs e)
        {
            Form killer = new MoviesInfo.Killer_Among_Us();
            killer.Show();
            this.Hide();
        }

        private void button_TransformaniaClick(object sender, EventArgs e)
        {
            Form transformania = new MoviesInfo.Transformania();
            transformania.Show();
            this.Hide();
        }

        private void button_BackClick(object sender, EventArgs e)
        {
            Form_MainUser mainUser = new Form_MainUser();
            mainUser.Show();
            this.Close();
        }

        private void button_ForwardClick(object sender, EventArgs e)
        {
            Form movies = new MoviesList.Form_Movies2();
            movies.Show();
            this.Hide();
        }
    }
}
