using PandoraSharp;
using PandoraSharpPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandoraList
{
    public partial class SearchForm : Form
    {
        public Player Player { get; set; }
        public Station CurrentStation { get; set; }

        public SearchForm(Station curStation, Player player)
        {
            InitializeComponent();
            CurrentStation = curStation;
            Player = player;
            Player.SearchResult += Player_SearchResult;
        }

        private void Player_SearchResult(object sender, List<SearchResult> result)
        {
            Action x = () =>
            {
                listResults.Items.Clear();
                foreach (var item in result)
                {
                    listResults.Items.Add(item);
                }
            };
            if (InvokeRequired)
                Invoke(x);
            else
                x();
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Player.StationSearchNew(txtQuery.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedItem != null)
            {
                if (CurrentStation != null)
                    CurrentStation.AddVariety((SearchResult)listResults.SelectedItem);
                else
                    Player.CreateStation((SearchResult)listResults.SelectedItem);
            }
            Close();
        }

        private void listResults_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
                e.Graphics.DrawString(((SearchResult)listResults.Items[e.Index]).DisplayName, listResults.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }
    }
}
