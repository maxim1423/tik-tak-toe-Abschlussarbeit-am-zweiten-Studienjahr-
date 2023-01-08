using GameAccountLib.Data;
using Lab2.GameAccounts;
using MySql.Data.MySqlClient;
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
    public partial class LogInOpp : Form
    {
        private GameAccount player1;
        public LogInOpp(GameAccount player)
        {
            player1 = player;
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            String userName = logInForm.Text;
            if (player1.userName == userName)
            {
                MessageBox.Show("You can't play with yourself");
                return;
            }
            foreach (GameAccount gamer in GameAccount.gamers)
            {
                if (gamer.userName == userName)
                {
                    this.Hide();
                    SetGame setting = new SetGame(player1, gamer);
                    setting.Show();
                    return;
                }
            }
            MessageBox.Show("There isn't account with this username");  
        }

        private void label3_Click(object sender, EventArgs e)
        {
            registrationForm.saveDataAndExit(registrationForm.maxId);
        }
    }
}
