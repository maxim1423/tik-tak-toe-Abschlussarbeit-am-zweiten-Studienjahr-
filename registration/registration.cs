using GameAccountLib.Data;
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

namespace registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void logInForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (logInForm.Text == "")
            {
                MessageBox.Show("Enter name");
                return;
            }
            if (comboBox1.SelectedItem==null)
            {
                MessageBox.Show("Choose type of account");
                return;
            }
            if (isUserExist())
                return;
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO gamers(username, accountType, rating) VALUES (@login,@type, 10)",db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = logInForm.Text;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Account don't create");
            }

            db.closeConnection();
        }
        public Boolean isUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM gamers WHERE username = @ul",db.getConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = logInForm.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("this name is already taken. Enter another");
                return true;
                
            }
            else 
            {
                return false;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
