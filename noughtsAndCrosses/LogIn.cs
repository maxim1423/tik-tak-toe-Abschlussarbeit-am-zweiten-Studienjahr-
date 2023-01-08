using GameAccountLib.Data;
using Lab2;
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
    public partial class LogIn : Form
    {
         
        public LogIn()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            String userName = logInForm.Text;
            foreach(GameAccount gamer in GameAccount.gamers)
            {
                if (gamer.userName == userName)
                {
                    this.Hide();
                    Menu menu = new Menu(gamer);
                    menu.Show();
                    return;
                }
            }
            MessageBox.Show("There isn't account with this username");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            registrationForm reg = new registrationForm();
            reg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            registrationForm.saveDataAndExit(registrationForm.maxId);
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
