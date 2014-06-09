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
    public partial class frmBoxes : Form
    {
        public void SetPCStorage(PKMDS.PCStorage_Pub pc, int boxnum)
        {
            this.pcstorage = pc;
            this.currentbox = pc[boxnum];
            for (int i = 0; i < 30; i++)
            {
                controlsbinding.Add(new BindingSource());
                controlsbinding[i].DataSource = currentbox[i];
                if (boxPics[i].DataBindings.Count > 0)
                {
                    controlsbinding[i].ResetBindings(false);
                }
                else
                {
                    boxPics[i].DataBindings.Add("Image", controlsbinding[i], "Icon", false, DataSourceUpdateMode.OnPropertyChanged, null);
                }
            }
        }
        public frmBoxes()
        {
            InitializeComponent();
            partyPics.Add(pbPartySlot01);
            partyPics.Add(pbPartySlot02);
            partyPics.Add(pbPartySlot03);
            partyPics.Add(pbPartySlot04);
            partyPics.Add(pbPartySlot05);
            partyPics.Add(pbPartySlot06);
            boxPics.Add(pbBoxSlot01);
            boxPics.Add(pbBoxSlot02);
            boxPics.Add(pbBoxSlot03);
            boxPics.Add(pbBoxSlot04);
            boxPics.Add(pbBoxSlot05);
            boxPics.Add(pbBoxSlot06);
            boxPics.Add(pbBoxSlot07);
            boxPics.Add(pbBoxSlot08);
            boxPics.Add(pbBoxSlot09);
            boxPics.Add(pbBoxSlot10);
            boxPics.Add(pbBoxSlot11);
            boxPics.Add(pbBoxSlot12);
            boxPics.Add(pbBoxSlot13);
            boxPics.Add(pbBoxSlot14);
            boxPics.Add(pbBoxSlot15);
            boxPics.Add(pbBoxSlot16);
            boxPics.Add(pbBoxSlot17);
            boxPics.Add(pbBoxSlot18);
            boxPics.Add(pbBoxSlot19);
            boxPics.Add(pbBoxSlot20);
            boxPics.Add(pbBoxSlot21);
            boxPics.Add(pbBoxSlot22);
            boxPics.Add(pbBoxSlot23);
            boxPics.Add(pbBoxSlot24);
            boxPics.Add(pbBoxSlot25);
            boxPics.Add(pbBoxSlot26);
            boxPics.Add(pbBoxSlot27);
            boxPics.Add(pbBoxSlot28);
            boxPics.Add(pbBoxSlot29);
            boxPics.Add(pbBoxSlot30);
            boxGridPics.Add(pbBoxGrid01);
            boxGridPics.Add(pbBoxGrid02);
            boxGridPics.Add(pbBoxGrid03);
            boxGridPics.Add(pbBoxGrid04);
            boxGridPics.Add(pbBoxGrid05);
            boxGridPics.Add(pbBoxGrid06);
            boxGridPics.Add(pbBoxGrid07);
            boxGridPics.Add(pbBoxGrid08);
            boxGridPics.Add(pbBoxGrid09);
            boxGridPics.Add(pbBoxGrid10);
            boxGridPics.Add(pbBoxGrid11);
            boxGridPics.Add(pbBoxGrid12);
            boxGridPics.Add(pbBoxGrid13);
            boxGridPics.Add(pbBoxGrid14);
            boxGridPics.Add(pbBoxGrid15);
            boxGridPics.Add(pbBoxGrid16);
            boxGridPics.Add(pbBoxGrid17);
            boxGridPics.Add(pbBoxGrid18);
            boxGridPics.Add(pbBoxGrid19);
            boxGridPics.Add(pbBoxGrid20);
            boxGridPics.Add(pbBoxGrid21);
            boxGridPics.Add(pbBoxGrid22);
            boxGridPics.Add(pbBoxGrid23);
            boxGridPics.Add(pbBoxGrid24);
            boxNameLabels.Add(lblBoxGrid01);
            boxNameLabels.Add(lblBoxGrid02);
            boxNameLabels.Add(lblBoxGrid03);
            boxNameLabels.Add(lblBoxGrid04);
            boxNameLabels.Add(lblBoxGrid05);
            boxNameLabels.Add(lblBoxGrid06);
            boxNameLabels.Add(lblBoxGrid07);
            boxNameLabels.Add(lblBoxGrid08);
            boxNameLabels.Add(lblBoxGrid09);
            boxNameLabels.Add(lblBoxGrid10);
            boxNameLabels.Add(lblBoxGrid11);
            boxNameLabels.Add(lblBoxGrid12);
            boxNameLabels.Add(lblBoxGrid13);
            boxNameLabels.Add(lblBoxGrid14);
            boxNameLabels.Add(lblBoxGrid15);
            boxNameLabels.Add(lblBoxGrid16);
            boxNameLabels.Add(lblBoxGrid17);
            boxNameLabels.Add(lblBoxGrid18);
            boxNameLabels.Add(lblBoxGrid19);
            boxNameLabels.Add(lblBoxGrid20);
            boxNameLabels.Add(lblBoxGrid21);
            boxNameLabels.Add(lblBoxGrid22);
            boxNameLabels.Add(lblBoxGrid23);
            boxNameLabels.Add(lblBoxGrid24);
            boxcountLabels.Add(lblBoxCount01);
            boxcountLabels.Add(lblBoxCount02);
            boxcountLabels.Add(lblBoxCount03);
            boxcountLabels.Add(lblBoxCount04);
            boxcountLabels.Add(lblBoxCount05);
            boxcountLabels.Add(lblBoxCount06);
            boxcountLabels.Add(lblBoxCount07);
            boxcountLabels.Add(lblBoxCount08);
            boxcountLabels.Add(lblBoxCount09);
            boxcountLabels.Add(lblBoxCount10);
            boxcountLabels.Add(lblBoxCount11);
            boxcountLabels.Add(lblBoxCount12);
            boxcountLabels.Add(lblBoxCount13);
            boxcountLabels.Add(lblBoxCount14);
            boxcountLabels.Add(lblBoxCount15);
            boxcountLabels.Add(lblBoxCount16);
            boxcountLabels.Add(lblBoxCount17);
            boxcountLabels.Add(lblBoxCount18);
            boxcountLabels.Add(lblBoxCount19);
            boxcountLabels.Add(lblBoxCount20);
            boxcountLabels.Add(lblBoxCount21);
            boxcountLabels.Add(lblBoxCount22);
            boxcountLabels.Add(lblBoxCount23);
            boxcountLabels.Add(lblBoxCount24);
            boxPanels.Add(pnlBoxGrid01);
            boxPanels.Add(pnlBoxGrid02);
            boxPanels.Add(pnlBoxGrid03);
            boxPanels.Add(pnlBoxGrid04);
            boxPanels.Add(pnlBoxGrid05);
            boxPanels.Add(pnlBoxGrid06);
            boxPanels.Add(pnlBoxGrid07);
            boxPanels.Add(pnlBoxGrid08);
            boxPanels.Add(pnlBoxGrid09);
            boxPanels.Add(pnlBoxGrid10);
            boxPanels.Add(pnlBoxGrid11);
            boxPanels.Add(pnlBoxGrid12);
            boxPanels.Add(pnlBoxGrid13);
            boxPanels.Add(pnlBoxGrid14);
            boxPanels.Add(pnlBoxGrid15);
            boxPanels.Add(pnlBoxGrid16);
            boxPanels.Add(pnlBoxGrid17);
            boxPanels.Add(pnlBoxGrid18);
            boxPanels.Add(pnlBoxGrid19);
            boxPanels.Add(pnlBoxGrid20);
            boxPanels.Add(pnlBoxGrid21);
            boxPanels.Add(pnlBoxGrid22);
            boxPanels.Add(pnlBoxGrid23);
            boxPanels.Add(pnlBoxGrid24);
            foreach (PictureBox pb in partyPics)
            {
                ((Control)pb).AllowDrop = true;
            }
            foreach (PictureBox pb in boxPics)
            {
                ((Control)pb).AllowDrop = true;
            }
            foreach (PictureBox pb in boxGridPics)
            {
                ((Control)pb).AllowDrop = true;
            }
            splitMain.Enabled = true;
        }
        private List<PictureBox> partyPics = new List<PictureBox>();
        private List<PictureBox> boxPics = new List<PictureBox>();
        private List<PictureBox> boxGridPics = new List<PictureBox>();
        private List<Label> boxNameLabels = new List<Label>();
        private List<Label> boxcountLabels = new List<Label>();
        private List<Panel> boxPanels = new List<Panel>();
        frmPKMViewer pkmview = new frmPKMViewer();
        PKMDS.PCStorage_Pub pcstorage = new PKMDS.PCStorage_Pub();
        PKMDS.Box_Pub currentbox = new PKMDS.Box_Pub();
        List<BindingSource> controlsbinding = new List<BindingSource>();
        private void pbBoxSlot01_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)(sender);
            int slot = 0;
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            pkmview.SetPKM(currentbox[slot]);
            pkmview.ShowDialog();
            controlsbinding[slot].ResetBindings(false);
        }
    }
}
