﻿using ProjetoFinal.Classes;
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
    public partial class CategoryAllForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        public CategoryAllForm()
        {
            InitializeComponent();
            ShowData();
            ResizeDataGridView();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            CategoryDetailsForm cd = new CategoryDetailsForm();
            cd.Show();
            this.Hide();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            int idCategory = Int32.Parse(dgvCategory.SelectedRows[0].Cells[0].Value.ToString());

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();
                string sql = "UPDATE PRODUCT SET ACTIVE = @active WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@id", idCategory));
                cmd.Parameters.Add(new SqlParameter("@active", false));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Categoria inativo!");
                Log.SalvarLog("Categoria desativada","Deleção", DateTime.Now);
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erro ao desativar este categoria!" + "\n\n" + Ex.Message);
                throw;
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           int idCategory = Int32.Parse(dgvCategory.SelectedRows[0].Cells[0].Value.ToString());

            CategoryDetailsForm categoryDetails = new CategoryDetailsForm(idCategory);
            categoryDetails.Show();

            this.Close();
        }
        private void ShowData()
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", sqlConnect);
                // SqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);
                dgvCategory.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar. " + ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
        }
        private void ResizeDataGridView()
        {
            dgvCategory.Columns["ID"].Visible = false;
            dgvCategory.Columns["NAME"].HeaderText = "Nome";
            dgvCategory.Columns["ACTIVE"].HeaderText = "Ativo";

            foreach (DataGridViewColumn col in dgvCategory.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
                string optionForm = "CategoryForm";
                string optionString = "name";

                Search search = new Search();
                dgvCategory.DataSource = search.SearchFilter(connectionString, tbxSearch.Text, optionString, optionForm);

            btnCleanSearch.Visible = true;
            if (tbxSearch.Text == "") {
                ShowData();
                ResizeDataGridView();
                btnCleanSearch.Visible = false;
            }
            tbxSearch.Text = "";
                
        }

        private void btnCleanSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            ResizeDataGridView();
            btnCleanSearch.Visible = false;
        }
    }
}
