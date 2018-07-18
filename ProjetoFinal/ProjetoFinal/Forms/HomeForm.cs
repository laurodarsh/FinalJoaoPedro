using ProjetoFinal.Classes;
using ProjetoFinal.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class HomeForm : Form
    {
        public HomeForm(/*User user*/)
        {
            InitializeComponent();
            /*
            if(user.Id =! 1)
            {
                pbxLog.Visible = false;
                pbxProfile.Visible = false;
                pbxUser.Visible = false;
            }*/
        }

        private void pbxCategory_MouseEnter(object sender, EventArgs e)
        {
            lblCategory.Visible = true;
            pbxCategory.BackColor = Color.Turquoise;
        }
        
        private void pbxProfile_MouseLeave(object sender, EventArgs e)
        {
            lblUserProfile.Visible = false;
            pbxProfile.BackColor = Color.Transparent;
        }

        private void pbxProfile_MouseEnter(object sender, EventArgs e)
        {
            lblUserProfile.Visible = true;
            pbxProfile.BackColor = Color.Tomato;
        }

        private void pbxCategory_MouseLeave(object sender, EventArgs e)
        {
            lblCategory.Visible = false;
            pbxCategory.BackColor = Color.Transparent;
        }

        private void pbxLog_MouseEnter(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.Teal;
            lblLog.Visible = true;
        }

        private void pbxLog_MouseLeave(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.Transparent;
            lblLog.Visible = false;
        }

        private void pbxProduct_MouseEnter(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.Navy;
            lblProduct.Visible = true;
        }

        private void pbxProduct_MouseLeave(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.Transparent;
            lblProduct.Visible = true;
        }

        private void pbxUser_MouseEnter(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.Plum;
            lblUser.Visible = true;
        }

        private void pbxUser_MouseLeave(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.Transparent;
            lblUser.Visible = false;
        }

        private void pbxProduct_Click(object sender, EventArgs e)
        {
            ProductAllForm pa = new ProductAllForm();
            pa.Show();
        }

        private void pbxCategory_Click(object sender, EventArgs e)
        {
            CategoryAllForm ca = new CategoryAllForm();
            ca.Show();
        }

        private void pbxUser_Click(object sender, EventArgs e)
        {
            UserAllForm ua = new UserAllForm();
            ua.Show();
        }

        private void pbxProfile_Click(object sender, EventArgs e)
        {
            ProfileAllForm pa = new ProfileAllForm();
            pa.Show();
        }

        private void pbxLog_Click(object sender, EventArgs e)
        {
            LogForm l = new LogForm();
            l.Show();
        }
    }
}
