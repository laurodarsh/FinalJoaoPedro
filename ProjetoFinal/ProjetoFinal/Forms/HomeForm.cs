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
            
           /* if(user.Id !=1)
            {
                pbxLog.Visible = false;
                pbxProfile.Visible = false;
                pbxUser.Visible = false;
            }*/
        }

        private void pbxCategory_MouseEnter(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.White;
        }
        
        private void pbxProfile_MouseLeave(object sender, EventArgs e)
        {
            pbxProfile.BackColor = Color.Transparent;
        }

        private void pbxProfile_MouseEnter(object sender, EventArgs e)
        {
            pbxProfile.BackColor = Color.White;
        }

        private void pbxCategory_MouseLeave(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.Transparent;
        }

        private void pbxLog_MouseEnter(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.White;
         }

        private void pbxLog_MouseLeave(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.Transparent;
        }

        private void pbxProduct_MouseEnter(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.White;
        }

        private void pbxProduct_MouseLeave(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.Transparent;
        }

        private void pbxUser_MouseEnter(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.White;
        }

        private void pbxUser_MouseLeave(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.Transparent;
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
