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
    public partial class AddMatchForm : Form
    {
        Database db = new Database();
        public AddMatchForm()
        {
            InitializeComponent();
            List<Champion> champions = db.GetChampions();
            List<Role> roles = db.GetRoles();
            List<SummonerSpell> summonerSpells = db.GetSummonerSpells();
            foreach (Champion champion in champions)
            {
                championComboBox.Items.Add(champion);
                enemyTopComboBox.Items.Add(champion);
                enemyJungleComboBox.Items.Add(champion);
                enemyMidComboBox.Items.Add(champion);
                enemyAdcComboBox.Items.Add(champion);
                enemySupportComboBox.Items.Add(champion);
            }
            foreach (Role role in roles)
            {
                roleComboBox.Items.Add(role);
            }
            foreach (SummonerSpell summonerSpell in summonerSpells)
            {
                summonerSpell1ComboBox.Items.Add(summonerSpell);
                summonerSpell2ComboBox.Items.Add(summonerSpell);
            }
        }

        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
