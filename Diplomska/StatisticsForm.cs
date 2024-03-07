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
        Database db = new Database();
        public StatisticsForm()
        {
            InitializeComponent();
            LoadStats();
            FillData();
        }
        public StatisticsForm(int match_id)
        {
            InitializeComponent();
        }
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
        void LoadStats()
        {
            matchCount = db.GetMatchCount();
            avgDrakes = db.GetDrakeSum() / matchCount;
            avgHeralds = db.GetRiftHeraldSum() / matchCount;
            avgBarons = db.GetBaronSum() / matchCount;
            avgCs = db.GetCreepScoreSum() / matchCount;
            avgVisionScore = db.GetVisionScoreSum() / matchCount;
            avgKills = db.GetKillSum() / matchCount;
            avgDeaths = db.GetDeathSum() / matchCount;
            avgAssists = db.GetAssistSum() / matchCount;
            avgMatchLength = db.GetMatchLenghtSum() / matchCount;
            winCount = db.GetMatchCountWon();
            role = db.GetMostPlayedRole();
            champion = db.GetMostPlayedChampion();
        }
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
            winPercentageTextBox.Text = ((winCount * 100) / matchCount).ToString() + "%";
            mostPlayedRoleTextBox.Text = role.Name;
            mostPlayedChampionTextBox.Text = champion.Name;
        }
    }
}
