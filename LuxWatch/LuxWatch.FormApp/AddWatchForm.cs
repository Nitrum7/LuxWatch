using LuxWatch.Model;
using LuxWatch.Service;
using Scooters.FormApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuxWatch.FormApp
{
    public partial class AddWatchForm : Form
    {
        private readonly Services services;
        public AddWatchForm(Services services)
        {
            InitializeComponent();
            this.services = services;
        }

        private void AddWatchForm_Load(object sender, EventArgs e)
        {
            LoadBrands();
            LoadMaterial();
            comboBoxCategory.Items.AddRange(services.GetCategorySex());
        }

        


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string refNum = textBoxRefNum.Text;
                string brand = comboBoxBrand.Text;
                string model = textBoxModel.Text;
                string material = comboBoxMaterial.Text;
                string category = comboBoxCategory.Text;
                string size = textBoxSize.Text;
                string year = textBoxYear.Text;
                string price = textBoxPrice.Text;
                this.services.AddWatch(refNum, brand, model, material, category, size, year, price);
                MessageBox.Show("Watch Successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void labelRefNum_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAB_Click(object sender, EventArgs e)
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Enter new Brand: ");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    this.services.AddBrand(dialogForm.Result);
                    MessageBox.Show("Brand added successfully");
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadBrands();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        

        private void buttonAM_Click(object sender, EventArgs e)
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Enter new Material: ");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    this.services.AddMaterial(dialogForm.Result);
                    MessageBox.Show("Material added successfully");
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadMaterial();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void LoadBrands()
        {
            comboBoxBrand.Items.Clear();
            comboBoxBrand.Items.AddRange(services.GetBrandsName());
        }
        private void LoadMaterial()
        {
            comboBoxMaterial.Items.Clear(); 
            comboBoxMaterial.Items.AddRange(services.GetMaterialType());
        }
    }
}
