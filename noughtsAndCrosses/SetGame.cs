
using GameAccountLib.Factory;
using Lab2;
using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noughtsAndCrosses
{
    public partial class SetGame : Form
    {
        GameAccount player1;
        GameAccount player2;
        public SetGame(GameAccount player1, GameAccount player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            InitializeComponent();
            label4.Text = player1.userName + "'s rating: " + player1.CurrentRating.ToString();
            label5.Text = player2.userName + "'s rating: " + player2.CurrentRating.ToString();
        }
        private void start_Click(object sender, EventArgs e)
        {
            GameFactory factory = new GameFactory();
            try
            {
                Console.WriteLine(player2.CurrentRating+"    "+ player1.CurrentRating);
                Game game = factory.createGame(player1, player2, Convert.ToInt32(rating.Text), type.SelectedItem.ToString());
                this.Hide();
                gameWindow gameW = new gameWindow(game);
                gameW.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            registrationForm.saveDataAndExit(registrationForm.maxId);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SetGame_Load(object sender, EventArgs e)
        {

        }
    }
}
