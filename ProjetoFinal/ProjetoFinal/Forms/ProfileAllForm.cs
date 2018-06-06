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
    public partial class ProfileAllForm : Form
    {
        public ProfileAllForm()
        {
            InitializeComponent();
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            ProfileDetailsForm pd = new ProfileDetailsForm();
            pd.Show();
            this.Hide();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {

        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            HomeForm hf = new HomeForm();
            hf.Show();
            this.Hide();
        }
    }
}
