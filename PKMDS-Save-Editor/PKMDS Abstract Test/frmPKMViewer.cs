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
        private PKMDS.Pokemon pkm;
        private PKMDS.Pokemon temppkm = new PKMDS.Pokemon();
        BindingSource controlsbinding = new BindingSource();
        BindingSource formsbindingsource = new BindingSource();
        Binding nicknamedbinding;
        Binding diamondbinding;
        Binding squarebinding;
        Binding trianglebinding;
        Binding circlebinding;
        Binding heartbinding;
        Binding starbinding;
        Binding formbinding;
        bool uiset = false;
        public frmPKMViewer()
        {
            InitializeComponent();
            PKMDS.SQL.OpenDB(Properties.Settings.Default.veekunpokedex);
            if (!uiset)
            {
                SetUI();
            }
            controlsbinding.DataSource = temppkm;
            formsbindingsource.DataSource = temppkm;
            numSpecies.DataBindings.Add("Value", controlsbinding, "SpeciesID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            pbSprite.DataBindings.Add("Image", controlsbinding, "Sprite", true, DataSourceUpdateMode.Never, null);
            pbBall.DataBindings.Add("Image", controlsbinding, "BallPic", true, DataSourceUpdateMode.Never, null);
            cbSpecies.DataBindings.Add("SelectedValue", controlsbinding, "SpeciesID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            cbHeldItem.DataBindings.Add("SelectedValue", controlsbinding, "ItemID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            lblHeldItemFlavor.DataBindings.Add("Text", controlsbinding, "ItemFlavor", false, DataSourceUpdateMode.Never, "");
            pbHeldItem.DataBindings.Add("Image", controlsbinding, "ItemPic", true, DataSourceUpdateMode.Never, null);
            numTID.DataBindings.Add("Value", controlsbinding, "TID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            numSID.DataBindings.Add("Value", controlsbinding, "SID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            pbGender.DataBindings.Add("Image", controlsbinding, "GenderIcon", true, DataSourceUpdateMode.Never, null);
            pbType1.DataBindings.Add("Image", controlsbinding, "TypePic1", true, DataSourceUpdateMode.Never, null);
            pbType2.DataBindings.Add("Image", controlsbinding, "TypePic2", true, DataSourceUpdateMode.Never, null);
            cbBall.DataBindings.Add("SelectedValue", controlsbinding, "BallID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            pbShiny.DataBindings.Add("Image", controlsbinding, "ShinyIcon", true, DataSourceUpdateMode.Never, null);
            pbPokerus.DataBindings.Add("Image", controlsbinding, "PokerusIcon", true, DataSourceUpdateMode.Never, null);
            chkNicknamed.DataBindings.Add("Checked", controlsbinding, "IsNicknamed", false, DataSourceUpdateMode.OnPropertyChanged, false);
            nicknamedbinding = txtNickname.DataBindings.Add("Text", controlsbinding, "Nickname", true, DataSourceUpdateMode.OnValidation, "");
            nicknamedbinding.Parse += new ConvertEventHandler(SetNicknamedFlag);
            diamondbinding = pbDiamond.DataBindings.Add("Image", controlsbinding, "Diamond", true, DataSourceUpdateMode.Never, PKMDS.GetMarkingImage(PKMDS.Markings.Diamond, false));
            squarebinding = pbSquare.DataBindings.Add("Image", controlsbinding, "Square", true, DataSourceUpdateMode.Never, PKMDS.GetMarkingImage(PKMDS.Markings.Square, false));
            starbinding = pbStar.DataBindings.Add("Image", controlsbinding, "Star", true, DataSourceUpdateMode.Never, PKMDS.GetMarkingImage(PKMDS.Markings.Star, false));
            trianglebinding = pbTriangle.DataBindings.Add("Image", controlsbinding, "Triangle", true, DataSourceUpdateMode.Never, PKMDS.GetMarkingImage(PKMDS.Markings.Triangle, false));
            circlebinding = pbCircle.DataBindings.Add("Image", controlsbinding, "Circle", true, DataSourceUpdateMode.Never, PKMDS.GetMarkingImage(PKMDS.Markings.Circle, false));
            heartbinding = pbHeart.DataBindings.Add("Image", controlsbinding, "Heart", true, DataSourceUpdateMode.Never, PKMDS.GetMarkingImage(PKMDS.Markings.Heart, false));
            diamondbinding.Format += new ConvertEventHandler(SetMarkingImage);
            squarebinding.Format += new ConvertEventHandler(SetMarkingImage);
            starbinding.Format += new ConvertEventHandler(SetMarkingImage);
            trianglebinding.Format += new ConvertEventHandler(SetMarkingImage);
            circlebinding.Format += new ConvertEventHandler(SetMarkingImage);
            heartbinding.Format += new ConvertEventHandler(SetMarkingImage);
            formbinding = cbForm.DataBindings.Add("SelectedIndex", formsbindingsource, "FormID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            formbinding.Format += new ConvertEventHandler(FormConvert);

            /*
numLevel.DataBindings.Add();
txtNickname.DataBindings.Add();
gbOTInfo.DataBindings.Add();
lblSID.DataBindings.Add();
numSID.DataBindings.Add();
lblTID.DataBindings.Add();
numTID.DataBindings.Add();
rbOTFemale.DataBindings.Add();
rbOTMale.DataBindings.Add();
txtOTName.DataBindings.Add();
lblOTName.DataBindings.Add();
lblTNL.DataBindings.Add();
lblEXP.DataBindings.Add();
numEXP.DataBindings.Add();
cbAbility.DataBindings.Add();
lblAbility.DataBindings.Add();
pbTNL.DataBindings.Add();
lblAbilityFlavor.DataBindings.Add();
gbCalcStats.DataBindings.Add();
gbEVs.DataBindings.Add();
gbIVs.DataBindings.Add();
lblTotalEVs.DataBindings.Add();
lblCharacteristic.DataBindings.Add();
numTameness.DataBindings.Add();
lblNature.DataBindings.Add();
cbNature.DataBindings.Add();
cbMove1.DataBindings.Add();
lblMaxPP.DataBindings.Add();
lblPP.DataBindings.Add();
lblPPUps.DataBindings.Add();
lblAccuracy.DataBindings.Add();
lblPower.DataBindings.Add();
numMove1PP.DataBindings.Add();
numMove1PPUps.DataBindings.Add();
txtTNL.DataBindings.Add();
txtMinHatchSteps.DataBindings.Add();
txtMove1MaxPP.DataBindings.Add();
tlMoves.DataBindings.Add();
tlMoveLabels.DataBindings.Add();
tlMove1.DataBindings.Add();
tlMove1Data.DataBindings.Add();
lblMove1Accuracy.DataBindings.Add();
lblMove1Power.DataBindings.Add();
tlMove1MoreData.DataBindings.Add();
pbMove1Type.DataBindings.Add();
lblMove1Flavor.DataBindings.Add();
pbMove1Category.DataBindings.Add();
tlMove4.DataBindings.Add();
tlMove4Data.DataBindings.Add();
lblMove4Accuracy.DataBindings.Add();
cbMove4.DataBindings.Add();
txtMove4MaxPP.DataBindings.Add();
numMove4PP.DataBindings.Add();
numMove4PPUps.DataBindings.Add();
lblMove4Power.DataBindings.Add();
tlMove4MoreData.DataBindings.Add();
pbMove4Category.DataBindings.Add();
pbMove4Type.DataBindings.Add();
lblMove4Flavor.DataBindings.Add();
tlMove2.DataBindings.Add();
tlMove2Data.DataBindings.Add();
lblMove2Accuracy.DataBindings.Add();
cbMove2.DataBindings.Add();
txtMove2MaxPP.DataBindings.Add();
numMove2PP.DataBindings.Add();
numMove2PPUps.DataBindings.Add();
lblMove2Power.DataBindings.Add();
tlMove2MoreData.DataBindings.Add();
pbMove2Category.DataBindings.Add();
pbMove2Type.DataBindings.Add();
lblMove2Flavor.DataBindings.Add();
tlMove3.DataBindings.Add();
tlMove3Data.DataBindings.Add();
lblMove3Accuracy.DataBindings.Add();
cbMove3.DataBindings.Add();
txtMove3MaxPP.DataBindings.Add();
numMove3PP.DataBindings.Add();
numMove3PPUps.DataBindings.Add();
lblMove3Power.DataBindings.Add();
tlMove3MoreData.DataBindings.Add();
pbMove3Category.DataBindings.Add();
pbMove3Type.DataBindings.Add();
lblMove3Flavor.DataBindings.Add();
tlIVs.DataBindings.Add();
tlTotalEVs.DataBindings.Add();
tableLayoutPanel3.DataBindings.Add();
txtTotalEVs.DataBindings.Add();
tlEVs.DataBindings.Add();
tlCalcStats.DataBindings.Add();
lblHPStats.DataBindings.Add();
lblAtkStats.DataBindings.Add();
lblDefStats.DataBindings.Add();
lblSpAtkStats.DataBindings.Add();
lblSpDefStats.DataBindings.Add();
lblSpeedStats.DataBindings.Add();
numHPIV.DataBindings.Add();
txtTNLPercent.DataBindings.Add();
numSpeedEV.DataBindings.Add();
numSpDefEV.DataBindings.Add();
numSpAtkEV.DataBindings.Add();
numDefEV.DataBindings.Add();
numAtkEV.DataBindings.Add();
numHPEV.DataBindings.Add();
numSpeedIV.DataBindings.Add();
numSpDefIV.DataBindings.Add();
numSpAtkIV.DataBindings.Add();
numDefIV.DataBindings.Add();
numAtkIV.DataBindings.Add();
txtCalcSpeed.DataBindings.Add();
txtCalcSpDef.DataBindings.Add();
txtCalcSpAtk.DataBindings.Add();
txtCalcDef.DataBindings.Add();
txtCalcAtk.DataBindings.Add();
txtCalcHP.DataBindings.Add();
gbMet.DataBindings.Add();
tlMet.DataBindings.Add();
gbEggMet.DataBindings.Add();
tlEggMet.DataBindings.Add();
cbEggLocation.DataBindings.Add();
cbMetLocation.DataBindings.Add();
dtEggDate.DataBindings.Add();
dtMetDate.DataBindings.Add();
cbMetAsEgg.DataBindings.Add();
lblMetLevel.DataBindings.Add();
numMetLevel.DataBindings.Add();
cbCountry.DataBindings.Add();
lblCountry.DataBindings.Add();
cbGame.DataBindings.Add();
lblGame.DataBindings.Add();
cbIsEgg.DataBindings.Add();
cbFateful.DataBindings.Add();
cbNsPokemon.DataBindings.Add();
gbPKRS.DataBindings.Add();
lblPKRSStrain.DataBindings.Add();
lblPKRSDays.DataBindings.Add();
cbPKRSStrain.DataBindings.Add();
cbPKRSDays.DataBindings.Add();
lblForm.DataBindings.Add();
             */
            // TODO: finish data bindings
        }
        private void FormConvert(object bindingsource, ConvertEventArgs e)
        {
            UInt16 speciesid = temppkm.SpeciesID;
            if ((cbForm.Items.Count == 0) || !(
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Unown)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Castform)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Deoxys)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Burmy)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Wormadam)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Cherrim)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Shellos)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Gastrodon)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Rotom)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Giratina)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Shaymin)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Basculin)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Darmanitan)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Deerling)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Sawsbuck)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Tornadus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Thundurus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Landorus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Kyurem)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Keldeo)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Meloetta)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Arceus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Genesect))
                ))
            {
                e.Value = -1;
            }
            if (Convert.ToInt32(e.Value) > cbForm.Items.Count)
            {
                temppkm.FormID = Convert.ToByte(cbForm.Items.Count - 1);
                controlsbinding.ResetBindings(false);
            }
        }
        private void SetNicknamedFlag(object bindingsource, ConvertEventArgs e)
        {
            Binding bs = (Binding)(bindingsource);
            BindingSource binding = (BindingSource)(bs.DataSource);
            PKMDS.Pokemon pkm = (PKMDS.Pokemon)(binding.DataSource);
            pkm.IsNicknamed = true;
        }
        private void SetMarkingImage(object bindingsource, ConvertEventArgs e)
        {
            Binding bs = (Binding)(bindingsource);
            switch (bs.BindingMemberInfo.BindingMember)
            {
                case "Diamond":
                    e.Value = PKMDS.GetMarkingImage(PKMDS.Markings.Diamond, (bool)e.Value);
                    break;
                case "Heart":
                    e.Value = PKMDS.GetMarkingImage(PKMDS.Markings.Heart, (bool)e.Value);
                    break;
                case "Star":
                    e.Value = PKMDS.GetMarkingImage(PKMDS.Markings.Star, (bool)e.Value);
                    break;
                case "Circle":
                    e.Value = PKMDS.GetMarkingImage(PKMDS.Markings.Circle, (bool)e.Value);
                    break;
                case "Triangle":
                    e.Value = PKMDS.GetMarkingImage(PKMDS.Markings.Triangle, (bool)e.Value);
                    break;
                case "Square":
                    e.Value = PKMDS.GetMarkingImage(PKMDS.Markings.Square, (bool)e.Value);
                    break;
            }
        }
        private void SetUI()
        {
            SetItems();
            SetAbilities();
            SetSpecies();
            SetBalls();
            SetNatures();
            SetLocations();
            SetMoves();
            SetHometowns();
            SetCountries();
            uiset = true;
        }
        private void SetForms()
        {
            cbForm.Items.Clear();
            cbForm.Text = "";
            UInt16 speciesid = temppkm.SpeciesID;
            if ((speciesid != 0) && (
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Unown)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Castform)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Deoxys)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Burmy)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Wormadam)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Cherrim)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Shellos)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Gastrodon)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Rotom)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Giratina)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Shaymin)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Basculin)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Darmanitan)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Deerling)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Sawsbuck)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Tornadus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Thundurus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Landorus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Kyurem)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Keldeo)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Meloetta)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Arceus)) ||
                (speciesid == (UInt16)(PKMDS.PKMSpecies.Genesect))
                ))
            {
                string[] formnames = PKMDS.GetPKMFormNames(temppkm.SpeciesID);
                if (formnames.Length != 0)
                {
                    if (!((formnames.Length == 1) && (formnames[0] == "")))
                    {
                        cbForm.Items.AddRange(PKMDS.GetPKMFormNames(temppkm.SpeciesID));
                        cbForm.Enabled = true;
                        formsbindingsource.ResetBindings(false);
                    }
                    else
                    {
                        cbForm.Enabled = false;
                    }
                }
                else
                {
                    cbForm.Enabled = false;
                }
            }
            else
            {
                cbForm.Enabled = false;
            }
        }
        private void SetItems()
        {
            List<PKMDS.Item> items = new List<PKMDS.Item>();
            PKMDS.Item item = new PKMDS.Item(0);
            items.Add(item);
            for (UInt16 itemindex = 0; itemindex <= 0x027E; itemindex++)
            {
                item = new PKMDS.Item(itemindex);
                if ((item.ItemName != "") & (item.ItemName != null))
                {
                    items.Add(item);
                }
            }
            cbHeldItem.DataSource = items;
            cbHeldItem.DisplayMember = "ItemName";
            cbHeldItem.ValueMember = "ItemID";
        }
        private void SetAbilities()
        {
            List<PKMDS.Ability> abilities = new List<PKMDS.Ability>();
            PKMDS.Ability ability = new PKMDS.Ability();
            for (UInt16 abilityindex = 0; abilityindex <= 164; abilityindex++)
            {
                ability = new PKMDS.Ability(abilityindex);
                if ((ability.AbilityName != "") & (ability.AbilityName != null) & (ability.AbilityID != 0))
                {
                    abilities.Add(ability);
                }
            }
            cbAbility.DataSource = abilities;
            cbAbility.DisplayMember = "AbilityName";
            cbAbility.ValueMember = "AbilityID";
        }
        private void SetSpecies()
        {
            List<PKMDS.Species> species_l = new List<PKMDS.Species>();
            PKMDS.Species species = new PKMDS.Species();
            for (UInt16 speciesindex = 0; speciesindex <= 649; speciesindex++)
            {
                species = new PKMDS.Species(speciesindex);
                if ((species.SpeciesName != "") & (species.SpeciesName != null) & (species.SpeciesID != 0))
                {
                    species_l.Add(species);
                }
            }
            cbSpecies.DataSource = species_l;
            cbSpecies.DisplayMember = "SpeciesName";
            cbSpecies.ValueMember = "SpeciesID";
        }
        private void SetBalls()
        {
            List<PKMDS.Ball> balls = new List<PKMDS.Ball>();
            PKMDS.Ball ball = new PKMDS.Ball();
            for (Byte ballindex = 0; ballindex <= 25; ballindex++)
            {
                ball = new PKMDS.Ball(ballindex);
                if ((ball.BallName != "") & (ball.BallName != null))
                {
                    balls.Add(ball);
                }
            }
            cbBall.DataSource = balls;
            cbBall.DisplayMember = "BallName";
            cbBall.ValueMember = "BallID";
        }
        private void SetNatures()
        {
            List<PKMDS.Nature> natures = new List<PKMDS.Nature>();
            PKMDS.Nature nature = new PKMDS.Nature();
            for (Byte natureindex = 0; natureindex <= 24; natureindex++)
            {
                nature = new PKMDS.Nature(natureindex);
                if ((nature.NatureName != "") & (nature.NatureName != null))
                {
                    natures.Add(nature);
                }
            }
            cbNature.DataSource = natures;
            cbNature.DisplayMember = "NatureName";
            cbNature.ValueMember = "NatureID";
        }
        private void SetLocations()
        {
            List<PKMDS.Location> metlocations = new List<PKMDS.Location>();
            List<PKMDS.Location> egglocations = new List<PKMDS.Location>();
            PKMDS.Location location = new PKMDS.Location();
            for (UInt16 locationindex = 0; locationindex <= 153; locationindex++)
            {
                location = new PKMDS.Location(locationindex);
                if ((location.LocationName != "") & (location.LocationName != null) & (location.LocationID != 0))
                {
                    metlocations.Add(location);
                    egglocations.Add(location);
                }
            }
            location = new PKMDS.Location(2000);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(30001);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(30012);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(30013);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(30015);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(40001);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(40069);
            metlocations.Add(location);
            egglocations.Add(location);
            location = new PKMDS.Location(60002);
            metlocations.Add(location);
            egglocations.Add(location);

            cbMetLocation.DataSource = metlocations;
            cbMetLocation.DisplayMember = "LocationName";
            cbMetLocation.ValueMember = "LocationID";
            cbEggLocation.DataSource = egglocations;
            cbEggLocation.DisplayMember = "LocationName";
            cbEggLocation.ValueMember = "LocationID";
        }
        private void SetMoves()
        {
            List<PKMDS.Move> moves1 = new List<PKMDS.Move>();
            List<PKMDS.Move> moves2 = new List<PKMDS.Move>();
            List<PKMDS.Move> moves3 = new List<PKMDS.Move>();
            List<PKMDS.Move> moves4 = new List<PKMDS.Move>();
            PKMDS.Move move = new PKMDS.Move();
            for (UInt16 moveindex = 0; moveindex <= 559; moveindex++)
            {
                move = new PKMDS.Move(moveindex);
                if ((move.MoveName != "") & (move.MoveName != null) & (move.MoveID != 0))
                {
                    moves1.Add(move);
                }
                moves2.Add(move);
                moves3.Add(move);
                moves4.Add(move);
            }
            cbMove1.DataSource = moves1;
            cbMove1.DisplayMember = "MoveName";
            cbMove1.ValueMember = "MoveID";
            cbMove2.DataSource = moves2;
            cbMove2.DisplayMember = "MoveName";
            cbMove2.ValueMember = "MoveID";
            cbMove3.DataSource = moves3;
            cbMove3.DisplayMember = "MoveName";
            cbMove3.ValueMember = "MoveID";
            cbMove4.DataSource = moves4;
            cbMove4.DisplayMember = "MoveName";
            cbMove4.ValueMember = "MoveID";
        }
        private void SetHometowns()
        {
            List<PKMDS.Hometown> hometowns = new List<PKMDS.Hometown>();
            PKMDS.Hometown hometown = new PKMDS.Hometown();
            for (Byte hometownindex = 0; hometownindex <= 25; hometownindex++)
            {
                if ((hometownindex != 6) ||
                    (hometownindex != 9) ||
                    (hometownindex != 13) ||
                    (hometownindex != 14) ||
                    (hometownindex != 16) ||
                    (hometownindex != 17) ||
                    (hometownindex != 18) ||
                    (hometownindex != 19))
                {
                    hometown = new PKMDS.Hometown(hometownindex);
                    if ((hometown.HometownName != "") & (hometown.HometownName != null) & (hometown.HometownID != 0))
                    {
                        hometowns.Add(hometown);
                    }
                }
            }
            cbGame.DataSource = hometowns;
            cbGame.DisplayMember = "HometownName";
            cbGame.ValueMember = "HometownID";
        }
        private void SetCountries()
        {
            List<PKMDS.Country> countries = new List<PKMDS.Country>();
            PKMDS.Country country = new PKMDS.Country();
            for (Byte countryindex = 0; countryindex <= 8; countryindex++)
            {
                if (countryindex != 6)
                {
                    country = new PKMDS.Country(countryindex);
                    if ((country.CountryName != "") & (country.CountryName != null) & (country.CountryID != 0))
                    {
                        countries.Add(country);
                    }
                }
            }
            cbCountry.DataSource = countries;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }
        public void SetPKM(PKMDS.Pokemon pokemon)
        {
            pkm = pokemon;
            temppkm.Data = pkm.Data;
            SetForms();
            controlsbinding.ResetBindings(false);
        }
        public void SetPKM(PKMDS.PartyPokemon pokemon)
        {
            pkm = pokemon.PokemonData;
            temppkm.Data = pkm.Data;
            SetForms();
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
        private void pbMarkings_Click(object sender, EventArgs e)
        {
            if ((PictureBox)(sender) == this.pbDiamond)
            {
                temppkm.Diamond = !(temppkm.Diamond);
                diamondbinding.ReadValue();
            }
            if ((PictureBox)(sender) == this.pbTriangle)
            {
                temppkm.Triangle = !(temppkm.Triangle);
                trianglebinding.ReadValue();
            }
            if ((PictureBox)(sender) == this.pbSquare)
            {
                temppkm.Square = !(temppkm.Square);
                squarebinding.ReadValue();
            }
            if ((PictureBox)(sender) == this.pbHeart)
            {
                temppkm.Heart = !(temppkm.Heart);
                heartbinding.ReadValue();
            }
            if ((PictureBox)(sender) == this.pbStar)
            {
                temppkm.Star = !(temppkm.Star);
                starbinding.ReadValue();
            }
            if ((PictureBox)(sender) == this.pbCircle)
            {
                temppkm.Circle = !(temppkm.Circle);
                circlebinding.ReadValue();
            }
        }
        private void cbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetForms();
        }
    }
}
