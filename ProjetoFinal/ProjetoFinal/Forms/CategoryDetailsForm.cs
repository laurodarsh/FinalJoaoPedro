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
    public partial class CategoryDetailsForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string name;
        bool active;
        public CategoryDetailsForm(int idCategory)
        {
            InitializeComponent();

           /* lbl.Text = idUser.ToString(); //-------

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblId.Text))
            {
                try
                {
                    //Conectar
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY WHERE ID = @id", sqlConnect);
                    cmd.Parameters.Add(new SqlParameter("@id", idCategory));

                    Category category = new Category(); //------

                    using (SqlDataReader reader = cmd.ExecuteReader()) //-----
                    {
                        while (reader.Read())
                        {
                            category.Id = Int32.Parse(reader["ID"].ToString());
                            category.Name = reader["NAME"].ToString();
                            category.Active = bool.Parse(reader["ACTIVE"].ToString());

                            //user.UserProfile = new UserProfile
                            //{
                            //Id = Int32.Parse(reader["FK_USER_PROFILE"].ToString())
                            //};

                        }
                    }

                    tbxName.Text = category.Name;
                    cbxActive.Checked = category.Active;


                    //Busca o index baseado no Select
                    //int indexCombo = 0;
                    //if (user.UserProfile != null)
                    //{
                    //  indexCombo = user.UserProfile.Id;
                    //}

                    //Inicializa o dropDown com as informações do banco
                    //InitializeComboBox(cbxProfile, indexCombo);

                }
                catch (Exception EX)
                {
                    //Tratar exceções
                    throw;
                }
                finally
                {
                    //Fechar
                    sqlConnect.Close();
                }
            }*/
        }

        public CategoryDetailsForm()
        {
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            CategoryAllForm ca = new CategoryAllForm();
            ca.Show();
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
                string sql = "INSERT INTO CATEGORY(NAME, ACTIVE) VALUES (@name, @active)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@active", active));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso!");


            }
            catch (Exception ex)
            {
                //Tratar exceções
                MessageBox.Show("Erro ao adicionar categoria!" + ex.Message);
                CleanData();
            }
            finally
            {
                //Fechar
                sqlConnect.Close();
                CleanData();
            }
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {

        }
       void GetData()
        {
           name = tbxName.Text;
            if (cbxActive.Checked) {
                active = true;
            }else
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
