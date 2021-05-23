using System;
using System.Windows.Forms;

namespace DreamMovie.MoviesList
{
    public partial class Form_Movies3 : Form
    {
        public Form_Movies3()
        {
            InitializeComponent();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            Form_MainUser mainUser = new Form_MainUser();
            mainUser.Show();
            this.Close();
        }

        private void button_BlackWidowClick(object sender, EventArgs e)
        {
            Form widow = new MoviesInfo.Black_Widow();
            widow.Show();
            this.Hide();
        }

        private void button_SixMinutesTillDaylightClick(object sender, EventArgs e)
        {
            Form daylight = new MoviesInfo._6_Minutes_Till_Daylight();
            daylight.Show();
            this.Hide();
        }

        private void button_JungleCruiseClick(object sender, EventArgs e)
        {
            Form jungleCruise = new MoviesInfo.Jungle_Cruise();
            jungleCruise.Show();
            this.Hide();
        }

        private void button_TheForeverPurgeClick(object sender, EventArgs e)
        {
            Form purge = new MoviesInfo.The_Forever_Purge();
            purge.Show();
            this.Hide();
        }

        private void button_GodzillaVsKongClick(object sender, EventArgs e)
        {
            Form fight = new MoviesInfo.Godzilla_vs_Kong();
            fight.Show();
            this.Hide();
        }

        private void button_BackClick(object sender, EventArgs e)
        {
            Form_Movies2 back = new Form_Movies2();
            back.Show();
            this.Close();
        }
    }
}
