using ProjetoFinal.Classes;
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
    public partial class LoginForm : Form
    {
        string name = "";
        string password = "";
        User userAux;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            GetData();
            if (CheckLogin(password, name))
            {
                HomeForm hf = new HomeForm(userAux);
                hf.Show();
                this.Hide();
            }
            else
            {
                CleanData();
                MessageBox.Show("Usuário ou senha incorretos!");
            }

        }
        private bool CheckLogin(string password, string name)
        {
            User user = UserHelper.SelectByName(name);

            if (user != null)
            {
                if (UserHelper.Hash(password) == user.Password)
                {
                    userAux = user;
                    return true;
                }
            }
            return false;
        }
        void GetData()
        {
            name = tbxLogin.Text;
            password = tbxPass.Text;
        }
        void CleanData()
        {
            tbxPass.Text = "";
            tbxLogin.Text = "";
        }
    }
}
