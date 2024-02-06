using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomska
{
    public partial class EditMatchForm : Form
    {
        Database db = new Database();
        int match_id;
        public EditMatchForm(int id)
        {
            match_id = id;
            InitializeComponent();
            List<Champion> champions = db.GetChampions();
            List<Role> roles = db.GetRoles();
            List<SummonerSpell> summonerSpells = db.GetSummonerSpells();
            List<string> items = db.GetItems();
            foreach (Champion champion in champions)
            {
                championComboBox.Items.Add(champion.Name);
                enemyTopComboBox.Items.Add(champion.Name);
                enemyJungleComboBox.Items.Add(champion.Name);
                enemyMidComboBox.Items.Add(champion.Name);
                enemyAdcComboBox.Items.Add(champion.Name);
                enemySupportComboBox.Items.Add(champion.Name);
            }
            foreach (Role role in roles)
            {
                roleComboBox.Items.Add(role.Name);
            }
            foreach (SummonerSpell summonerSpell in summonerSpells)
            {
                summonerSpell1ComboBox.Items.Add(summonerSpell.Name);
                summonerSpell2ComboBox.Items.Add(summonerSpell.Name);
            }
            foreach (string item in items)
            {
                itemsCheckedListBox.Items.Add(item);
            }
            FillData(match_id);
        }
        //WIP
        private void FillData(int id)
        {
            Match match = db.GetMatch(id);
            championComboBox.Text = match.Champion.Name;
            matchDateTimePicker.Value = match.Date;
            killsTextBox.Text = match.Kills.ToString();
            deathsTextBox.Text = match.Deaths.ToString();
            assistsTextBox.Text = match.Assists.ToString();
            creepScoreTextBox.Text = match.CreepScore.ToString();
            visionScoreTextBox.Text = match.VisionScore.ToString();
            matchLenghtTextBox.Text = match.MatchLength.ToString();
            drakeTextBox.Text = match.Drake.ToString();
            riftHeraldTextBox.Text = match.RiftHerald.ToString();
            baronTextBox.Text = match.Baron.ToString();
            winCheckBox.Checked = match.Win;
            roleComboBox.SelectedItem = match.Role.Name;
            summonerSpell1ComboBox.SelectedItem = match.SummonerSpell1.Name;
            summonerSpell2ComboBox.SelectedItem = match.SummonerSpell2.Name;
            List<Champion> enemyTeam = db.GetEnemyTeamByMatch(match);
            enemyTopComboBox.Text = enemyTeam.ElementAt(0).Name.ToString();
            enemyJungleComboBox.Text = enemyTeam.ElementAt(1).Name.ToString();
            enemyMidComboBox.Text = enemyTeam.ElementAt(2).Name.ToString();
            enemyAdcComboBox.Text = enemyTeam.ElementAt(3).Name.ToString();
            enemySupportComboBox.Text = enemyTeam.ElementAt(4).Name.ToString();
            List<string> items = db.GetMatchItems(match.Id);
            foreach (string item in items)
            {
                itemsCheckedListBox.SetItemChecked(itemsCheckedListBox.Items.IndexOf(item), true);
            }
        }
        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cancelMatchButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
