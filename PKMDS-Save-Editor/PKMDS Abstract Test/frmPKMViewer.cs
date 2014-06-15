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
        Binding move2binding;
        Binding move3binding;
        Binding move4binding;
        Binding move1powerbinding;
        Binding move2powerbinding;
        Binding move3powerbinding;
        Binding move4powerbinding;
        Binding move1accuracybinding;
        Binding move2accuracybinding;
        Binding move3accuracybinding;
        Binding move4accuracybinding;
        Binding tnlpercentbinding;
        bool uiset = false;
        public frmPKMViewer()
        {
            InitializeComponent();
            PKMDS.SQL.OpenDB(Properties.Settings.Default.veekunpokedex);
            if (!uiset)
            {
                SetUI();
            }

            DataSourceUpdateMode variableupdatemode = DataSourceUpdateMode.OnPropertyChanged;
#if DEBUG
            variableupdatemode = DataSourceUpdateMode.OnValidation;
#endif
            //#if RELEASE
            //            variableupdatemode = DataSourceUpdateMode.OnValidation;
            //#endif
            controlsbinding.DataSource = temppkm;
            formsbindingsource.DataSource = temppkm;
            numSpecies.DataBindings.Add("Value", controlsbinding, "SpeciesID", false, variableupdatemode, 0);
            pbSprite.DataBindings.Add("Image", controlsbinding, "Sprite", true, DataSourceUpdateMode.Never, null);
            pbBall.DataBindings.Add("Image", controlsbinding, "BallPic", true, DataSourceUpdateMode.Never, null);
            cbSpecies.DataBindings.Add("SelectedValue", controlsbinding, "SpeciesID", false, variableupdatemode, -1);
            cbHeldItem.DataBindings.Add("SelectedValue", controlsbinding, "ItemID", false, variableupdatemode, 0);
            lblHeldItemFlavor.DataBindings.Add("Text", controlsbinding, "ItemFlavor", false, DataSourceUpdateMode.Never, "");
            pbHeldItem.DataBindings.Add("Image", controlsbinding, "ItemPic", true, DataSourceUpdateMode.Never, null);
            numTID.DataBindings.Add("Value", controlsbinding, "TID", false, variableupdatemode, 0);
            numSID.DataBindings.Add("Value", controlsbinding, "SID", false, variableupdatemode, 0);
            pbGender.DataBindings.Add("Image", controlsbinding, "GenderIcon", true, DataSourceUpdateMode.Never, null);
            pbType1.DataBindings.Add("Image", controlsbinding, "TypePic1", true, DataSourceUpdateMode.Never, null);
            pbType2.DataBindings.Add("Image", controlsbinding, "TypePic2", true, DataSourceUpdateMode.Never, null);
            cbBall.DataBindings.Add("SelectedValue", controlsbinding, "BallID", false, variableupdatemode, -1);
            pbShiny.DataBindings.Add("Image", controlsbinding, "ShinyIcon", true, DataSourceUpdateMode.Never, null);
            pbPokerus.DataBindings.Add("Image", controlsbinding, "PokerusIcon", true, DataSourceUpdateMode.Never, null);
            chkNicknamed.DataBindings.Add("Checked", controlsbinding, "IsNicknamed", false, variableupdatemode, false);
            nicknamedbinding = txtNickname.DataBindings.Add("Text", controlsbinding, "Nickname", true, variableupdatemode, "");
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
            formbinding = cbForm.DataBindings.Add("SelectedIndex", formsbindingsource, "FormID", false, variableupdatemode, -1);
            formbinding.Format += new ConvertEventHandler(FormConvert);
            numLevel.DataBindings.Add("Value", controlsbinding, "Level", false, variableupdatemode, 0);
            rbOTMale.DataBindings.Add("Checked", controlsbinding, "OTIsMale", false, variableupdatemode, false);
            rbOTFemale.DataBindings.Add("Checked", controlsbinding, "OTIsFemale", false, variableupdatemode, false);
            txtOTName.DataBindings.Add("Text", controlsbinding, "OTName", true, variableupdatemode, "");
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
            cbNature.DataBindings.Add("SelectedValue", controlsbinding, "NatureID", false, variableupdatemode, -1);
            numEXP.DataBindings.Add("Value", controlsbinding, "EXP", false, variableupdatemode, 0);
            cbAbility.DataBindings.Add("SelectedValue", controlsbinding, "AbilityID", false, variableupdatemode, -1);
            lblAbilityFlavor.DataBindings.Add("Text", controlsbinding, "AbilityFlavor", false, DataSourceUpdateMode.Never, "");
            lblCharacteristic.DataBindings.Add("Text", controlsbinding, "Characteristic", false, DataSourceUpdateMode.Never, "");
            maxtamenessbinding = numTameness.DataBindings.Add("Value", controlsbinding, "Tameness", false, variableupdatemode, 0);
            cbMove1.DataBindings.Add("SelectedValue", controlsbinding, "Move1ID", false, variableupdatemode, -1);
            move2binding = cbMove2.DataBindings.Add("SelectedValue", controlsbinding, "Move2ID", false, variableupdatemode, -1);
            move3binding = cbMove3.DataBindings.Add("SelectedValue", controlsbinding, "Move3ID", false, variableupdatemode, -1);
            move4binding = cbMove4.DataBindings.Add("SelectedValue", controlsbinding, "Move4ID", false, variableupdatemode, -1);
            numMove1PP.DataBindings.Add("Value", controlsbinding, "Move1PP", false, variableupdatemode, 0);
            numMove1PPUps.DataBindings.Add("Value", controlsbinding, "Move1PPUps", false, variableupdatemode, 0);
            numMove2PP.DataBindings.Add("Value", controlsbinding, "Move2PP", false, variableupdatemode, 0);
            numMove2PPUps.DataBindings.Add("Value", controlsbinding, "Move2PPUps", false, variableupdatemode, 0);
            numMove3PP.DataBindings.Add("Value", controlsbinding, "Move3PP", false, variableupdatemode, 0);
            numMove3PPUps.DataBindings.Add("Value", controlsbinding, "Move3PPUps", false, variableupdatemode, 0);
            numMove4PP.DataBindings.Add("Value", controlsbinding, "Move4PP", false, variableupdatemode, 0);
            numMove4PPUps.DataBindings.Add("Value", controlsbinding, "Move4PPUps", false, variableupdatemode, 0);
            txtMove1MaxPP.DataBindings.Add("Text", controlsbinding, "Move1MaxPP", true, DataSourceUpdateMode.Never, "");
            txtMove2MaxPP.DataBindings.Add("Text", controlsbinding, "Move2MaxPP", true, DataSourceUpdateMode.Never, "");
            txtMove3MaxPP.DataBindings.Add("Text", controlsbinding, "Move3MaxPP", true, DataSourceUpdateMode.Never, "");
            txtMove4MaxPP.DataBindings.Add("Text", controlsbinding, "Move4MaxPP", true, DataSourceUpdateMode.Never, "");
            move2binding.Format += new ConvertEventHandler(MoveEnabledFormat);
            move3binding.Format += new ConvertEventHandler(MoveEnabledFormat);
            move4binding.Format += new ConvertEventHandler(MoveEnabledFormat);
            maxhpivbinding = numHPIV.DataBindings.Add("Value", controlsbinding, "HPIV", false, variableupdatemode, 0);
            maxatkivbinding = numAtkIV.DataBindings.Add("Value", controlsbinding, "AttackIV", false, variableupdatemode, 0);
            maxdefivbinding = numDefIV.DataBindings.Add("Value", controlsbinding, "DefenseIV", false, variableupdatemode, 0);
            maxspatkivbinding = numSpAtkIV.DataBindings.Add("Value", controlsbinding, "SpecialAttackIV", false, variableupdatemode, 0);
            maxspdefivbinding = numSpDefIV.DataBindings.Add("Value", controlsbinding, "SpecialDefenseIV", false, variableupdatemode, 0);
            maxspeedivbinding = numSpeedIV.DataBindings.Add("Value", controlsbinding, "SpeedIV", false, variableupdatemode, 0);
            maxhpevbinding = numHPEV.DataBindings.Add("Value", controlsbinding, "HPEV", false, variableupdatemode, 0);
            maxatkevbinding = numAtkEV.DataBindings.Add("Value", controlsbinding, "AttackEV", false, variableupdatemode, 0);
            maxdefevbinding = numDefEV.DataBindings.Add("Value", controlsbinding, "DefenseEV", false, variableupdatemode, 0);
            maxspatkevbinding = numSpAtkEV.DataBindings.Add("Value", controlsbinding, "SpecialAttackEV", false, variableupdatemode, 0);
            maxspdefevbinding = numSpDefEV.DataBindings.Add("Value", controlsbinding, "SpecialDefenseEV", false, variableupdatemode, 0);
            maxspeedevbinding = numSpeedEV.DataBindings.Add("Value", controlsbinding, "SpeedEV", false, variableupdatemode, 0);
            txtCalcHP.DataBindings.Add("Text", controlsbinding, "CalculatedHP", true, DataSourceUpdateMode.Never, "");
            txtCalcAtk.DataBindings.Add("Text", controlsbinding, "CalculatedAttack", true, DataSourceUpdateMode.Never, "");
            txtCalcDef.DataBindings.Add("Text", controlsbinding, "CalculatedDefense", true, DataSourceUpdateMode.Never, "");
            txtCalcSpAtk.DataBindings.Add("Text", controlsbinding, "CalculatedSpecialAttack", true, DataSourceUpdateMode.Never, "");
            txtCalcSpDef.DataBindings.Add("Text", controlsbinding, "CalculatedSpecialDefense", true, DataSourceUpdateMode.Never, "");
            txtCalcSpeed.DataBindings.Add("Text", controlsbinding, "CalculatedSpeed", true, DataSourceUpdateMode.Never, "");
            maxtotalevbinding = txtTotalEVs.DataBindings.Add("Text", controlsbinding, "TotalEVs", true, DataSourceUpdateMode.Never, "0");
            numMetLevel.DataBindings.Add("Value", controlsbinding, "MetLevel", false, variableupdatemode, 0);
            cbCountry.DataBindings.Add("SelectedValue", controlsbinding, "LanguageID", false, variableupdatemode, -1);
            cbGame.DataBindings.Add("SelectedValue", controlsbinding, "HometownID", false, variableupdatemode, -1);
            cbFateful.DataBindings.Add("Checked", controlsbinding, "IsFateful", false, variableupdatemode, false);
            cbNsPokemon.DataBindings.Add("Checked", controlsbinding, "IsNsPokemon", false, variableupdatemode, false);
            cbIsEgg.DataBindings.Add("Checked", controlsbinding, "IsEgg", false, variableupdatemode, false);
            cbPKRSStrain.DataBindings.Add("SelectedIndex", controlsbinding, "PokerusStrain", false, variableupdatemode, 0);
            cbPKRSDays.DataBindings.Add("SelectedIndex", controlsbinding, "PokerusDays", false, variableupdatemode, 0);
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
            cbMetLocation.DataBindings.Add("SelectedValue", controlsbinding, "MetLocationID", false, variableupdatemode, 0);
            cbEggLocation.DataBindings.Add("SelectedValue", controlsbinding, "EggLocationID", false, variableupdatemode, 0);
            cbEggLocation.DataBindings.Add("Enabled", cbMetAsEgg, "Checked", true, DataSourceUpdateMode.Never, false);
            numEXP.DataBindings.Add("Maximum", controlsbinding, "MaxEXP", false, DataSourceUpdateMode.Never, double.MaxValue);
            move1powerbinding = lblMove1Power.DataBindings.Add("Text", controlsbinding, "Move1Power", false, DataSourceUpdateMode.Never, "");
            move1accuracybinding = lblMove1Accuracy.DataBindings.Add("Text", controlsbinding, "Move1Accuracy", false, DataSourceUpdateMode.Never, "");
            lblMove1Flavor.DataBindings.Add("Text", controlsbinding, "Move1Flavor", false, DataSourceUpdateMode.Never, "");
            pbMove1Type.DataBindings.Add("Image", controlsbinding, "Move1TypePic", true, DataSourceUpdateMode.Never, null);
            pbMove1Category.DataBindings.Add("Image", controlsbinding, "Move1CategoryPic", true, DataSourceUpdateMode.Never, null);
            move2powerbinding = lblMove2Power.DataBindings.Add("Text", controlsbinding, "Move2Power", false, DataSourceUpdateMode.Never, "");
            move2accuracybinding = lblMove2Accuracy.DataBindings.Add("Text", controlsbinding, "Move2Accuracy", false, DataSourceUpdateMode.Never, "");
            lblMove2Flavor.DataBindings.Add("Text", controlsbinding, "Move2Flavor", false, DataSourceUpdateMode.Never, "");
            pbMove2Type.DataBindings.Add("Image", controlsbinding, "Move2TypePic", true, DataSourceUpdateMode.Never, null);
            pbMove2Category.DataBindings.Add("Image", controlsbinding, "Move2CategoryPic", true, DataSourceUpdateMode.Never, null);
            move3powerbinding = lblMove3Power.DataBindings.Add("Text", controlsbinding, "Move3Power", false, DataSourceUpdateMode.Never, "");
            move3accuracybinding = lblMove3Accuracy.DataBindings.Add("Text", controlsbinding, "Move3Accuracy", false, DataSourceUpdateMode.Never, "");
            lblMove3Flavor.DataBindings.Add("Text", controlsbinding, "Move3Flavor", false, DataSourceUpdateMode.Never, "");
            pbMove3Type.DataBindings.Add("Image", controlsbinding, "Move3TypePic", true, DataSourceUpdateMode.Never, null);
            pbMove3Category.DataBindings.Add("Image", controlsbinding, "Move3CategoryPic", true, DataSourceUpdateMode.Never, null);
            move4powerbinding = lblMove4Power.DataBindings.Add("Text", controlsbinding, "Move4Power", false, DataSourceUpdateMode.Never, "");
            move4accuracybinding = lblMove4Accuracy.DataBindings.Add("Text", controlsbinding, "Move4Accuracy", false, DataSourceUpdateMode.Never, "");
            lblMove4Flavor.DataBindings.Add("Text", controlsbinding, "Move4Flavor", false, DataSourceUpdateMode.Never, "");
            pbMove4Type.DataBindings.Add("Image", controlsbinding, "Move4TypePic", true, DataSourceUpdateMode.Never, null);
            pbMove4Category.DataBindings.Add("Image", controlsbinding, "Move4CategoryPic", true, DataSourceUpdateMode.Never, null);
            move1powerbinding.Format += new ConvertEventHandler(MovePowerFormat);
            move2powerbinding.Format += new ConvertEventHandler(MovePowerFormat);
            move3powerbinding.Format += new ConvertEventHandler(MovePowerFormat);
            move4powerbinding.Format += new ConvertEventHandler(MovePowerFormat);
            move1accuracybinding.Format += new ConvertEventHandler(MoveAccuracyFormat);
            move2accuracybinding.Format += new ConvertEventHandler(MoveAccuracyFormat);
            move3accuracybinding.Format += new ConvertEventHandler(MoveAccuracyFormat);
            move4accuracybinding.Format += new ConvertEventHandler(MoveAccuracyFormat);
            tcTabs.TabPages.Remove(tpRibbon);
            tcTabs.TabPages.Remove(tpMisc);
            pbTNL.DataBindings.Add("Minimum", controlsbinding, "EXPAtCurLevel", false, DataSourceUpdateMode.Never, 0);
            pbTNL.DataBindings.Add("Maximum", controlsbinding, "EXPAtNextLevel", false, DataSourceUpdateMode.Never, 100);
            pbTNL.DataBindings.Add("Value", controlsbinding, "EXP", false, DataSourceUpdateMode.Never, 0);
            txtTNL.DataBindings.Add("Text", controlsbinding, "TNL", false, DataSourceUpdateMode.Never, 0);
            tnlpercentbinding = txtTNLPercent.DataBindings.Add("Text", controlsbinding, "TNLPercent", true, DataSourceUpdateMode.Never, "0%");
            tnlpercentbinding.Format += TNLPercentFormat;
            dtEggDate.DataBindings.Add("Enabled", cbMetAsEgg, "Checked", true, DataSourceUpdateMode.Never, false);
            dtEggDate.DataBindings.Add("Value", controlsbinding, "EggDate", true, variableupdatemode, DateTime.Today);
            dtMetDate.DataBindings.Add("Value", controlsbinding, "MetDate", true, variableupdatemode, DateTime.Today);
            btnRevert.Visible = false;
        }
        private void TNLPercentFormat(object sender, ConvertEventArgs e)
        {
            if (temppkm.TNL == 0)
            {
                txtTNLPercent.Visible = false;
            }
            else
            {
                txtTNLPercent.Visible = true;
                e.Value = ((double)(e.Value)).ToString("p2", System.Globalization.CultureInfo.CreateSpecificCulture("hr-HR"));
            }
        }
        private void MovePowerFormat(object bindingsource, ConvertEventArgs e)
        {
            switch ((int)(e.Value))
            {
                case -1:
                    e.Value = "-";
                    break;
                case 0:
                    e.Value = "-";
                    break;
                case 1:
                    e.Value = "-";
                    break;
                default:
                    break;
            }
        }
        private void MoveAccuracyFormat(object bindingsource, ConvertEventArgs e)
        {
            switch ((int)(e.Value))
            {
                case -1:
                    e.Value = "-";
                    break;
                case 0:
                    e.Value = "-";
                    break;
                default:
                    e.Value = ((int)(e.Value)).ToString("0") + "%";
                    break;
            }
        }
        private void MoveEnabledFormat(object bindingsource, ConvertEventArgs e)
        {
            Binding binding = ((Binding)(bindingsource));
            if (binding.BindingMemberInfo.BindingMember == "Move2ID")
            {
                numMove2PP.Enabled = ((UInt16)(e.Value) != 0);
                numMove2PPUps.Enabled = ((UInt16)(e.Value) != 0);
            }
            if (binding.BindingMemberInfo.BindingMember == "Move3ID")
            {
                numMove3PP.Enabled = ((UInt16)(e.Value) != 0);
                numMove3PPUps.Enabled = ((UInt16)(e.Value) != 0);
            }
            if (binding.BindingMemberInfo.BindingMember == "Move4ID")
            {
                numMove4PP.Enabled = ((UInt16)(e.Value) != 0);
                numMove4PPUps.Enabled = ((UInt16)(e.Value) != 0);
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
                //formsbindingsource.ResetBindings(false);
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
            if (cbForm.Enabled)
            {
                cbForm.Items.Clear();
                cbForm.Text = "";
            }
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
            for (Byte ballindex = 1; ballindex <= 25; ballindex++)
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
                moves4.Add(move);
            }
            moves1.AddRange(moves4);
            moves1.RemoveAt(0);
            moves2.AddRange(moves4);
            moves3.AddRange(moves4);
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
            //controlsbinding.CurrentItemChanged -= controlsbinding_CurrentItemChanged;
            pkm = pokemon;
            temppkm.Data = pkm.Data;
            SetForms();
            controlsbinding.ResetBindings(false);
            //formsbindingsource.ResetBindings(false);
            cbMetAsEgg.Checked = (temppkm.EggLocationID != 0);
            //controlsbinding.CurrentItemChanged += controlsbinding_CurrentItemChanged;
        }
        public void SetPKM(PKMDS.PartyPokemon pokemon)
        {
            //controlsbinding.CurrentItemChanged -= controlsbinding_CurrentItemChanged;
            pkm = pokemon.PokemonData;
            temppkm.Data = pkm.Data;
            SetForms();
            controlsbinding.ResetBindings(false);
            //formsbindingsource.ResetBindings(false);
            cbMetAsEgg.Checked = (temppkm.EggLocationID != 0);
            //controlsbinding.CurrentItemChanged += controlsbinding_CurrentItemChanged;
        }
        private void SavePKM()
        {
            if (temppkm.Move2ID == 0)
            {
                temppkm.Move2PP = 0;
                temppkm.Move2PPUps = 0;
            }
            if (temppkm.Move3ID == 0)
            {
                temppkm.Move3PP = 0;
                temppkm.Move3PPUps = 0;
            }
            if (temppkm.Move4ID == 0)
            {
                temppkm.Move4PP = 0;
                temppkm.Move4PPUps = 0;
            }
            temppkm.FixChecksum();
            pkm.Data = temppkm.Data;
            controlsbinding.ResetBindings(false);
            //formsbindingsource.ResetBindings(false);
        }
        private void frmPKMViewer_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePKM();
            //btnRevert.Enabled = false;
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
            if (!(temppkm.Data.SequenceEqual(pkm.Data)))
            {
                e.Cancel = (MessageBox.Show("If you close this window you will lose unsaved changes. Close this window anyway?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No);
                btnRevert.Enabled = false;
            }
        }
        private void cbMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cbMove1)
            {
                AutosizeFont(ref lblMove1Flavor);
            }
            if (sender == cbMove2)
            {
                AutosizeFont(ref lblMove2Flavor);
            }
            if (sender == cbMove3)
            {
                AutosizeFont(ref lblMove3Flavor);
            }
            if (sender == cbMove4)
            {
                AutosizeFont(ref lblMove4Flavor);
            }
        }
        private void AutosizeFont(ref System.Windows.Forms.Label ctrl)
        {
            while ((Decimal)(ctrl.Width) < (Decimal)(System.Windows.Forms.TextRenderer.MeasureText(ctrl.Text,
     new Font(ctrl.Font.FontFamily, ctrl.Font.Size, ctrl.Font.Style)).Width) / 1.90M)
            {
                ctrl.Font = new Font(ctrl.Font.FontFamily, ctrl.Font.Size - 0.5f, ctrl.Font.Style);
            }
        }
        private void cbMetAsEgg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMetAsEgg.Checked)
            {
                if (temppkm.EggLocationID == 0)
                {
                    if (pkm.EggLocationID != 0)
                    {
                        temppkm.EggLocationID = pkm.EggLocationID;
                    }
                    else
                    {
                        temppkm.EggLocationID = 1;
                    }
                    temppkm.EggDate = pkm.EggDate;
                }
            }
            else
            {
                temppkm.EggLocationID = 0;
                temppkm.SetNoEggDate();
            }
            dtEggDate.DataBindings[0].ReadValue();
            cbEggLocation.DataBindings[0].ReadValue();
            //btnRevert.Enabled = !(temppkm.Data.SequenceEqual(pkm.Data));
        }
        private void cbIsEgg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsEgg.Checked)
            {
                cbMetAsEgg.Checked = true;
            }
        }
        private void btnRevert_Click(object sender, EventArgs e)
        {
            //temppkm.Data = pkm.Data;
            //btnRevert.Enabled = false;
            //ResetAllBindings(this);
        }
        private void ResetAllBindings(Control control)
        {
            numEXP.DataBindings[1].ReadValue();
            bool tryagain = false;
            do
            {
                foreach (Control ctrl in control.Controls)
                {
                    try
                    {
                        ResetAllBindings(ctrl);
                        tryagain = false;
                    }
                    catch (Exception ex)
                    {
                        tryagain = true;
                    }
                }
                if (control.DataBindings.Count > 0)
                {
                    for (int i = 0; i < control.DataBindings.Count; i++)
                    {
                        try
                        {
                            control.DataBindings[0].ReadValue();
                        }
                        catch (Exception ex)
                        {
                            tryagain = true;
                        }
                    }
                }
            }
            while (tryagain);
        }
        public void PreloadTabs()
        {
            foreach (TabPage tp in tcTabs.TabPages)
            {
                //tp.Show();
                tp.CreateControl();
            }
        }
    }
}
