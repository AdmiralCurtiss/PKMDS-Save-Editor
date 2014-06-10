using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKMDS_CS;
namespace PKMDS_Abstract_Test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        PKMDS.Save sav;
        PKMDS.PCStorage_Pub pcstorage = new PKMDS.PCStorage_Pub();
        PKMDS.Box_Pub currentbox = new PKMDS.Box_Pub();
        frmBoxes BoxesForm = new frmBoxes();
        BindingSource controlsbinding = new BindingSource();
        string filename = @"F:\Google Drive\Home Desktop\Saves\Mike B2 Sav_AbstractTest.sav";
        private void frmMain_Load(object sender, EventArgs e)
        {
            sav = new PKMDS.Save(filename);
            pcstorage = sav.PCStorage;
            currentbox = pcstorage[0];
            controlsbinding.DataSource = currentbox[0];
            numSpeciesID.DataBindings.Add("Value", controlsbinding, "SpeciesID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            pbSprite.DataBindings.Add("Image", controlsbinding, "Sprite", false, DataSourceUpdateMode.OnPropertyChanged, null);
            pbIcon.DataBindings.Add("Image", controlsbinding, "Icon", false, DataSourceUpdateMode.OnPropertyChanged, null);
            numSpeciesID.Minimum = 1;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            sav.WriteToFile(filename);
            PKMDS.SQL.CloseDB();
        }
        private void btnBoxesForm_Click(object sender, EventArgs e)
        {
            BoxesForm.SetPCStorage(pcstorage, 0);
            BoxesForm.ShowDialog();
            controlsbinding.ResetBindings(false);
        }
    }
}
