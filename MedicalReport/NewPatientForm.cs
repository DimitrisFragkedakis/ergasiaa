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
    public partial class NewPatientForm : Form
    {
        public NewPatientForm()
        {
            InitializeComponent();
        }

        private void buttonBACK_Click(object sender, EventArgs e)
        {
            new NewFormEditForm().Show();
            this.Hide();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            new Visit().Show();
            this.Hide();
        }
    }
}
