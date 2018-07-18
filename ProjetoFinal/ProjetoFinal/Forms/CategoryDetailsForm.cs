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

            lblId.Text = idCategory.ToString(); //-------

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
            }
        }

        public CategoryDetailsForm()
        {
            InitializeComponent();
            pbxDelete.Visible = false;
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            CategoryAllForm ca = new CategoryAllForm();
            ca.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            GetData();
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            if (string.IsNullOrEmpty(lblId.Text)) //-----
            {
                try
                {
                    //Conectar
                    sqlConnect.Open();
                    string sql = "INSERT INTO CATEGORY(NAME, ACTIVE) VALUES (@name, @active)";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@active", active));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Adicionado com sucesso!");
                    Log.SalvarLog("Adicionado Categoria", DateTime.Now);


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
            else
            {
                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE CATEGORY SET NAME = @name, ACTIVE = @active WHERE ID= @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", this.lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Altereções salvas com sucesso!");
                    Log.SalvarLog("Editado Categoria", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar esta categoria!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();

                    CategoryAllForm ca = new CategoryAllForm();
                    ca.Show();
                    this.Hide();
                }
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
                    string sql = "UPDATE CATEGORY SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", lblId.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("categoria inativa!");
                    Log.SalvarLog("Deletado Categoria", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar esta categoria!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }

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
