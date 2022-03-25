namespace LuxWatch.FormApp
{
    using LuxWatch.Model;
    using LuxWatch.Service;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Catalogue : Form
    {
        private Services services;
        public Catalogue()
        {
            InitializeComponent();
            services = new Services();
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {
            FormStartupSetter();
        }
        private void radioButtonBrand_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxSearchRN.Hide();
            this.groupBoxMaterial.Hide();
            this.groupBoxSearchB.Show();
            comboBoxBrand.Items.AddRange(services.GetBrandsName());
            this.SearchButton.Enabled = true;
        }

        private void radioButtonRefNum_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxSearchB.Hide();
            this.groupBoxMaterial.Hide();
            this.groupBoxSearchRN.Show();
            this.SearchButton.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxSearchRN.Hide();
            this.groupBoxSearchB.Hide();
            this.groupBoxMaterial.Show();
            comboBoxMaterial.Items.AddRange(services.GetMaterialType());
            this.SearchButton.Enabled = true;
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonBrand.Checked)
                {
                    string brand = comboBoxBrand.Text;
                    Watch[] allBrands = this.services.GetWatchesByBrand(brand).ToArray();
                    SearchResultForm searchResultForm = new SearchResultForm(services, brand, 1);
                    if (allBrands.Any())
                    {
                        searchResultForm.Show();
                    }
                    else
                        searchResultForm.Hide();
                }
                else if (radioButtonRefNum.Checked)
                {
                    string refNum = textBoxRN.Text;
                    Watch watchByRN = this.services.GetWatch(refNum);
                    SearchResultForm searchResultForm = new SearchResultForm(services, refNum, 2);
                    if (watchByRN != null)
                    {
                        searchResultForm.Show();
                    }
                    else
                        searchResultForm.Hide();
                }
                else if (radioButtonMaterial.Checked)
                {
                    string material = comboBoxMaterial.Text;
                    Watch[] allMaterial = this.services.GetWatchesByMaterial(material).ToArray();
                    SearchResultForm searchResultForm = new SearchResultForm(services, material, 3);
                    if (allMaterial.Any())
                    {
                        searchResultForm.Show();
                    }
                    else
                        searchResultForm.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllWatchesForm form = new ShowAllWatchesForm(services);
            form.Show();

        }
        private void FormStartupSetter()
        {
            this.groupBoxSearchB.Hide();
            this.groupBoxSearchRN.Hide();
            this.groupBoxMaterial.Hide();
            this.SearchButton.Enabled = false;
        }
    }
}
