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
    public partial class ProductAllForm : Form
    {
        public ProductAllForm()
        {
            InitializeComponent();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            HomeForm h = new HomeForm();
            h.Show();
            this.Hide();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {

        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            ProductDetailsForm pd = new ProductDetailsForm();
            pd.Show();
            this.Hide();
        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {
            ProductDetailsForm pd = new ProductDetailsForm();
            pd.Show();
            this.Hide();
        }
    }
}
