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
    public partial class MainForm : Form
    {
        public Player player { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Player_StationsRefreshed(object sender)
        {
            UpdateStations();
        }

        private void UpdateStations()
        {
            Action x = () =>
            {
                listStations.Items.Clear();
                foreach (var station in player.Stations)
                {
                    if (station.Name != "Quick Mix")
                        listStations.Items.Add(station);
                }
            };

            if (InvokeRequired)
                Invoke(x);
            else
                x();
        }

        public void Init()
        {
            player = new Player();
            player.StationsRefreshed += Player_StationsRefreshed;
            player.StationCreated += Player_StationCreated;
            player.Initialize();

            var login = new LoginForm();
            login.player = player;
            var result = login.ShowDialog();
            if (result != DialogResult.OK)
                Close();
            else
                player.RefreshStations();
        }

        private void Player_StationCreated(object sender, Station station)
        {
            UpdateStations();
        }

        private void listStations_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            
            if (e.Index >= 0)
                e.Graphics.DrawString(((Station)listStations.Items[e.Index]).Name, listStations.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            
            e.DrawFocusRectangle();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listStations.SelectedItem != null)
                player.StationDelete((Station)listStations.SelectedItem);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listStations.SelectedItem != null)
            {
                var edit = new StationEditor((Station)listStations.SelectedItem, player);
                edit.ShowDialog();
                listStations.Invalidate();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var search = new SearchForm(null, player);
            search.ShowDialog();
            listStations.Invalidate();
        }
    }
}
