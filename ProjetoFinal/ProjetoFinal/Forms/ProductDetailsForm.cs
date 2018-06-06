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
    public partial class ProductDetailsForm : Form
    {
        string connectionString = "workstation id=StockControl.mssql.somee.com;packet size = 4096; user id = luacademy_SQLLogin_1; pwd=msctq6gvt3;data source = StockControl.mssql.somee.com; persist security info=False;initial catalog = StockControl";
        string name ="";
        string category="";
        float price = 0;
        bool active = false;
        public ProductDetailsForm()
        {
            InitializeComponent();
            cmbCategory.Items.Add("Selecionar Produto");
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            try
            {
                GetData();
                sqlConnect.Open();
                string sql = "INSERT INTO PRODUCT(NAME, ACTIVE, PRICE) VALUES (@name, @active, @price)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@active", active));
                cmd.Parameters.Add(new SqlParameter("@price", price));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso!");
                CleanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar categoria!" + ex.Message);
                CleanData();
            }
            finally
            {
                sqlConnect.Close();
            }
            }
        void GetData()
        {
            name = tbxName.Text;
            price = float.Parse(tbxPrice.Text);
            category = cmbCategory.Text;

            if (cbxActive.Checked)
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
            tbxPrice.Text = "";
            cbxActive.Checked = false;
            cmbCategory.SelectedIndex = 0;
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            ProfileAllForm pa = new ProfileAllForm();
            pa.Show();
            this.Hide();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProductAllForm pa = new ProductAllForm();
            pa.Show();
            this.Hide();
        }
    }
}
