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
    public partial class gameWindow : Form
    {
        private Game game;

        private byte playersTurn = 1;
        
        public gameWindow(Game game)
        {
            this.game = game;
            InitializeComponent();
            label1.Text = "Turn " + game.player1.userName;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(playersTurn%2!=0)
            {
                sender.GetType().GetProperty("Text").SetValue(sender, "O");
                
                playersTurn++;
                label1.Text = "Turn: " + game.player2.userName;
                
            }
            else
            {
                sender.GetType().GetProperty("Text").SetValue(sender, "X");
                
                playersTurn++;
                label1.Text = "Turn: " + game.player1.userName;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            if (checkWin())
            {
                game.Winner = playersTurn%2 == 0 ? game.player1.userName : game.player2.userName;
                GameAccount.allGame.Add(game);
                MessageBox.Show("Winner " + game.Winner);
                this.Hide();
                LogIn log = new LogIn();
                log.Show();
            }
            else if (playersTurn == 10)
            {
                MessageBox.Show("Draw");
                this.Hide();
                LogIn log = new LogIn();
                log.Show();
            }
            
        }
        private bool checkWin()
        {
            if(isEqualText(button1,button2,button3))
            {
                return true;
            }
            else if (isEqualText(button4, button5, button6))
            {
                return true;
            }
            else if (isEqualText(button7, button8, button9))
            {
                return true;
            }
            else if (isEqualText(button1, button4, button7))
            {
                return true;
            }
            else if (isEqualText(button2, button5, button8))
            {
                return true;
            }
            else if (isEqualText(button3, button6, button9))
            {
                return true;
            }
            else if (isEqualText(button1, button5, button9))
            {
                return true;
            }
            else if (isEqualText(button3, button5, button7))
            {
                return true;
            }
            return false;
        }
        private bool isEqualText(Button button1,Button button2,Button button3)
        {
            return button1.Text == button2.Text && button2.Text == button3.Text && !button1.Enabled;
        }
        

        private void gameWindow_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            registrationForm.saveDataAndExit(registrationForm.maxId);
        }
    }
}
