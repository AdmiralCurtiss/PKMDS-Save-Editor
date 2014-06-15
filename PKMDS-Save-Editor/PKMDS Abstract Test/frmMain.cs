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
        PKMDS.PCStorage pcstorage = new PKMDS.PCStorage();
        PKMDS.Box currentbox = new PKMDS.Box();
        PKMDS.Party party = new PKMDS.Party();
        frmBoxes BoxesForm = new frmBoxes();
        BindingSource controlsbinding = new BindingSource();
        string filename = "Test-Save-White-2.sav";
        private void frmMain_Load(object sender, EventArgs e)
        {
            sav = new PKMDS.Save(filename);
            pcstorage = sav.PCStorage;
            currentbox = pcstorage[0];
            party = sav.Party;
            controlsbinding.DataSource = currentbox[0];
            numSpeciesID.DataBindings.Add("Value", controlsbinding, "SpeciesID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            pbSprite.DataBindings.Add("Image", controlsbinding, "Sprite", true, DataSourceUpdateMode.Never, null);
            pbIcon.DataBindings.Add("Image", controlsbinding, "Icon", true, DataSourceUpdateMode.Never, null);
            numSpeciesID.Minimum = 1;

            //PKMDS.SQL.OpenDB(Properties.Settings.Default.veekunpokedex);

            //party.Select(myClass => party[0].PokemonData);
            //dgData.DataSource = party.Select(t => t.PokemonData).ToList();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            sav.WriteToFile(filename);
            PKMDS.SQL.CloseDB();
        }
        private void btnBoxesForm_Click(object sender, EventArgs e)
        {
            BoxesForm.SetSave(sav);
            BoxesForm.ShowDialog();
            controlsbinding.ResetBindings(false);
        }
    }
}
