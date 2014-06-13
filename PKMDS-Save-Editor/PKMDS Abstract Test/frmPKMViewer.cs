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
        BindingSource eggdatebindingsource = new BindingSource();
        Binding nicknamedbinding;
        Binding diamondbinding;
        Binding squarebinding;
        Binding trianglebinding;
        Binding circlebinding;
        Binding heartbinding;
        Binding starbinding;
        Binding formbinding;
        Binding otnamecolorbinding;
        Binding attackstatcolorbinding;
        Binding defensestatcolorbinding;
        Binding specialattackstatcolorbinding;
        Binding specialdefensestatcolorbinding;
        Binding speedstatcolorbinding;
        Binding maxhpivbinding;
        Binding maxatkivbinding;
        Binding maxdefivbinding;
        Binding maxspatkivbinding;
        Binding maxspdefivbinding;
        Binding maxspeedivbinding;
        Binding maxhpevbinding;
        Binding maxatkevbinding;
        Binding maxdefevbinding;
        Binding maxspatkevbinding;
        Binding maxspdefevbinding;
        Binding maxspeedevbinding;
        Binding maxtamenessbinding;
        Binding maxtotalevbinding;
        Binding eggdatebinding;
        bool uiset = false;
        public frmPKMViewer()
        {
            InitializeComponent();
            PKMDS.SQL.OpenDB(Properties.Settings.Default.veekunpokedex);
            if (!uiset)
            {
                SetUI();
            }
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
            btnApply.DataBindings.Add("Enabled", controlsbinding, "IsModified", false, DataSourceUpdateMode.Never, false);
            numLevel.DataBindings.Add("Value", controlsbinding, "Level", false, DataSourceUpdateMode.OnValidation, 0);
            rbOTMale.DataBindings.Add("Checked", controlsbinding, "OTIsMale", false, DataSourceUpdateMode.OnPropertyChanged, false);
            rbOTFemale.DataBindings.Add("Checked", controlsbinding, "OTIsFemale", false, DataSourceUpdateMode.OnPropertyChanged, false);
            txtOTName.DataBindings.Add("Text", controlsbinding, "OTName", true, DataSourceUpdateMode.OnValidation, "");
            otnamecolorbinding = txtOTName.DataBindings.Add("ForeColor", controlsbinding, "OTIsMale", true, DataSourceUpdateMode.Never, Color.Black);
            otnamecolorbinding.Format += new ConvertEventHandler(OTNameColorConvert);
            attackstatcolorbinding = lblAtkStats.DataBindings.Add("ForeColor", controlsbinding, "AttackEffect", true, DataSourceUpdateMode.Never, Color.Black);
            defensestatcolorbinding = lblDefStats.DataBindings.Add("ForeColor", controlsbinding, "DefenseEffect", true, DataSourceUpdateMode.Never, Color.Black);
            specialattackstatcolorbinding = lblSpAtkStats.DataBindings.Add("ForeColor", controlsbinding, "SpecialAttackEffect", true, DataSourceUpdateMode.Never, Color.Black);
            specialdefensestatcolorbinding = lblSpDefStats.DataBindings.Add("ForeColor", controlsbinding, "SpecialDefenseEffect", true, DataSourceUpdateMode.Never, Color.Black);
            speedstatcolorbinding = lblSpeedStats.DataBindings.Add("ForeColor", controlsbinding, "SpeedEffect", true, DataSourceUpdateMode.Never, Color.Black);
            attackstatcolorbinding.Format += new ConvertEventHandler(StatColorConvert);
            defensestatcolorbinding.Format += new ConvertEventHandler(StatColorConvert);
            specialattackstatcolorbinding.Format += new ConvertEventHandler(StatColorConvert);
            specialdefensestatcolorbinding.Format += new ConvertEventHandler(StatColorConvert);
            speedstatcolorbinding.Format += new ConvertEventHandler(StatColorConvert);
            cbNature.DataBindings.Add("SelectedValue", controlsbinding, "NatureID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            numEXP.DataBindings.Add("Value", controlsbinding, "EXP", false, DataSourceUpdateMode.OnValidation, 0);
            cbAbility.DataBindings.Add("SelectedValue", controlsbinding, "AbilityID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            lblAbilityFlavor.DataBindings.Add("Text", controlsbinding, "AbilityFlavor", false, DataSourceUpdateMode.Never, "");
            lblCharacteristic.DataBindings.Add("Text", controlsbinding, "Characteristic", false, DataSourceUpdateMode.Never, "");
            maxtamenessbinding = numTameness.DataBindings.Add("Value", controlsbinding, "Tameness", false, DataSourceUpdateMode.OnValidation, 0);
            cbMove1.DataBindings.Add("SelectedValue", controlsbinding, "Move1ID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            cbMove2.DataBindings.Add("SelectedValue", controlsbinding, "Move2ID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            cbMove3.DataBindings.Add("SelectedValue", controlsbinding, "Move3ID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            cbMove4.DataBindings.Add("SelectedValue", controlsbinding, "Move4ID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            numMove1PP.DataBindings.Add("Value", controlsbinding, "Move1PP", false, DataSourceUpdateMode.OnValidation, 0);
            numMove1PPUps.DataBindings.Add("Value", controlsbinding, "Move1PPUps", false, DataSourceUpdateMode.OnValidation, 0);
            numMove2PP.DataBindings.Add("Value", controlsbinding, "Move2PP", false, DataSourceUpdateMode.OnValidation, 0);
            numMove2PPUps.DataBindings.Add("Value", controlsbinding, "Move2PPUps", false, DataSourceUpdateMode.OnValidation, 0);
            numMove3PP.DataBindings.Add("Value", controlsbinding, "Move3PP", false, DataSourceUpdateMode.OnValidation, 0);
            numMove3PPUps.DataBindings.Add("Value", controlsbinding, "Move3PPUps", false, DataSourceUpdateMode.OnValidation, 0);
            numMove4PP.DataBindings.Add("Value", controlsbinding, "Move4PP", false, DataSourceUpdateMode.OnValidation, 0);
            numMove4PPUps.DataBindings.Add("Value", controlsbinding, "Move4PPUps", false, DataSourceUpdateMode.OnValidation, 0);
            txtMove1MaxPP.DataBindings.Add("Text", controlsbinding, "Move1MaxPP", true, DataSourceUpdateMode.Never, "");
            txtMove2MaxPP.DataBindings.Add("Text", controlsbinding, "Move2MaxPP", true, DataSourceUpdateMode.Never, "");
            txtMove3MaxPP.DataBindings.Add("Text", controlsbinding, "Move3MaxPP", true, DataSourceUpdateMode.Never, "");
            txtMove4MaxPP.DataBindings.Add("Text", controlsbinding, "Move4MaxPP", true, DataSourceUpdateMode.Never, "");
            maxhpivbinding = numHPIV.DataBindings.Add("Value", controlsbinding, "HPIV", false, DataSourceUpdateMode.OnValidation, 0);
            maxatkivbinding = numAtkIV.DataBindings.Add("Value", controlsbinding, "AttackIV", false, DataSourceUpdateMode.OnValidation, 0);
            maxdefivbinding = numDefIV.DataBindings.Add("Value", controlsbinding, "DefenseIV", false, DataSourceUpdateMode.OnValidation, 0);
            maxspatkivbinding = numSpAtkIV.DataBindings.Add("Value", controlsbinding, "SpecialAttackIV", false, DataSourceUpdateMode.OnValidation, 0);
            maxspdefivbinding = numSpDefIV.DataBindings.Add("Value", controlsbinding, "SpecialDefenseIV", false, DataSourceUpdateMode.OnValidation, 0);
            maxspeedivbinding = numSpeedIV.DataBindings.Add("Value", controlsbinding, "SpeedIV", false, DataSourceUpdateMode.OnValidation, 0);
            maxhpevbinding = numHPEV.DataBindings.Add("Value", controlsbinding, "HPEV", false, DataSourceUpdateMode.OnValidation, 0);
            maxatkevbinding = numAtkEV.DataBindings.Add("Value", controlsbinding, "AttackEV", false, DataSourceUpdateMode.OnValidation, 0);
            maxdefevbinding = numDefEV.DataBindings.Add("Value", controlsbinding, "DefenseEV", false, DataSourceUpdateMode.OnValidation, 0);
            maxspatkevbinding = numSpAtkEV.DataBindings.Add("Value", controlsbinding, "SpecialAttackEV", false, DataSourceUpdateMode.OnValidation, 0);
            maxspdefevbinding = numSpDefEV.DataBindings.Add("Value", controlsbinding, "SpecialDefenseEV", false, DataSourceUpdateMode.OnValidation, 0);
            maxspeedevbinding = numSpeedEV.DataBindings.Add("Value", controlsbinding, "SpeedEV", false, DataSourceUpdateMode.OnValidation, 0);
            txtCalcHP.DataBindings.Add("Text", controlsbinding, "CalculatedHP", true, DataSourceUpdateMode.Never, "");
            txtCalcAtk.DataBindings.Add("Text", controlsbinding, "CalculatedAttack", true, DataSourceUpdateMode.Never, "");
            txtCalcDef.DataBindings.Add("Text", controlsbinding, "CalculatedDefense", true, DataSourceUpdateMode.Never, "");
            txtCalcSpAtk.DataBindings.Add("Text", controlsbinding, "CalculatedSpecialAttack", true, DataSourceUpdateMode.Never, "");
            txtCalcSpDef.DataBindings.Add("Text", controlsbinding, "CalculatedSpecialDefense", true, DataSourceUpdateMode.Never, "");
            txtCalcSpeed.DataBindings.Add("Text", controlsbinding, "CalculatedSpeed", true, DataSourceUpdateMode.Never, "");
            maxtotalevbinding = txtTotalEVs.DataBindings.Add("Text", controlsbinding, "TotalEVs", true, DataSourceUpdateMode.Never, "0");
            maxtamenessbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxhpivbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxatkivbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxdefivbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxspatkivbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxspdefivbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxspeedivbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxhpevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxatkevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxdefevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxspatkevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxspdefevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxspeedevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            maxtotalevbinding.Format += new ConvertEventHandler(MaxStatFormat);
            cbIsEgg.DataBindings.Add("Checked", controlsbinding, "IsEgg", false, DataSourceUpdateMode.OnPropertyChanged, false);
            cbFateful.DataBindings.Add("Checked", controlsbinding, "IsFateful", false, DataSourceUpdateMode.OnPropertyChanged, false);
            cbNsPokemon.DataBindings.Add("Checked", controlsbinding, "IsNsPokemon", false, DataSourceUpdateMode.OnPropertyChanged, false);
            cbMetAsEgg.DataBindings.Add("Checked", controlsbinding, "MetAsEgg", false, DataSourceUpdateMode.OnPropertyChanged, false);
            cbPKRSStrain.DataBindings.Add("SelectedIndex", controlsbinding, "PokerusStrain", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            cbPKRSDays.DataBindings.Add("SelectedIndex", controlsbinding, "PokerusDays", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            cbEggLocation.DataBindings.Add("SelectedValue", controlsbinding, "EggLocationID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            cbMetLocation.DataBindings.Add("SelectedValue", controlsbinding, "MetLocationID", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            dtMetDate.DataBindings.Add("Value", controlsbinding, "MetDate", false, DataSourceUpdateMode.OnValidation, dtMetDate.MinDate);
            eggdatebinding = dtEggDate.DataBindings.Add("Value", eggdatebindingsource, "EggDate", false, DataSourceUpdateMode.OnValidation, new DateTime(1, 1, 1));
            eggdatebinding.Format += new ConvertEventHandler(EggDateFormat);
            numMetLevel.DataBindings.Add("Value", controlsbinding, "MetLevel", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            cbCountry.DataBindings.Add("SelectedValue", controlsbinding, "LanguageID", false, DataSourceUpdateMode.OnPropertyChanged, -1);
            cbGame.DataBindings.Add("SelectedValue", controlsbinding, "HometownID", false, DataSourceUpdateMode.OnPropertyChanged, -1);

            /*
txtMinHatchSteps.DataBindings.Add();
pbTNL.DataBindings.Add();
txtTNL.DataBindings.Add();
txtTNLPercent.DataBindings.Add();
lblMove1Accuracy.DataBindings.Add();
lblMove1Power.DataBindings.Add();
pbMove1Type.DataBindings.Add();
lblMove1Flavor.DataBindings.Add();
pbMove1Category.DataBindings.Add();
lblMove4Accuracy.DataBindings.Add();
lblMove4Power.DataBindings.Add();
pbMove4Category.DataBindings.Add();
pbMove4Type.DataBindings.Add();
lblMove4Flavor.DataBindings.Add();
lblMove2Accuracy.DataBindings.Add();
lblMove2Power.DataBindings.Add();
pbMove2Category.DataBindings.Add();
pbMove2Type.DataBindings.Add();
lblMove2Flavor.DataBindings.Add();
lblMove3Accuracy.DataBindings.Add();
lblMove3Power.DataBindings.Add();
tlMove3MoreData.DataBindings.Add();
pbMove3Category.DataBindings.Add();
pbMove3Type.DataBindings.Add();
lblMove3Flavor.DataBindings.Add();
             */
            // TODO: finish data bindings
            controlsbinding.DataSource = temppkm;
            formsbindingsource.DataSource = temppkm;
            eggdatebindingsource.DataSource = temppkm;
        }
        private void EggDateFormat(object bindingsource, ConvertEventArgs e)
        {
            Binding binding = (Binding)(bindingsource);
            if (Convert.ToDateTime(e.Value) == new DateTime(1, 1, 1))
            {
                //binding.ControlUpdateMode = ControlUpdateMode.Never;
                eggdatebindingsource.SuspendBinding();
                e.Value = dtEggDate.MinDate;
            }
            else
            {
                //binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
                eggdatebindingsource.ResumeBinding();
            }
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
            if (Convert.ToInt32(e.Value) >= cbForm.Items.Count)
            {
                temppkm.FormID = Convert.ToByte(cbForm.Items.Count - 1);
                controlsbinding.ResetBindings(false);
            }
        }
        private void OTNameColorConvert(object bindingsource, ConvertEventArgs e)
        {
            if ((bool)(e.Value) == true)
            {
                e.Value = Color.Blue;
            }
            else
            {
                e.Value = Color.Red;
            }
        }
        private void StatColorConvert(object bindingsource, ConvertEventArgs e)
        {
            switch ((PKMDS.NatureEffect)(e.Value))
            {
                case PKMDS.NatureEffect.Increase:
                    e.Value = Color.Red;
                    break;
                case PKMDS.NatureEffect.Decrease:
                    e.Value = Color.Blue;
                    break;
                case PKMDS.NatureEffect.NoEffect:
                    e.Value = Color.Black;
                    break;
            }
        }
        private void MaxStatFormat(object bindingsource, ConvertEventArgs e)
        {
            Binding binding = ((Binding)(bindingsource));
            Control control = binding.Control;
            if (binding.BindingMemberInfo.BindingMember == "HPIV")
            {
                SetControlFont(ref control, temppkm.HPIV == 31);
            }
            if (binding.BindingMemberInfo.BindingMember == "AttackIV")
            {
                SetControlFont(ref control, temppkm.AttackIV == 31);
            }
            if (binding.BindingMemberInfo.BindingMember == "DefenseIV")
            {
                SetControlFont(ref control, temppkm.DefenseIV == 31);
            }
            if (binding.BindingMemberInfo.BindingMember == "SpecialAttackIV")
            {
                SetControlFont(ref control, temppkm.SpecialAttackIV == 31);
            }
            if (binding.BindingMemberInfo.BindingMember == "SpecialDefenseIV")
            {
                SetControlFont(ref control, temppkm.SpecialDefenseIV == 31);
            }
            if (binding.BindingMemberInfo.BindingMember == "SpeedIV")
            {
                SetControlFont(ref control, temppkm.SpeedIV == 31);
            }
            if (binding.BindingMemberInfo.BindingMember == "HPEV")
            {
                SetControlFont(ref control, temppkm.HPEV >= 252);
            }
            if (binding.BindingMemberInfo.BindingMember == "AttackEV")
            {
                SetControlFont(ref control, temppkm.AttackEV >= 252);
            }
            if (binding.BindingMemberInfo.BindingMember == "DefenseEV")
            {
                SetControlFont(ref control, temppkm.DefenseEV >= 252);
            }
            if (binding.BindingMemberInfo.BindingMember == "SpecialAttackEV")
            {
                SetControlFont(ref control, temppkm.SpecialAttackEV >= 252);
            }
            if (binding.BindingMemberInfo.BindingMember == "SpecialDefenseEV")
            {
                SetControlFont(ref control, temppkm.SpecialDefenseEV >= 252);
            }
            if (binding.BindingMemberInfo.BindingMember == "SpeedEV")
            {
                SetControlFont(ref control, temppkm.SpeedEV >= 252);
            }
            if (binding.BindingMemberInfo.BindingMember == "TotalEVs")
            {
                SetControlFont(ref control, temppkm.TotalEVs >= 510);
            }
            if (binding.BindingMemberInfo.BindingMember == "Tameness")
            {
                SetControlFont(ref control, temppkm.Tameness == 255);
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
        private void SetControlFont(ref Control control, bool bold = false)
        {
            if (bold)
            {
                control.Font = new Font(control.Font, FontStyle.Bold);
            }
            else
            {
                control.Font = new Font(control.Font, FontStyle.Regular);
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
                        if ((int)(temppkm.FormID) >= cbForm.Items.Count)
                        {
                            temppkm.FormID = (byte)(cbForm.Items.Count - 1);
                        }
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
            temppkm.FixChecksum();
            pkm.Data = temppkm.Data;
            controlsbinding.ResetBindings(false);
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
            string filename = "";
            if (fileSave.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                filename = fileSave.FileName;
                if (filename != "")
                {
                    temppkm.FixChecksum();
                    System.IO.FileInfo fo = new System.IO.FileInfo(filename);
                    string extension = fo.Extension.ToLower().Replace(".", "");
                    temppkm.WriteToFile(filename, (extension == "bin") || (extension == "ek5"));
                }
            }
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
        private void frmPKMViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (temppkm.IsModified)
            {
                e.Cancel = (MessageBox.Show("If you close this window you will lose unsaved changes. Close this window anyway?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No);
            }
        }
    }
}

