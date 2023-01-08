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
    public partial class Menu : Form
    {
        GameAccount player;
        public Menu(GameAccount player)
        {
            this.player = player;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInOpp opp = new LogInOpp(player);
            opp.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Width = 914;
            this.Height = 515;
            button1.Hide();
            button2.Hide();
            label1.Show();

            for (int i = 0; i < GameAccount.allGame.Count(); i++)
            {
                dataGridView1.Rows.Add("row1");
                dataGridView1[0, i].Value = i+1;
                dataGridView1[1, i].Value = GameAccount.allGame[i].player1.userName;
                dataGridView1[2, i].Value = GameAccount.allGame[i].player2.userName;
                dataGridView1[3, i].Value = GameAccount.allGame[i].Winner;
                dataGridView1[4, i].Value = GameAccount.allGame[i].Rating;
                dataGridView1[5, i].Value = GameAccount.allGame[i].gameType.ToString();
                dataGridView1[6, i].Value = GameAccount.allGame[i].gameIndex.ToString();
            }
            dataGridView1.Show();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            button1.Show();
            button2.Show();
            label1.Hide();
            this.Width = 536;
            this.Height = 221;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            registrationForm.saveDataAndExit(registrationForm.maxId);
        }
    }
}
