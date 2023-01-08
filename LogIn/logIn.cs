using System;
using GameAccountLib.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Lab2.GameAccounts;
using registration;

namespace LogIn
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            
            
        }

        private void buttonLogIn_Click_1(object sender, EventArgs e)
        {

            String userName = logInForm.Text;
            String accountType;
            int rating;

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT rating, accountType FROM gamers WHERE username = @uN", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = userName;

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                bool GamerExistance = false;
                foreach (GameAccount gamer in GameAccount.gamers)
                {
                    if (userName == gamer.userName)
                    {
                        GamerExistance = true;
                    }
                }
                if (!GamerExistance)
                {

                }

            }
            db.closeConnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void logInForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration reg = new registration();
        }
    }
}
