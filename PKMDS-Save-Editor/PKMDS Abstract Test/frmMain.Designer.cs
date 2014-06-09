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
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeciesID)).BeginInit();
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
            this.numSpeciesID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeciesID.Name = "numSpeciesID";
            this.numSpeciesID.Size = new System.Drawing.Size(100, 20);
            this.numSpeciesID.TabIndex = 1;
            this.numSpeciesID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtSaveTrainerName
            // 
            this.txtSaveTrainerName.Location = new System.Drawing.Point(12, 12);
            this.txtSaveTrainerName.Name = "txtSaveTrainerName";
            this.txtSaveTrainerName.Size = new System.Drawing.Size(100, 20);
            this.txtSaveTrainerName.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtSaveTrainerName);
            this.Controls.Add(this.numSpeciesID);
            this.Controls.Add(this.pbSprite);
            this.Name = "frmMain";
            this.Text = "PKMDS Abstract Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeciesID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.NumericUpDown numSpeciesID;
        private System.Windows.Forms.TextBox txtSaveTrainerName;
    }
}

