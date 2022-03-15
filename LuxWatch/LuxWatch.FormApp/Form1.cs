using LuxWatch.Service;
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
            this.groupBoxSearchB.Hide();
            this.groupBoxSearchRN.Hide();
            this.groupBoxMaterial.Hide();
            this.SearchButton.Enabled = false;
        }
  
        private void radioButtonBrand_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxSearchRN.Hide();
            this.groupBoxMaterial.Hide();
            this.groupBoxSearchB.Show();
            comboBoxBrand.Items.AddRange(services.GetBrandsName());
            this.SearchButton.Enabled=true;
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
            if (radioButtonBrand.Checked)
            {
                string brand = comboBoxBrand.GetItemText(comboBoxBrand.SelectedIndex);

            }
            else if (radioButtonRefNum.Checked)
            {

            }
            else if (radioButtonMaterial.Checked)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllWatchesForm form = new ShowAllWatchesForm(services);
            form.Show();
            
        }
    }
}
