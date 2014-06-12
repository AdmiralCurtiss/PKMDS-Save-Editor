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
        PKMDS.Pokemon nullpkm = new PKMDS.Pokemon();
        public void SetSave(PKMDS.Save save)
        {
            this.sav = save;
            this.party = this.sav.Party;
            this.pcstorage = this.sav.PCStorage;
            this.boxnames = this.sav.BoxNames;
            this.boxwallpapers = this.sav.BoxWallpapers;
            this.currentbox = this.pcstorage[this.sav.CurrentBox];
            if (partyPics[0].DataBindings.Count > 0)
            {
                partyslotsbinding[0].ResetBindings(false);
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    partyslotsbinding.Add(new BindingSource());
                    partyslotsbinding[i].DataSource = this.party[i].PokemonData;
                    partyPics[i].DataBindings.Add("Image", partyslotsbinding[i], "Icon", true, DataSourceUpdateMode.Never, null);
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (boxPics[i].DataBindings.Count > 0)
                {
                    boxslotsbinding[i].ResetBindings(false);
                }
                else
                {
                    boxslotsbinding.Add(new BindingSource());
                    boxslotsbinding[i].DataSource = currentbox[i];
                    boxPics[i].DataBindings.Add("Image", boxslotsbinding[i], "Icon", true, DataSourceUpdateMode.Never, null);
                }
            }
            if (boxGridPics[0].DataBindings.Count > 0)
            {
                for (int i = 0; i < 24; i++)
                {
                    boxgridsbinding[i].ResetBindings(false);
                    boxnamesbinding[i].ResetBindings(false);
                }
            }
            else
            {
                for (int i = 0; i < 24; i++)
                {
                    boxgridsbinding.Add(new BindingSource());
                    boxgridsbinding[i].DataSource = pcstorage;
                    boxgridsbinding[i].Position += i;
                    boxGridPics[i].DataBindings.Add("Image", boxgridsbinding[i], "Grid", true, DataSourceUpdateMode.Never, null);
                    boxnamesbinding.Add(new BindingSource());
                    boxnamesbinding[i].DataSource = boxnames;
                    boxnamesbinding[i].Position += i;
                    boxNameLabels[i].DataBindings.Add("Text", boxnamesbinding[i], "Name", false, DataSourceUpdateMode.Never, "");
                }
            }
            if (!(txtBoxName.DataBindings.Count > 0))
            {
                txtBoxName.DataBindings.Add("Text", boxnamebinding, "Name", false, DataSourceUpdateMode.OnPropertyChanged, "");
            }
            if (!(pnlBox.DataBindings.Count > 0))
            {
                pnlBox.DataBindings.Add("BackgroundImage", boxwallpaperbinding, "Wallpaper", true, DataSourceUpdateMode.Never, null);
            }
            UpdateBoxNameTextbox();
            UpdateBoxWallpaper();
            splitMain.Enabled =
            splitMain.Panel2.Enabled =
            btnNextBox.Enabled =
            btnPreviousBox.Enabled =
            txtBoxName.Enabled = true;
            btnNextBox.Enabled = (sav.CurrentBox != 23);
            btnPreviousBox.Enabled = (sav.CurrentBox != 0);
        }
        private void UpdateBoxNameTextbox()
        {
            boxnamebinding.DataSource = boxnames[this.sav.CurrentBox];
            boxnamebinding.ResetBindings(false);
        }
        private void UpdateBoxWallpaper()
        {
            boxwallpaperbinding.DataSource = boxwallpapers[this.sav.CurrentBox];
            boxwallpaperbinding.ResetBindings(false);
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
        }
        private List<PictureBox> partyPics = new List<PictureBox>();
        private List<PictureBox> boxPics = new List<PictureBox>();
        private List<PictureBox> boxGridPics = new List<PictureBox>();
        private List<Label> boxNameLabels = new List<Label>();
        private List<Label> boxcountLabels = new List<Label>();
        private List<Panel> boxPanels = new List<Panel>();
        frmPKMViewer pkmview = new frmPKMViewer();
        PKMDS.Save sav;
        PKMDS.Party party = new PKMDS.Party();
        PKMDS.PCStorage pcstorage = new PKMDS.PCStorage();
        PKMDS.Box currentbox = new PKMDS.Box();
        PKMDS.BoxNames boxnames = new PKMDS.BoxNames();
        PKMDS.BoxWallpapers boxwallpapers = new PKMDS.BoxWallpapers();
        List<BindingSource> partyslotsbinding = new List<BindingSource>();
        List<BindingSource> boxslotsbinding = new List<BindingSource>();
        List<BindingSource> boxgridsbinding = new List<BindingSource>();
        List<BindingSource> boxnamesbinding = new List<BindingSource>();
        BindingSource boxnamebinding = new BindingSource();
        BindingSource boxwallpaperbinding = new BindingSource();
        Color SelectionColor = Color.FromArgb(100, Color.Orange.R, Color.Orange.G, Color.Orange.B);
        private void txtBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxName.DataBindings[0].WriteValue();
                txtBoxName.SelectAll();
            }
        }
        private void pbBoxSlot_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)(sender);
            int slot = 0;
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            PKMDS.Pokemon pkm = currentbox[slot];
            if (pkm.SpeciesID != 0)
            {
                pkmview.SetPKM(pkm);
                pkmview.ShowDialog();
                boxslotsbinding[slot].ResetBindings(false);
                boxgridsbinding[this.sav.CurrentBox].ResetBindings(false);
            }
        }
        private void pbPartySlot_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)(sender);
            int slot = 0;
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            PKMDS.PartyPokemon ppkm = party[slot];
            if (ppkm.PokemonData.SpeciesID != 0)
            {
                pkmview.SetPKM(ppkm);
                pkmview.ShowDialog();
                party.RecalculateParty();
                partyslotsbinding[slot].ResetBindings(false);
            }
        }
        private void btnPreviousBox_Click(object sender, EventArgs e)
        {
            if (sav.CurrentBox > 0)
            {
                this.sav.CurrentBox--;
                UpdateBox();
            }
        }
        private void btnNextBox_Click(object sender, EventArgs e)
        {
            if (sav.CurrentBox < 23)
            {
                this.sav.CurrentBox++;
                UpdateBox();
            }
        }
        private void UpdateBox()
        {
            this.currentbox = this.pcstorage[this.sav.CurrentBox];
            for (int i = 0; i < 30; i++)
            {
                boxslotsbinding[i].ResetBindings(false);
                boxslotsbinding[i].DataSource = currentbox[i];
            }
            boxnamebinding.DataSource = boxnames[this.sav.CurrentBox];
            boxnamebinding.ResetBindings(false);
            boxwallpaperbinding.DataSource = boxwallpapers[this.sav.CurrentBox];
            boxwallpaperbinding.ResetBindings(false);
            btnNextBox.Enabled = (sav.CurrentBox != 23);
            btnPreviousBox.Enabled = (sav.CurrentBox != 0);
            splitMain.Panel2.ScrollControlIntoView(boxNameLabels[sav.CurrentBox]);
            splitMain.Panel2.ScrollControlIntoView(boxGridPics[sav.CurrentBox]);
        }
        private void lblBoxNamepbBoxGrid_Click(object sender, EventArgs e)
        {
            Control pb = (Control)(sender);
            byte slot = 0;
            byte.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            this.sav.CurrentBox = slot;
            UpdateBox();
        }
        private void splitMain_Panel2_MouseEnter(object sender, EventArgs e)
        {
            this.splitMain.Panel2.Focus();
        }
        private void lblBoxNamepbBoxGrid_MouseEnter(object sender, EventArgs e)
        {
            int box = 0;
            Control pb = (Control)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;
            boxPanels[box].BackColor = SelectionColor;
            this.splitMain.Panel2.Focus();
        }
        private void lblBoxNamepbBoxGrid_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void lblBoxNamepbBoxGrid_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void lblBoxNamepbBoxGrid_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void lblBoxNamepbBoxGrid_MouseLeave(object sender, EventArgs e)
        {
            int box = 0;
            Control pb = (Control)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;
            boxPanels[box].BackColor = Color.Transparent;
        }
        private void frmBoxes_Shown(object sender, EventArgs e)
        {
            splitMain.Panel2.ScrollControlIntoView(boxNameLabels[sav.CurrentBox]);
            splitMain.Panel2.ScrollControlIntoView(boxGridPics[sav.CurrentBox]);
        }
        private void pbPartySlot_MouseEnter(object sender, EventArgs e)
        {
            int slot = 0;
            Control pb = (Control)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            partyPics[slot].BackColor = SelectionColor;
            PreviewPokemon(party[slot].PokemonData);
        }
        private void pbPartySlot_MouseLeave(object sender, EventArgs e)
        {
            int slot = 0;
            Control pb = (Control)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            partyPics[slot].BackColor = Color.Transparent;
            ClearPreview();
        }
        private void pbPartySlot_MouseDown(object sender, MouseEventArgs e)
        {
            int box = 0;
            PictureBox pb = (PictureBox)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;

        }
        private void pbPartySlot_DragEnter(object sender, DragEventArgs e)
        {
            int box = 0;
            PictureBox pb = (PictureBox)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;

        }
        private void pbPartySlot_DragDrop(object sender, DragEventArgs e)
        {
            int box = 0;
            PictureBox pb = (PictureBox)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;

        }
        private void pbBoxSlot_DragEnter(object sender, DragEventArgs e)
        {
            int box = 0;
            PictureBox pb = (PictureBox)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;

        }
        private void pbBoxSlot_DragDrop(object sender, DragEventArgs e)
        {
            int box = 0;
            PictureBox pb = (PictureBox)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;

        }
        private void pbBoxSlot_MouseDown(object sender, MouseEventArgs e)
        {
            int box = 0;
            PictureBox pb = (PictureBox)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out box);
            box--;

        }
        private void pbBoxSlot_MouseEnter(object sender, EventArgs e)
        {
            int slot = 0;
            Control pb = (Control)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            boxPics[slot].BackColor = SelectionColor;
            PreviewPokemon(currentbox[slot]);
        }
        private void pbBoxSlot_MouseLeave(object sender, EventArgs e)
        {
            int slot = 0;
            Control pb = (Control)(sender);
            int.TryParse(pb.Name.Substring(pb.Name.Length - 2, 2), out slot);
            slot--;
            boxPics[slot].BackColor = Color.Transparent;
            ClearPreview();
        }
        private void PreviewPokemon(PKMDS.Pokemon pkm)
        {
            if (pkm.SpeciesID != 0)
            {
                pbSprite.Image = pkm.Sprite;
                pbGender.Image = pkm.GenderIcon;
                pbHeldItem.Image = pkm.ItemPic;
                pbBall.Image = pkm.BallPic;
                pbShiny.Image = pkm.ShinyIcon;
                lblHeldItem.Text = PKMDS.GetItemName(pkm.ItemID);
                lblNickname.Text = pkm.Nickname;
                lblLevel.Text = "Level " + pkm.Level.ToString("");
            }
        }
        private void ClearPreview()
        {
            pbSprite.Image = null;
            pbGender.Image = null;
            pbHeldItem.Image = null;
            pbBall.Image = null;
            pbShiny.Image = null;
            lblNickname.Text = "";
            lblLevel.Text = "";
            lblHeldItem.Text = "";
        }
    }
}
