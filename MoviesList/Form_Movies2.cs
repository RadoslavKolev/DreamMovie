using System;
using System.Windows.Forms;

using DreamMovie;

namespace DreamMovie.MoviesList
{
    public partial class Form_Movies2 : Form
    {
        public Form_Movies2()
        {
            InitializeComponent();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainUser mainUser = new Form_MainUser();
            mainUser.Show();
            this.Close();
        }

        private void button_SpaceClick(object sender, EventArgs e)
        {
            Form space = new MoviesInfo.Space();
            space.Show();
            this.Hide();
        }

        private void button_RayaClick(object sender, EventArgs e)
        {
            Form raya = new MoviesInfo.Raya();
            raya.Show();
            this.Hide();
        }

        private void button_VenomClick(object sender, EventArgs e)
        {
            Form venom = new MoviesInfo.Venom();
            venom.Show();
            this.Hide();
        }

        private void button_StowawayClick(object sender, EventArgs e)
        {
            Form stowaway = new MoviesInfo.Stowaway();
            stowaway.Show();
            this.Hide();
        }

        private void button_PeterRabbit2Click(object sender, EventArgs e)
        {
            Form rabbit = new MoviesInfo.Peter_Rabbit2();
            rabbit.Show();
            this.Hide();
        }

        private void button_BackClick(object sender, EventArgs e)
        {
            Form_Movies back = new Form_Movies();
            back.Show();
            this.Close();
        }

        private void button_ForwardClick(object sender, EventArgs e)
        {
            Form forward = new MoviesList.Form_Movies3();
            forward.Show();
            this.Close();
        }
    }
}
