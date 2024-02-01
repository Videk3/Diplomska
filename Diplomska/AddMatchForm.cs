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

        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void itemsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(itemsCheckedListBox.CheckedItems.Count >= 6)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }
    }
}
