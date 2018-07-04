using ProjetoFinal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class UserDetailsForm : Form
    {
        string name;
        string password;
        string confirmpassword;
        string email;
        bool active;
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        List<UserProfile> profiles = new List<UserProfile>();
   
        public UserDetailsForm()
        {
            InitializeComponent();
            cmbProfile.Items.Add("Selecionar o Perfil:");
            cmbProfile.DisplayMember = "NAME";
            LoadComboBox();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            UserAllForm ua = new UserAllForm();
            ua.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            try
            {
                GetData();

                //Conectar
                sqlConnect.Open();
                string sql = "INSERT INTO [USER](NAME,PASSWORD, EMAIL, ACTIVE, FK_USERPROFILE) VALUES (@name,@password,@email, @active,@userprofile)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@active", active));
                cmd.Parameters.Add(new SqlParameter("@userprofile", ((UserProfile)cmbProfile.SelectedItem).Id));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso!");


            }
            catch (Exception ex)
            {
                //Tratar exceções
                MessageBox.Show("Erro ao adicionar usuário!" + ex.Message);
                CleanData();
            }
            finally
            {
                //Fechar
                sqlConnect.Close();
            }

        }
        void GetData()
        {
            name = tbxName.Text;
            password = tbxPass.Text;
            confirmpassword = tbxPassConfirm.Text;
            email = tbxEmail.Text;
            if(cbxActive.Checked)
            {
                active = true;
            }else
            {
                active = false;
            }
        }
        void CleanData()
        {
            tbxPassConfirm.Text = "";
            tbxPass.Text = "";
            tbxName.Text = "";
            tbxEmail.Text = "";
            cbxActive.Checked = false;
        }
        void LoadComboBox()
        {
            SqlConnection cn = new SqlConnection(connectionString);

            try
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USER_PROFILE", cn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                   UserProfile up = new UserProfile(reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()), Int32.Parse(reader["ID"].ToString()));
                    profiles.Add(up);
                }
            }
            catch (Exception ex)
            {
                //Erro ao carregar banco
            }
            finally
            {
                cn.Close();
            }
            foreach (UserProfile up in profiles)
            {
                cmbProfile.Items.Add(up);
            }
        }
    }
}
