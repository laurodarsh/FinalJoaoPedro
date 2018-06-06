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
    public partial class UserDetailsForm : Form
    {
        string name = "";
        string email = "";
        string password = "";
        string confirmPassword = "";
        string profile = "";
        bool active = false;
        public UserDetailsForm()
        {
            InitializeComponent();
            cmbProfile.Items.Add("Selecionar Tipo de Perfil");
        }
        private void pbxDelete_Click(object sender, EventArgs e)
        {

        }
        private void pbxBack_Click(object sender, EventArgs e)
        {
            UserAllForm ua = new UserAllForm();
            ua.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            GetData();
            MessageBox.Show("nome: " + name +"\nPerfil:"+profile + "\nsenha"+password+"\nconfirma senha"+confirmPassword+"\nemail"+email + "\nAtivo: " + active);
            CleanData();
        }
        void GetData()
        {
            name = tbxName.Text;
            password = tbxPass.Text;
            confirmPassword = tbxPassConfirm.Text;
            email = tbxEmail.Text;
            profile = cmbProfile.Text;
            if (cbxActive.Checked)
            {
                active = true;
            }else
            {
                active = false;
            }
        }
        void CleanData()
        {
            tbxEmail.Text = "";
            tbxName.Text = "";
            tbxPass.Text = "";
            tbxPassConfirm.Text = "";
            cbxActive.Checked = false;
            cmbProfile.SelectedIndex = 0;
        }
    }
}
