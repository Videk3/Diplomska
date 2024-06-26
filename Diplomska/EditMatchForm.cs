﻿using System;
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
        // Database instance
        Database db = new Database();
        int match_id;

        // Constructor to initialize the form for editing a match
        public EditMatchForm(int id)
        {
            InitializeComponent();
            match_id = id;

            // Populate dropdowns with champions, roles, and summoner spells
            PopulateDropdowns();

            // Fill the form with existing match data
            FillData(match_id);
        }

        // Constructor to initialize the form for viewing a match (read-only mode)
        public EditMatchForm(int id, bool readOnly)
        {
            InitializeComponent();
            match_id = id;

            // Populate dropdowns with champions, roles, and summoner spells
            PopulateDropdowns();

            // Fill the form with existing match data
            FillData(match_id);

            // Set form elements to read-only mode
            setReadOnly();
        }

        // Method to populate dropdowns with champions, roles, and summoner spells
        private void PopulateDropdowns()
        {
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
        }

        // Method to fill the form with existing match data
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
            List<string> items = db.GetMatchItems(match_id);
            foreach (string item in items)
            {
                itemsCheckedListBox.SetItemChecked(itemsCheckedListBox.Items.IndexOf(item), true);
            }
        }

        // Event handler for allowing only numeric input in certain textboxes
        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        // Event handler for canceling match editing
        private void cancelMatchButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for saving edited match data
        private void saveMatchButton_Click(object sender, EventArgs e)
        {
            // Get all the new values from the form
            Match match = db.GetMatch(match_id);
            DateTime date = matchDateTimePicker.Value;
            string champion = championComboBox.Text;
            string role = roleComboBox.Text;
            string summoner_spell1 = summonerSpell1ComboBox.Text;
            string summoner_spell2 = summonerSpell2ComboBox.Text;
            int kills = int.Parse(killsTextBox.Text);
            int deaths = int.Parse(deathsTextBox.Text);
            int assists = int.Parse(assistsTextBox.Text);
            int creep_score = int.Parse(creepScoreTextBox.Text);
            int vision_score = int.Parse(visionScoreTextBox.Text);
            int match_length = int.Parse(matchLenghtTextBox.Text); // Corrected variable name
            int drake = int.Parse(drakeTextBox.Text);
            int rift_herald = int.Parse(riftHeraldTextBox.Text);
            int baron = int.Parse(baronTextBox.Text);
            bool win = winCheckBox.Checked;
            string enemy_top = enemyTopComboBox.Text;
            string enemy_jungle = enemyJungleComboBox.Text;
            string enemy_mid = enemyMidComboBox.Text;
            string enemy_adc = enemyAdcComboBox.Text;
            string enemy_support = enemySupportComboBox.Text;
            List<string> items = new List<string>();
            foreach (string item in itemsCheckedListBox.CheckedItems)
            {
                items.Add(item);
            }

            // Get IDs for the values from the database
            int champion_id = db.GetChampionId(champion);
            int role_id = db.GetRoleId(role);
            int summoner_spell1_id = db.GetSummonerSpellId(summoner_spell1);
            int summoner_spell2_id = db.GetSummonerSpellId(summoner_spell2);
            int prev_EnemyTeam = match.EnemyTeam;

            // Update match data in the database
            db.DeleteMatchItems(match.Id);
            db.UpdateMatch(match.Id, champion_id, role_id, summoner_spell1_id, summoner_spell2_id, date, kills, deaths, assists, creep_score, vision_score, match_length, drake, rift_herald, baron, enemy_top, enemy_jungle, enemy_mid, enemy_adc, enemy_support, win);
            foreach (string item in items)
            {
                db.AddItemToMatch(match.Id, item);
            }
            db.DeleteEnemyTeam(prev_EnemyTeam);
        }

        // Event handler to limit the number of checked items in the itemsCheckedListBox
        private void itemsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (itemsCheckedListBox.CheckedItems.Count >= 6)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        // Method to set form elements to read-only mode
        private void setReadOnly()
        {
            championComboBox.Enabled = false;
            matchDateTimePicker.Enabled = false;
            killsTextBox.ReadOnly = true;
            deathsTextBox.ReadOnly = true;
            assistsTextBox.ReadOnly = true;
            creepScoreTextBox.ReadOnly = true;
            visionScoreTextBox.ReadOnly = true;
            matchLenghtTextBox.ReadOnly = true;
            drakeTextBox.ReadOnly = true;
            riftHeraldTextBox.ReadOnly = true;
            baronTextBox.ReadOnly = true;
            winCheckBox.Enabled = false;
            roleComboBox.Enabled = false;
            summonerSpell1ComboBox.Enabled = false;
            summonerSpell2ComboBox.Enabled = false;
            enemyTopComboBox.Enabled = false;
            enemyJungleComboBox.Enabled = false;
            enemyMidComboBox.Enabled = false;
            enemyAdcComboBox.Enabled = false;
            enemySupportComboBox.Enabled = false;
            saveMatchButton.Visible = false;
            cancelMatchButton.Text = "Close";
            this.Text = "View match";
        }
    }
}
