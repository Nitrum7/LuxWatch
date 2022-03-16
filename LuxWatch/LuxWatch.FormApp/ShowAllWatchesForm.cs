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
            string result = string.Empty;
            
            Watch[] watches = this.services.GetAllWatches(); 
            foreach (var item in watches)
            {
               result +=  this.services.PrintWatchForm(item);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string[] res = new string[8];
            try
            {
                DialogForm dialogFormRN = new DialogForm("Enter ref. number ");
                if (dialogFormRN.ShowDialog() == DialogResult.OK)
                {
                    res[0] = dialogFormRN.Result;
                    dialogFormRN.Close();
                    DialogForm dialogFormB = new DialogForm("Enter brand ");
                    if (dialogFormB.ShowDialog() == DialogResult.OK)
                    {
                        res[1] = dialogFormB.Result;
                        dialogFormB.Close();
                        DialogForm dialogFormM = new DialogForm("Enter model ");
                        if (dialogFormM.ShowDialog() == DialogResult.OK)
                        {
                            res[2] = dialogFormM.Result;
                            dialogFormM.Close();
                            DialogForm dialogFormMat = new DialogForm("Enter material ");
                            if (dialogFormMat.ShowDialog() == DialogResult.OK)
                            {
                                res[3] = dialogFormMat.Result;
                                dialogFormM.Close();
                                DialogForm dialogFormC = new DialogForm("Enter category ");
                                if (dialogFormC.ShowDialog() == DialogResult.OK)
                                {
                                    res[4] = dialogFormC.Result;
                                    dialogFormC.Close();
                                    DialogForm dialogFormS = new DialogForm("Enter size ");
                                    if (dialogFormS.ShowDialog() == DialogResult.OK)
                                    {
                                        res[5] = dialogFormS.Result;
                                        dialogFormS.Close();
                                        DialogForm dialogFormY = new DialogForm("Enter year ");
                                        if (dialogFormY.ShowDialog() == DialogResult.OK)
                                        {
                                            res[6] = dialogFormY.Result;
                                            dialogFormY.Close();
                                            DialogForm dialogFormP = new DialogForm("Enter price ");
                                            if (dialogFormP.ShowDialog() == DialogResult.OK)
                                            {
                                                res[7] = dialogFormP.Result;
                                                this.services.AddWatch(res[0], res[1], res[2], res[3], res[4], res[5], res[6], res[7]);
                                                MessageBox.Show("Watch successfully added");
                                                dialogFormP.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You closed the dialog!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
