using MedicalReport;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Application_Development
{
    public partial class Login_Form : Form
    {

        public Login_Form()
        {
            InitializeComponent();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLOGIN_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ApplicationDev;sslmode=none;";
            String doctor_ID = textBoxUsername.Text;
            String password = textBoxPassword.Text;
            string query = "SELECT DoctorPassword FROM DoctorCredentials WHERE Doctor_ID = BINARY " + doctor_ID ;
            MySqlConnection databaseCon = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseCon);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // Let's do it !
            // Open the database
            try
            {
                databaseCon.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :
                reader.Read();
                string[] row = { reader.GetString(0) };
                if (reader.HasRows && row[0] == password)
                {
                    
                    
                        new NewFormEditForm().Show();
                        this.Hide();
                    
                    
                }
                else
                MessageBox.Show("Something went wrong ");


            }
            catch (Exception ed)
            {
                MessageBox.Show("Something went wrong ");
            }
            
        }
        
        

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxPassword.Text = "";
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
        }

        private void labelCreateAccount_Click(object sender, EventArgs e)
        {
            new formRegister().Show();
            this.Hide();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
