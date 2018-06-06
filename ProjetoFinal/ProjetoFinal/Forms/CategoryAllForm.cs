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
    public partial class CategoryAllForm : Form
    {
        public CategoryAllForm()
        {
            InitializeComponent();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            HomeForm hf = new HomeForm();
            hf.Show();
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CategoryDetailsForm cd = new CategoryDetailsForm();
            cd.Show();
            this.Hide();
        }
    }
}
