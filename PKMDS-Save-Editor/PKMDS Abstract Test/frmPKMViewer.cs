using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PKMDS_CS;
namespace PKMDS_Abstract_Test
{
    public partial class frmPKMViewer : Form
    {
        public frmPKMViewer()
        {
            InitializeComponent();
            controlsbinding.DataSource = temppkm;
            numSpecies.DataBindings.Add("Value", controlsbinding, "SpeciesID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            pbSprite.DataBindings.Add("Image", controlsbinding, "Sprite", false, DataSourceUpdateMode.OnPropertyChanged, null);
        }
        private PKMDS.Pokemon pkm;
        private PKMDS.Pokemon temppkm = new PKMDS.Pokemon();
        BindingSource controlsbinding = new BindingSource();
        public void SetPKM(PKMDS.Pokemon pokemon)
        {
            pkm = pokemon;
            temppkm.Data = pkm.Data;
            controlsbinding.ResetBindings(false);
        }
        private void SavePKM() 
        {
            pkm.Data = temppkm.Data;
        }
        private void frmPKMViewer_Load(object sender, EventArgs e)
        {

        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            SavePKM();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePKM();
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
