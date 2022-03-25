namespace LuxWatch.FormApp
{
    using LuxWatch.Model;
    using LuxWatch.Service;
    using Scooters.FormApp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;


    public partial class ShowAllWatchesForm : Form
    {
        private int currentPage = 1;
        private int totalPage = 0;
        private readonly Services services;

        public ShowAllWatchesForm(Services services)
        {
            InitializeComponent();
            this.services = services;
        }

        private void ShowAllWatchesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            PageDown();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            PageUp();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Ref. number ");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    this.services.DeleteWatch(dialogForm.Result);
                    MessageBox.Show("Watch deleted successfully");
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddWatchForm addWatchForm = new AddWatchForm(services);
                addWatchForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonUP_Click(object sender, EventArgs e)
        {
            UpdatePrice();
        }
        private void buttonUS_Click(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateSize()
        {
            try
            {
                DialogForm dialogRefNum = new DialogForm("Ref. number ");
                if (dialogRefNum.ShowDialog() == DialogResult.OK)
                {
                    string refNum = dialogRefNum.Result;
                    dialogRefNum.Close();
                    DialogForm dialogSize = new DialogForm("New size: ");
                    if (dialogSize.ShowDialog() == DialogResult.OK)
                    {
                        string size = dialogSize.Result;
                        this.services.UpdateWatchSize(refNum, size);
                    }
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadData()
        {
            string result = string.Empty;

            Watch[] watches = this.services.GetAllWatches();
            if (!watches.Any())
            {
                buttonPrev.Enabled = false;
                buttonNext.Enabled = false;
            }
            if (watches.Count() <= 3)
            {
                buttonPrev.Enabled = false;
                buttonNext.Enabled = false;
            }
            else if (watches.Count() > 3)
            {
                buttonPrev.Enabled = true;
                buttonNext.Enabled = true;
            }
            foreach (var item in watches)
            {
                result += this.services.PrintWatchForm(item);
            }
            this.richTextBox1.Text = result;
            this.richTextBox1.Enabled = false;
        }
        private void PageUp()
        {
            int watchC = this.services.WatchCount();
            totalPage = (int)Math.Ceiling((double)watchC / 3);
            if ((currentPage + 1) > totalPage || currentPage > totalPage)
            {
                currentPage = 1;
            }
            else
            {
                currentPage++;
            }
            ICollection<Watch> watches = this.services.GetWatches(currentPage);
            string result = string.Empty;

            foreach (var item in watches)
            {
                result += this.services.PrintWatchForm(item);
            }
            richTextBox1.Text = result;
        }
        private void PageDown()
        {
            int watchC = this.services.WatchCount();
            totalPage = (int)Math.Ceiling((double)watchC / 3);
            if ((currentPage - 1) < 1 || currentPage > totalPage)
            {
                currentPage = totalPage;
            }
            else
            {
                currentPage--;
            }
            ICollection<Watch> watches = this.services.GetWatches(currentPage);
            string result = string.Empty;

            foreach (var item in watches)
            {
                result += this.services.PrintWatchForm(item);
            }
            richTextBox1.Text = result;
        }
        private void UpdatePrice()
        {
            try
            {
                DialogForm dialogRefNum = new DialogForm("Ref. number ");
                if (dialogRefNum.ShowDialog() == DialogResult.OK)
                {
                    string refNum = dialogRefNum.Result;
                    dialogRefNum.Close();
                    DialogForm dialogPrice = new DialogForm("New price: ");
                    if (dialogPrice.ShowDialog()==DialogResult.OK)
                    {
                        string price = dialogPrice.Result;
                        this.services.UpdateWatchPrice(refNum, price);
                    }
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
