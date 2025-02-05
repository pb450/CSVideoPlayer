using PS5.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PS5
{
    public partial class PlaylistDisplay : Form
    {

        Form1 parent;

        public PlaylistDisplay(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.FormClosed += PlaylistDisplay_FormClosed;
            this.MaximumSize = this.Size;
        }

        private void PlaylistDisplay_FormClosed(object? sender, FormClosedEventArgs e)
        {
            parent.ClosedPlaylist();
        }

        internal void UpdatePlaylist(Form1.Playlist playlist)
        {
            var dx = playlist.GetPlaylistData();
            listView1.Items.Clear();

            ImageList il = new ImageList();

            il.ImageSize = new Size(128, 64);

            foreach (var file in dx)
            {
                il.Images.Add(file.miniature);
                //il.Images.Add(Resources.vph);
            }

            listView1.SmallImageList = il;

            var ind = 0;

            TimeSpan time = TimeSpan.FromSeconds(0);
            foreach (var item in dx)
            {
                time = time.Add(item.length);
                var filename = item.tags.GetValueOrDefault("Title") ?? "?";
                var t = item.length;
                var k = new List<string>() { string.Empty, filename, item.path, $"{t:mm\\:ss}" };
                var lvi = new ListViewItem(k.ToArray(), ind);

                listView1.Items.Add(lvi);
                ind++;
            }

            label1.Text = $"Playlist time: {time:hh\\:mm\\:ss} / {dx.Count} files";
        }

        private void PlaylistDisplay_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
        }

        private void ListView1_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                parent.SelectedVideo(e.ItemIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.MoveVideoUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.MoveVideoDown();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parent.TrashVideo();
        }
    }
}
