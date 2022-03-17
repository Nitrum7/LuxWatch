using LuxWatch.Model;
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
    public partial class SearchResultForm : Form
    {
        private int currentPage = 1;
        private int totalPage = 0;
        private readonly Services services;
        private readonly string input;
        private readonly int method;
        public SearchResultForm(Services services, string input, int method)
        {
            InitializeComponent();
            this.services = services;
            this.input = input;
            this.method = method;
        }

        private void SearchResultForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox1.Enabled = false;

                string result = string.Empty;
                if (method==1)
                {
                    result=String.Empty;
                    ICollection<Watch> watches = this.services.GetWatchesByBrand(input).ToArray();
                    foreach (var item in watches)
                    {
                        result += this.services.PrintWatchForm(item);
                    }
                }
                else if (method==2)
                {
                    buttonNext.Enabled = false;
                    buttonPrev.Enabled = false;
                    buttonNext.Hide();
                    buttonPrev.Hide();
                    result = String.Empty;
                    Watch watch = this.services.GetWatch(input);
                    result+=this.services.PrintWatchForm(watch);
                }
                else if (method==3)
                {
                    result = String.Empty;
                    ICollection<Watch> watches = this.services.GetWatchesByMaterial(input).ToArray();
                    foreach (var item in watches)
                    {
                        result += this.services.PrintWatchForm(item);
                    }
                }
                
                this.richTextBox1.Text = result;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (method==1)
            {
                int watchC = this.services.WatchCountByBrand(input);
                totalPage = (int)Math.Ceiling((double)watchC / 2);
                if ((currentPage - 1) < 1 || currentPage > totalPage)
                {
                    currentPage = totalPage;
                }
                else
                {
                    currentPage--;
                }
                ICollection<Watch> watches = this.services.GetWatchesByBrand(input, currentPage);
                string result = string.Empty;

                foreach (var item in watches)
                {
                    result += this.services.PrintWatchForm(item);
                }
                richTextBox1.Text = result;
            }
            else if (method==3)
            {
                int watchC = this.services.WatchCountByMaterial(input);
                totalPage = (int)Math.Ceiling((double)watchC / 2);
                if ((currentPage - 1) < 1 || currentPage > totalPage)
                {
                    currentPage = totalPage;
                }
                else
                {
                    currentPage--;
                }
                ICollection<Watch> watches = this.services.GetWatchesByMaterial(input, currentPage);
                string result = string.Empty;

                foreach (var item in watches)
                {
                    result += this.services.PrintWatchForm(item);
                }
                richTextBox1.Text = result;
            }
            
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (method == 1)
            {
                int watchC = this.services.WatchCountByBrand(input);
                totalPage = (int)Math.Ceiling((double)watchC / 2);
                if ((currentPage + 1) > totalPage || currentPage > totalPage)
                {
                    currentPage = 1;
                }
                else
                {
                    currentPage++;
                }
                ICollection<Watch> watches = this.services.GetWatchesByBrand(input, currentPage);
                string result = string.Empty;

                foreach (var item in watches)
                {
                    result += this.services.PrintWatchForm(item);
                }
                richTextBox1.Text = result;
            }
            else if (method == 3)
            {
                int watchC = this.services.WatchCountByMaterial(input);
                totalPage = (int)Math.Ceiling((double)watchC / 2);
                if ((currentPage + 1) > totalPage || currentPage > totalPage)
                {
                    currentPage = 1;
                }
                else
                {
                    currentPage++;
                }
                ICollection<Watch> watches = this.services.GetWatchesByMaterial(input, currentPage);
                string result = string.Empty;

                foreach (var item in watches)
                {
                    result += this.services.PrintWatchForm(item);
                }
                richTextBox1.Text = result;
            }
        }
    }
}
