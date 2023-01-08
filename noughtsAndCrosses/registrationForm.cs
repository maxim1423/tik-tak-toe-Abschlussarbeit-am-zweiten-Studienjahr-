using GameAccountLib.Data;
using GameAccountLib.Factory;
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
    public partial class registrationForm : Form
    {
        public static int maxId {get;set;} 
        
        
        public registrationForm()
        {
            if (maxId == 0) Loaddata();
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (logInForm.Text == "")
            {
                MessageBox.Show("Enter name");
                return;
            }
            if (isUserExist(logInForm.Text))
                return;
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO gamers(username) VALUES (@login)", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = logInForm.Text;
            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Account hasn't created");
            }
            else
            {
                GameAccount.gamers.Add(new GameAccount(logInForm.Text));
                MessageBox.Show("Account has created");
                this.Hide();
                LogIn logIn = new LogIn();
                logIn.Show();
            }

            db.closeConnection();
        }
        public Boolean isUserExist(String name)
        {
            foreach(GameAccount gamer in GameAccount.gamers)
            {
                if (gamer.userName == name)
                {
                    MessageBox.Show("This name is already taken");
                    return true;
                }
            }
            return false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn login = new LogIn();
            login.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            saveDataAndExit(maxId);
        }
        private void Loaddata()
        {
            GameFactory factory = new GameFactory();

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT username FROM gamers ", db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                GameAccount.gamers.Add(new GameAccount(reader[0].ToString()));
            }

            reader.Close();

            command = new MySqlCommand("SELECT * FROM gameshistory ", db.getConnection());

            reader = command.ExecuteReader();

            Game game;

            string userName1;

            string userName2;

            GameAccount player1 = null;

            GameAccount player2 = null;

            while (reader.Read())
            {
                userName1 = reader[0].ToString();
                userName2 = reader[1].ToString();
                foreach (GameAccount gamer in GameAccount.gamers)
                {
                    if (gamer.userName == userName1)
                    {
                        player1 = gamer;
                    }
                    else if (gamer.userName == userName2)
                    {
                        player2 = gamer;
                    }
                }
                game = factory.createGame(player1, player2, Convert.ToInt32(reader[3]), reader[4].ToString());
                game.Winner = reader[2].ToString();
                GameAccount.allGame.Add(game);
                maxId = Convert.ToInt32(reader[5]);
            }
            reader.Close();
            db.closeConnection();
        }
        public static void saveDataAndExit(int maxId)
        {
            foreach (Game game in GameAccount.allGame)
            {
                if (game.gameIndex > maxId)
                {
                    DB db = new DB();
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("INSERT INTO gameshistory(player1, player2, winner, rating, gameType, gameIndex) VALUES (@p1,@p2,@w,@r,@gt,@id)", db.getConnection());
                    command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = game.player1.userName;
                    command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = game.player2.userName;
                    command.Parameters.Add("@w", MySqlDbType.VarChar).Value = game.Winner;
                    command.Parameters.Add("@r", MySqlDbType.Int32).Value = game.Rating;
                    command.Parameters.Add("@gt", MySqlDbType.VarChar).Value = game.gameType.ToString();
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = game.gameIndex;
                    command.ExecuteNonQuery();
                }
            }
            Application.Exit();
        }

        private void registrationForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
