using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class ProfileDetailsForm : Form
    {
        public ProfileDetailsForm()
        {
            InitializeComponent();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            ProfileAllForm pa = new ProfileAllForm();
            pa.Show();
            this.Hide();
        }
    }
}
