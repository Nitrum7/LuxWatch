namespace LuxWatch.FormApp
{
    using LuxWatch.Service;
    using Scooters.FormApp;
    using System;
    using System.Windows.Forms;


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
            LoadMaterials();
            LoadCategory();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddWatch();
                MessageBox.Show("Watch successfully added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonRB_Click(object sender, EventArgs e)
        {
            DeleteBrand();
        }
        private void buttonAB_Click(object sender, EventArgs e)
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Enter new brand: ");
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
                DialogForm dialogForm = new DialogForm("Enter new material: ");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    this.services.AddMaterial(dialogForm.Result);
                    MessageBox.Show("Material added successfully");
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonRM_Click(object sender, EventArgs e)
        {
            DeleteMaterial();
        }
        private void LoadBrands()
        {
            comboBoxBrand.Items.Clear();
            comboBoxBrand.Items.AddRange(services.GetBrandsName());
        }
        private void LoadMaterials()
        {
            comboBoxMaterial.Items.Clear();
            comboBoxMaterial.Items.AddRange(services.GetMaterialType());
        }
        private void LoadCategory()
        {
            comboBoxCategory.Items.AddRange(services.GetCategorySex());
        }
        private void AddWatch()
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
        }
        private void DeleteBrand()
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Enter a brand: ");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    this.services.DeleteBrand(dialogForm.Result);
                    MessageBox.Show("Brand deleted successfully");
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
        private void DeleteMaterial()
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Enter a material: ");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    this.services.DeleteMaterial(dialogForm.Result);
                    MessageBox.Show("Material deleted successfully");
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
