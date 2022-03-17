﻿using LuxWatch.Service;
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
            // Трябва да се дебъгне проблем, при който формата с резултати винаги се отваря****
            try
            {
                if (radioButtonBrand.Checked)
                {
                    string brand = comboBoxBrand.Text;
                    string[] allBrands = this.services.GetBrandsName();
                    SearchResultForm searchResultForm = new SearchResultForm(services, brand, 1);
                    if (allBrands.Contains(brand))
                    {
                        searchResultForm.Show();
                    }
                    else
                        searchResultForm.Hide();
                }
                else if (radioButtonRefNum.Checked)
                {
                    string refNum = textBoxRN.Text;
                    SearchResultForm searchResultForm = new SearchResultForm(services, refNum,2);
                    searchResultForm.Show();
                }
                else if (radioButtonMaterial.Checked)
                {
                    string material = comboBoxMaterial.Text;
                    SearchResultForm searchResultForm = new SearchResultForm(services, material, 3);
                    searchResultForm.Show();
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
    }
}
