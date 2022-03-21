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

        private void LoadData()
        {
            string result = string.Empty;

            Watch[] watches = this.services.GetAllWatches();
            if (!watches.Any())
            {
                buttonPrev.Enabled = false;
                buttonNext.Enabled = false;
            }
            if (watches.Count()<=3)
            {
                buttonPrev.Enabled = false;
                buttonNext.Enabled = false;
            }
            else if (watches.Count()>3)
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

        private void buttonPrev_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogForm dialogForm = new DialogForm("Ref. Num ");
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
    }
}
