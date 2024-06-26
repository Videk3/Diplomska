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
    public partial class AddMatchForm : Form
    {
        // Database instance
        Database db = new Database();

        public AddMatchForm()
        {
            // Initialize the form components
            InitializeComponent();

            // Retrieve champions, roles, summoner spells, and items from the database
            List<Champion> champions = db.GetChampions();
            List<Role> roles = db.GetRoles();
            List<SummonerSpell> summonerSpells = db.GetSummonerSpells();
            List<string> items = db.GetItems();

            // Populate dropdowns with champions, roles, and summoner spells
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

            // Populate items list
            foreach (string item in items)
            {
                itemsCheckedListBox.Items.Add(item);
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

        // Event handler to limit the number of checked items in the itemsCheckedListBox
        private void itemsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (itemsCheckedListBox.CheckedItems.Count >= 6)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        // Event handler for adding a match to the database
        private void addMatchButton_Click(object sender, EventArgs e)
        {
            // Get all the values from the form
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
            int match_length = int.Parse(matchLengthTextBox.Text); // Corrected variable name
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

            // Get IDs for the values from the database
            int champion_id = db.GetChampionId(champion);
            int role_id = db.GetRoleId(role);
            int summoner_spell1_id = db.GetSummonerSpellId(summoner_spell1);
            int summoner_spell2_id = db.GetSummonerSpellId(summoner_spell2);

            // Add the match to the database
            int match_id = db.AddMatch(champion_id, role_id, summoner_spell1_id, summoner_spell2_id, date, kills, deaths, assists, creep_score, vision_score, match_length, drake, rift_herald, baron, enemy_top, enemy_jungle, enemy_mid, enemy_adc, enemy_support, win);

            // Add the items to the match
            foreach (string item in itemsCheckedListBox.CheckedItems)
            {
                db.AddItemToMatch(match_id, item);
            }
        }
    }
}
