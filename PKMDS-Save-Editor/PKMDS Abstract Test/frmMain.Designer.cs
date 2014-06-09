namespace PKMDS_Abstract_Test
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.numSpeciesID = new System.Windows.Forms.NumericUpDown();
            this.txtSaveTrainerName = new System.Windows.Forms.TextBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.btnBoxesForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeciesID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSprite
            // 
            this.pbSprite.Location = new System.Drawing.Point(12, 64);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(100, 100);
            this.pbSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSprite.TabIndex = 1;
            this.pbSprite.TabStop = false;
            // 
            // numSpeciesID
            // 
            this.numSpeciesID.Location = new System.Drawing.Point(12, 38);
            this.numSpeciesID.Maximum = new decimal(new int[] {
            649,
            0,
            0,
            0});
            this.numSpeciesID.Name = "numSpeciesID";
            this.numSpeciesID.Size = new System.Drawing.Size(100, 20);
            this.numSpeciesID.TabIndex = 1;
            // 
            // txtSaveTrainerName
            // 
            this.txtSaveTrainerName.Location = new System.Drawing.Point(12, 12);
            this.txtSaveTrainerName.Name = "txtSaveTrainerName";
            this.txtSaveTrainerName.Size = new System.Drawing.Size(100, 20);
            this.txtSaveTrainerName.TabIndex = 0;
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(118, 64);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIcon.TabIndex = 2;
            this.pbIcon.TabStop = false;
            // 
            // dgData
            // 
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Location = new System.Drawing.Point(12, 170);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(575, 371);
            this.dgData.TabIndex = 3;
            // 
            // btnBoxesForm
            // 
            this.btnBoxesForm.Location = new System.Drawing.Point(350, 34);
            this.btnBoxesForm.Name = "btnBoxesForm";
            this.btnBoxesForm.Size = new System.Drawing.Size(75, 23);
            this.btnBoxesForm.TabIndex = 4;
            this.btnBoxesForm.Text = "Boxes Form";
            this.btnBoxesForm.UseVisualStyleBackColor = true;
            this.btnBoxesForm.Click += new System.EventHandler(this.btnBoxesForm_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 553);
            this.Controls.Add(this.btnBoxesForm);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.txtSaveTrainerName);
            this.Controls.Add(this.numSpeciesID);
            this.Controls.Add(this.pbSprite);
            this.Name = "frmMain";
            this.Text = "PKMDS Abstract Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeciesID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.NumericUpDown numSpeciesID;
        private System.Windows.Forms.TextBox txtSaveTrainerName;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Button btnBoxesForm;
    }
}

