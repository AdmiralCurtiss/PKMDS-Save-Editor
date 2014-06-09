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
        PKMDS.PCStorage_Pub pcstorage;
        private void frmMain_Load(object sender, EventArgs e)
        {
            txtSaveTrainerName.MaxLength = 8;
            PKMDS.SQL.OpenDB(Properties.Settings.Default.veekunpokedex);
            sav = new PKMDS.Save(@"F:\Google Drive\Home Desktop\Saves\Mike B2 Sav_AbstractTest.sav");
            //this.Text = sav.TrainerName;
            pcstorage = sav.PCStorage;
            numSpeciesID.DataBindings.Add("Value", pcstorage[0][0], "SpeciesID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            pbSprite.DataBindings.Add("Image", pcstorage[0][0], "Sprite", false, DataSourceUpdateMode.OnPropertyChanged, null);
            txtSaveTrainerName.DataBindings.Add("Text", sav, "TrainerName", false, DataSourceUpdateMode.OnPropertyChanged, "");
            this.DataBindings.Add("Text", sav, "TrainerName", false, DataSourceUpdateMode.OnPropertyChanged, "");
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            sav.WriteToFile(@"F:\Google Drive\Home Desktop\Saves\Mike B2 Sav_AbstractTest.sav");
            PKMDS.SQL.CloseDB();
        }
        private void btnTest2_Click(object sender, EventArgs e)
        {
            pcstorage[0][0].SpeciesID = 300;
        }
    }
}
