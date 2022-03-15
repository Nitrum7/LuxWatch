namespace LuxWatch.FormApp
{
    partial class Catalogue
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchButton = new System.Windows.Forms.Button();
            this.radioButtonBrand = new System.Windows.Forms.RadioButton();
            this.radioButtonRefNum = new System.Windows.Forms.RadioButton();
            this.groupBoxSearchB = new System.Windows.Forms.GroupBox();
            this.labelSearchBr = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.groupBoxSearchRN = new System.Windows.Forms.GroupBox();
            this.labelRefN = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonMaterial = new System.Windows.Forms.RadioButton();
            this.groupBoxMaterial = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxSearchB.SuspendLayout();
            this.groupBoxSearchRN.SuspendLayout();
            this.groupBoxMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchButton.Location = new System.Drawing.Point(12, 432);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(444, 27);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // radioButtonBrand
            // 
            this.radioButtonBrand.AutoSize = true;
            this.radioButtonBrand.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonBrand.Location = new System.Drawing.Point(32, 21);
            this.radioButtonBrand.Name = "radioButtonBrand";
            this.radioButtonBrand.Size = new System.Drawing.Size(132, 21);
            this.radioButtonBrand.TabIndex = 2;
            this.radioButtonBrand.TabStop = true;
            this.radioButtonBrand.Text = "Search by Brand";
            this.radioButtonBrand.UseVisualStyleBackColor = true;
            this.radioButtonBrand.CheckedChanged += new System.EventHandler(this.radioButtonBrand_CheckedChanged);
            // 
            // radioButtonRefNum
            // 
            this.radioButtonRefNum.AutoSize = true;
            this.radioButtonRefNum.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonRefNum.Location = new System.Drawing.Point(32, 139);
            this.radioButtonRefNum.Name = "radioButtonRefNum";
            this.radioButtonRefNum.Size = new System.Drawing.Size(214, 21);
            this.radioButtonRefNum.TabIndex = 3;
            this.radioButtonRefNum.TabStop = true;
            this.radioButtonRefNum.Text = "Search by Reference number";
            this.radioButtonRefNum.UseVisualStyleBackColor = true;
            this.radioButtonRefNum.CheckedChanged += new System.EventHandler(this.radioButtonRefNum_CheckedChanged);
            // 
            // groupBoxSearchB
            // 
            this.groupBoxSearchB.Controls.Add(this.labelSearchBr);
            this.groupBoxSearchB.Controls.Add(this.comboBoxBrand);
            this.groupBoxSearchB.Location = new System.Drawing.Point(32, 48);
            this.groupBoxSearchB.Name = "groupBoxSearchB";
            this.groupBoxSearchB.Size = new System.Drawing.Size(424, 85);
            this.groupBoxSearchB.TabIndex = 4;
            this.groupBoxSearchB.TabStop = false;
            // 
            // labelSearchBr
            // 
            this.labelSearchBr.AutoSize = true;
            this.labelSearchBr.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSearchBr.Location = new System.Drawing.Point(6, 38);
            this.labelSearchBr.Name = "labelSearchBr";
            this.labelSearchBr.Size = new System.Drawing.Size(49, 17);
            this.labelSearchBr.TabIndex = 1;
            this.labelSearchBr.Text = "Brand:";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(59, 35);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(337, 23);
            this.comboBoxBrand.TabIndex = 0;
            // 
            // groupBoxSearchRN
            // 
            this.groupBoxSearchRN.Controls.Add(this.labelRefN);
            this.groupBoxSearchRN.Controls.Add(this.textBox1);
            this.groupBoxSearchRN.Location = new System.Drawing.Point(32, 166);
            this.groupBoxSearchRN.Name = "groupBoxSearchRN";
            this.groupBoxSearchRN.Size = new System.Drawing.Size(424, 90);
            this.groupBoxSearchRN.TabIndex = 5;
            this.groupBoxSearchRN.TabStop = false;
            // 
            // labelRefN
            // 
            this.labelRefN.AutoSize = true;
            this.labelRefN.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRefN.Location = new System.Drawing.Point(6, 45);
            this.labelRefN.Name = "labelRefN";
            this.labelRefN.Size = new System.Drawing.Size(89, 17);
            this.labelRefN.TabIndex = 1;
            this.labelRefN.Text = "Ref. Number:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 23);
            this.textBox1.TabIndex = 0;
            // 
            // radioButtonMaterial
            // 
            this.radioButtonMaterial.AutoSize = true;
            this.radioButtonMaterial.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonMaterial.Location = new System.Drawing.Point(32, 262);
            this.radioButtonMaterial.Name = "radioButtonMaterial";
            this.radioButtonMaterial.Size = new System.Drawing.Size(146, 21);
            this.radioButtonMaterial.TabIndex = 6;
            this.radioButtonMaterial.TabStop = true;
            this.radioButtonMaterial.Text = "Search by Material";
            this.radioButtonMaterial.UseVisualStyleBackColor = true;
            this.radioButtonMaterial.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBoxMaterial
            // 
            this.groupBoxMaterial.Controls.Add(this.label1);
            this.groupBoxMaterial.Controls.Add(this.comboBoxMaterial);
            this.groupBoxMaterial.Location = new System.Drawing.Point(32, 289);
            this.groupBoxMaterial.Name = "groupBoxMaterial";
            this.groupBoxMaterial.Size = new System.Drawing.Size(424, 85);
            this.groupBoxMaterial.TabIndex = 7;
            this.groupBoxMaterial.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material:";
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(72, 35);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(324, 23);
            this.comboBoxMaterial.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(12, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(444, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Show All Watches";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Catalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 473);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxMaterial);
            this.Controls.Add(this.radioButtonMaterial);
            this.Controls.Add(this.groupBoxSearchRN);
            this.Controls.Add(this.groupBoxSearchB);
            this.Controls.Add(this.radioButtonRefNum);
            this.Controls.Add(this.radioButtonBrand);
            this.Controls.Add(this.SearchButton);
            this.Name = "Catalogue";
            this.Text = "Catalogue";
            this.Load += new System.EventHandler(this.Catalogue_Load);
            this.groupBoxSearchB.ResumeLayout(false);
            this.groupBoxSearchB.PerformLayout();
            this.groupBoxSearchRN.ResumeLayout(false);
            this.groupBoxSearchRN.PerformLayout();
            this.groupBoxMaterial.ResumeLayout(false);
            this.groupBoxMaterial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.RadioButton radioButtonBrand;
        private System.Windows.Forms.RadioButton radioButtonRefNum;
        private System.Windows.Forms.GroupBox groupBoxSearchB;
        private System.Windows.Forms.Label labelSearchBr;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.GroupBox groupBoxSearchRN;
        private System.Windows.Forms.Label labelRefN;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonMaterial;
        private System.Windows.Forms.GroupBox groupBoxMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Button button1;
    }
}
