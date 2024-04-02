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
    public partial class StatisticsForm : Form
    {
        // Database instance
        Database db = new Database();

        // Variables to store statistics
        int avgDrakes;
        int avgHeralds;
        int avgBarons;
        int avgCs;
        int avgVisionScore;
        int avgKills;
        int avgDeaths;
        int avgAssists;
        int avgMatchLength;
        int matchCount;
        int winCount;
        Role role = new Role();
        Champion champion = new Champion();

        // Constructor
        public StatisticsForm()
        {
            InitializeComponent();

            // Load statistics and fill data
            LoadStats();
            FillData();
        }

        // Overloaded constructor
        public StatisticsForm(int match_id)
        {
            InitializeComponent();
        }

        // Method to load statistics from the database
        void LoadStats()
        {
            // Get total number of matches
            matchCount = db.GetMatchCount();

            // Calculate average statistics
            avgDrakes = db.GetDrakeSum() / matchCount;
            avgHeralds = db.GetRiftHeraldSum() / matchCount;
            avgBarons = db.GetBaronSum() / matchCount;
            avgCs = db.GetCreepScoreSum() / matchCount;
            avgVisionScore = db.GetVisionScoreSum() / matchCount;
            avgKills = db.GetKillSum() / matchCount;
            avgDeaths = db.GetDeathSum() / matchCount;
            avgAssists = db.GetAssistSum() / matchCount;
            avgMatchLength = db.GetMatchLenghtSum() / matchCount;

            // Get total number of wins
            winCount = db.GetMatchCountWon();

            // Get most played role and champion
            role = db.GetMostPlayedRole();
            champion = db.GetMostPlayedChampion();
        }

        // Method to fill data in the form
        void FillData()
        {
            avgDrakesTextBox.Text = avgDrakes.ToString();
            avgHeraldsTextBox.Text = avgHeralds.ToString();
            avgBaronsTextBox.Text = avgBarons.ToString();
            avgCreepScoreTextBox.Text = avgCs.ToString();
            avgVisionScoreTextBox.Text = avgVisionScore.ToString();
            avgKillsTextBox.Text = avgKills.ToString();
            avgDeathsTextBox.Text = avgDeaths.ToString();
            avgAssistsTextBox.Text = avgAssists.ToString();
            avgMatchLenghtTextBox.Text = avgMatchLength.ToString();

            // Calculate and display win percentage
            winPercentageTextBox.Text = ((winCount * 100) / matchCount).ToString() + "%";

            // Display most played role and champion
            mostPlayedRoleTextBox.Text = role.Name;
            mostPlayedChampionTextBox.Text = champion.Name;
        }
    }
}
