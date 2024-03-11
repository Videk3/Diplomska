using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplomska
{
    public partial class Form1 : Form
    {
        private Database db = new Database();
        List<Match> matches = new List<Match>();
        public Form1()
        {
            InitializeComponent();
            RefreshData();
        }

        private void newMatchButton_Click(object sender, EventArgs e)
        {
            AddMatchForm addMatchForm = new AddMatchForm();
            addMatchForm.Show();
        }
        public void RefreshData()
        {
            recordsListView.Items.Clear();
            matches = db.GetMatches();
            foreach (Match match in matches)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = match.Id;
                item.Text = match.Champion.Name.ToString();
                item.SubItems.Add(match.Date.ToString());
                item.SubItems.Add(match.Kills.ToString());
                item.SubItems.Add(match.Deaths.ToString());
                item.SubItems.Add(match.Assists.ToString());
                item.SubItems.Add(match.CreepScore.ToString());
                item.SubItems.Add(match.VisionScore.ToString());
                item.SubItems.Add(match.MatchLength.ToString());
                item.SubItems.Add(match.Win ? "Yes" : "No");
                item.SubItems.Add(match.Role.Name.ToString());

                recordsListView.Items.Add(item);
            }
            recordsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void removeRecordButton_Click(object sender, EventArgs e)
        {
            if (recordsListView.SelectedItems.Count > 0)
            {
                int id = (int)recordsListView.SelectedItems[0].Tag;
                Match match = db.GetMatch(id);
                db.DeleteMatchItems(id);
                db.DeleteEnemyTeam(match.EnemyTeam);
                db.RemoveMatch(id);
            }
        }

        private void editRecordButton_Click(object sender, EventArgs e)
        {
            if (recordsListView.SelectedItems.Count > 0)
            {
                int id = (int)recordsListView.SelectedItems[0].Tag;
                EditMatchForm editMatchForm = new EditMatchForm(id);
                editMatchForm.Show();
            }
        }

        private void statisticsAllButton_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.Show();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (recordsListView.SelectedItems.Count > 0)
            {
                int id = (int)recordsListView.SelectedItems[0].Tag;
                EditMatchForm editMatchForm = new EditMatchForm(id, true);
                editMatchForm.Show();
            }
        }
    }
}
