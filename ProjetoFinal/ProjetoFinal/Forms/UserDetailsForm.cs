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
            pbxDelete.Visible = false;
        }
        public UserDetailsForm(int idUser)
        {
            InitializeComponent();
            lblId.Text = idUser.ToString();

            cmbProfile.DisplayMember = "NAME";
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblId.Text))
            {
                try
                {
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM [USER] WHERE ID = @id", sqlConnect);
                    cmd.Parameters.Add(new SqlParameter("@id", idUser));
                    User user = new User();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Id = Int32.Parse(reader["ID"].ToString());
                            user.Name = reader["NAME"].ToString();
                            user.Active = bool.Parse(reader["ACTIVE"].ToString());
                            user.Password = reader["PASSWORD"].ToString();
                            user.Email = reader["EMAIL"].ToString();
                            user.UserProfile = new UserProfile()
                            {
                                Id = Int32.Parse(reader["FK_USERPROFILE"].ToString())
                            };
                        }
                    }

                    tbxName.Text = user.Name;
                    tbxEmail.Text = user.Email;
                    tbxPass.Text = user.Password;
                    cbxActive.Checked = user.Active;
                    int indexCombo = 0;
                    if (user.UserProfile != null)
                    {
                        indexCombo = user.UserProfile.Id;
                    }
                    InitializeComboBox(cmbProfile, indexCombo);


                }
                catch (Exception EX)
                {
                    //Tratar exce??es
                    throw;
                }
                finally
                {
                    //Fechar
                    sqlConnect.Close();
                }
            }

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
            if (string.IsNullOrEmpty(lblId.Text))
            {
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
                    Log.SalvarLog("Adicionado Usuário", DateTime.Now);


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
            else {
                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE [USER] SET NAME = @name,PASSWORD =@password,EMAIL = @email, ACTIVE = @active, FK_USERPROFILE = @userprofile WHERE ID= @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", this.lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@password", this.tbxPass.Text));
                    cmd.Parameters.Add(new SqlParameter("@email", this.tbxEmail.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));
                    cmd.Parameters.Add(new SqlParameter("@userprofile", ((UserProfile)cmbProfile.SelectedItem).Id));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Altereções salvas com sucesso!");
                    Log.SalvarLog("Editado usuário", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar esta categoria!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();

                    UserAllForm ua = new UserAllForm();
                    ua.Show();
                    this.Hide();
                }
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

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text)) //-----
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);


                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE [USER] SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuário inativo!");
                    Log.SalvarLog("Deletado Usuário", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar este usuário!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }

        }
        private void InitializeComboBox(ComboBox cbxProduct, int indexCombo)
        {
            cbxProduct.Items.Add("Selecione.. ");
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                //Conectar
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PROFILE", sqlConnect);

                using (SqlDataReader reader = cmd.ExecuteReader()) //-----
                {
                    while (reader.Read())
                    {
                        UserProfile up = new UserProfile(reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()), Int32.Parse(reader["ID"].ToString()));
                        cmbProfile.Items.Add(up);
                    }
                }

                cmbProfile.SelectedItem = cmbProfile.Items[indexCombo];
            }
            catch (Exception EX)
            {
                MessageBox.Show("erro de acesso ao banco de dados. " + EX.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void tbxPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
