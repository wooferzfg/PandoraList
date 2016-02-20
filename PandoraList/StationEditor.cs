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
    public partial class StationEditor : Form
    {
        public Station CurrentStation { get; set; }
        public Player Player { get; set; }
        private List<Song> playlist { get; set; }

        public StationEditor(Station curStation, Player player)
        {
            InitializeComponent();
            CurrentStation = curStation;
            Player = player;
            SetUIElements();
        }

        private void SetUIElements()
        {
            txtTitle.Text = CurrentStation.Name;
            RefreshItems();
            UpdatePlaylist();
        }

        private void RefreshItems()
        {
            listSeeds.Items.Clear();
            foreach (var seed in CurrentStation.Seeds)
            {
                listSeeds.Items.Add(seed);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listSeeds.SelectedItem != null && CurrentStation.Seeds.Count > 1)
            {
                CurrentStation.RemoveSeed(((Seed)listSeeds.SelectedItem).SeedID);
                RefreshItems();
                UpdatePlaylist();
            }
        }

        private void UpdatePlaylist()
        {
            Task.Factory.StartNew(() =>
            {
                playlist = new List<Song>();
                for (int x = 0; x < 3; x++)
                {
                    playlist.AddRange(CurrentStation.GetPlaylist());
                }
                Action act = () =>
                {
                    listPlaylist.Items.Clear();
                    foreach (var song in playlist)
                    {
                        listPlaylist.Items.Add(song);
                    }
                };
                if (InvokeRequired)
                    Invoke(act);
                else
                    act();
            });
        }

        private void txtTitle_Validated(object sender, EventArgs e)
        {
            CurrentStation.Rename(txtTitle.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var search = new SearchForm(CurrentStation, Player);
            search.ShowDialog();
            RefreshItems();
            UpdatePlaylist();
        }
    }
}
