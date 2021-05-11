using MedicalReport;
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

namespace Application_Development
{
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
                textBoxConfirmPasword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                textBoxConfirmPasword.PasswordChar = '*';
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
           string doctoriD =  textBoxUsername.Text ;
            string password=  textBoxPassword.Text ;
            string confirmPassword =  textBoxConfirmPasword.Text ;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ApplicationDev;sslmode=none;";
            
            string query = "SELECT Doctor_ID FROM DoctorCredentials WHERE Doctor_ID = BINARY " + doctoriD;
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

                if (reader.HasRows)
                {
                    MessageBox.Show("Doctor ID Already Exists");
                }
                else
                {
                    Registtration();

                }


            }
            catch (Exception ed)
            {
                Registtration();
            }


        }
        void Registtration()
        {
            string doctoriD = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPasword.Text;
            int doctorIDInNumber;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ApplicationDev;sslmode=none;";

            string query = "INSERT INTO ApplicationDev.doctorcredentials(Doctor_ID, DoctorPassword ) VALUES ('" + doctoriD + "', '" + password + "')";

            MySqlConnection databaseCon = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseCon);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            if (!int.TryParse(doctoriD, out doctorIDInNumber))
            {
                MessageBox.Show("Incorrect format");
            }

            else if (password.Length < 4)
            {
                MessageBox.Show("Password to small");

            }
            else if (password != confirmPassword)
            {
                MessageBox.Show("PAssword field and confirm password does not match");

            }
            else
            {
                try
                {
                    databaseCon.Open();

                    // Execute the query
                    reader = commandDatabase.ExecuteReader();
                    reader.Read();

                    // All succesfully executed, now do something
                    MessageBox.Show("Registration complete");

                    // IMPORTANT : 
                    // If your query returns result, use the following processor :


                    new NewFormEditForm().Show();
                    this.Hide();
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
            
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxConfirmPasword.Text = "";
            textBoxUsername.Focus();
        }

        private void labelBackToLOGIN_Click(object sender, EventArgs e)
        {
            new Login_Form().Show();
            this.Hide();
        }

        private void formRegister_Load(object sender, EventArgs e)
        {

        }

        private void labelAlreadyHaveAnAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
