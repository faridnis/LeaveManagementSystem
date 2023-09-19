using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveManagementSystem
{
    public partial class CategoriesForm : Form
    {
        Functions Con;
        public CategoriesForm()
        {
            
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "SELECT * FROM CategoryTb";
            CategoriesList.DataSource = Con.GetData(Query);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveCategories_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCatName.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    string Category = txtCatName.Text;
                    string Query = "INSERT INTO CategoryTb VALUES('{0}')";
                    Query = string.Format(Query, Category);
                    Con.SetData(Query);
                    ShowCategories();
                    txtCatName.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
