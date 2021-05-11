using Application_Development;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalReport
{
    public partial class NewFormEditForm : Form
    {
        public NewFormEditForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewPatient_Click(object sender, EventArgs e)
        {
            new NewPatientForm().Show();
            this.Hide();
        }

        private void NewFormEditForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            new Login_Form().Show();
            this.Hide();
        }

        private void buttonPatient_Click(object sender, EventArgs e)
        {
            new PatientForm().Show();
            this.Hide();
        }
    }
}
