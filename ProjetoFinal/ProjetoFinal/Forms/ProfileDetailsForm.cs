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
        bool active = false;
        string name = "";
        public ProfileDetailsForm()
        {
            InitializeComponent();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            GetData();
            MessageBox.Show("nome: " + name + "\nAtivo: " + active);
            CleanData();
        }
        void GetData()
        {
            name = tbxName.Text;
            if(cbxActive.Checked)
            {
                active = true;
            }
            else
            {
                active = false;
            }
        }

        void CleanData()
        {
            tbxName.Text = "";
            cbxActive.Checked = false;
        }
    }
}
