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
            // TODO: finish data bindings
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
            if (temppkm.SpeciesID != 0)
            {
                string[] formnames = PKMDS.GetPKMFormNames(temppkm.SpeciesID);
                if (formnames.Length != 0)
                {
                    if (!((formnames.Length == 1) && (formnames[0] == "")))
                    {
                        cbForm.Items.AddRange(PKMDS.GetPKMFormNames(temppkm.SpeciesID));
                        cbForm.Enabled = true;
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
            controlsbinding.ResetBindings(false);
        }
        public void SetPKM(PKMDS.PartyPokemon pokemon)
        {
            pkm = pokemon.PokemonData;
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
