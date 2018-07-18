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
    public partial class ProfileDetailsForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string name = "";
        bool active= false;

        public ProfileDetailsForm(int idProfile)
        {
            InitializeComponent();
            lblId.Text = idProfile.ToString(); //-------

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblId.Text))
            {
                try
                {
                    //Conectar
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PROFILE WHERE ID = @id", sqlConnect);
                    //SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY WHERE ID = " + idCategory.ToString(), sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", idProfile));

                    UserProfile profile = new UserProfile(); //------

                    using (SqlDataReader reader = cmd.ExecuteReader()) //-----
                    {
                        while (reader.Read())
                        {
                            profile.Id = Int32.Parse(reader["ID"].ToString());
                            profile.Name = reader["NAME"].ToString();
                            profile.Active = bool.Parse(reader["ACTIVE"].ToString());
                        }
                    }

                    tbxName.Text = profile.Name;
                    cbxActive.Checked = profile.Active;


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
        public ProfileDetailsForm()
        {
            InitializeComponent();
            pbxDelete.Visible = false;
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            ProfileAllForm pa = new ProfileAllForm();
            pa.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
             SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (string.IsNullOrEmpty(lblId.Text)) //-----
            {
                try
                {
                    GetData();

                    //Conectar
                    sqlConnect.Open();
                    string sql = "INSERT INTO USER_PROFILE(NAME, ACTIVE) VALUES (@name, @active)";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@active", active));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Adicionado com sucesso!");
                    Log.SalvarLog("Adicionado Perfil", DateTime.Now);


                }
                catch (Exception ex)
                {
                    //Tratar exceções
                    MessageBox.Show("Erro ao adicionar Perfil!" + ex.Message);
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
                    string sql = "UPDATE USER_PROFILE SET NAME = @name, ACTIVE = @active WHERE ID= @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", this.lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Altereções salvas com sucesso!");
                    Log.SalvarLog("Editado Perfil", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar esta perfil!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();

                    ProfileAllForm pa = new ProfileAllForm();
                    pa.Show();
                    this.Hide();
                }
            }

        }
        void GetData()
            {
           name = tbxName.Text;
            if(cbxActive.Checked){
            active = true;
            }else{
            active = false;
            }
        }
        void CleanData()
            {
            tbxName.Text = "";
            cbxActive.Checked = false;
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text)) //-----
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);


                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE USER_PROFILE SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Perfil inativa!");
                    Log.SalvarLog("Deletado Perfil", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar este Perfil!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
        }
    }
}
