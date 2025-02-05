using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS5
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
        }

        public void LoadData(Form1.Video v)
        {
            //v.tags
            var fi = new FileInfo(v.path);
            label1.Text = "File: " + fi.Name;

            var branch1 = new TreeNode("Tags");
            foreach (var item in v.tags)
            {
                branch1.Nodes.Add(item.Key + ": " + item.Value);
            }

            branch1.Nodes.Add("Size: " + FormatByteSize(fi.Length));

            var branch2 = new TreeNode("Tracks");

            var tracks = v.media.Tracks;

            var i = 0;
            foreach (var track in tracks)
            {
                var b = new TreeNode($"Track {i}");

                b.Nodes.Add($"Track Type: {track.TrackType}");
                b.Nodes.Add($"Codec: {DecodeFourCC(track.Codec)}");
                b.Nodes.Add($"ID: {track.Id}");
                b.Nodes.Add($"Language: {track.Language}");
                b.Nodes.Add($"Description: {track.Description}");

                if (track.TrackType == TrackType.Audio)
                {
                    var audioTrack = track.Data.Audio;
                    b.Nodes.Add($"Channels: {audioTrack.Channels}");
                    b.Nodes.Add($"Rate: {audioTrack.Rate}");
                }
                else if (track.TrackType == TrackType.Video)
                {
                    var videoTrack = track.Data.Video;
                    b.Nodes.Add($"Width: {videoTrack.Width}");
                    b.Nodes.Add($"Height: {videoTrack.Height}");
                    b.Nodes.Add($"Frame Rate: {videoTrack.FrameRateNum}");
                }

                branch2.Nodes.Add(b);

                i++;
            }

            treeView1.Nodes.Add(branch1);
            treeView1.Nodes.Add(branch2);
            treeView1.ExpandAll();
        }

        static string FormatByteSize(long bytes)
        {
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };
            double size = bytes;
            int suffixIndex = 0;

            while (size >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                size /= 1024;
                suffixIndex++;
            }

            return $"{size:0.##} {suffixes[suffixIndex]}";
        }

        string DecodeFourCC(uint cc)
        {
            char[] result = new char[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = (char)((cc >> (8 * i)) & 0xFF);
            }
            return new string(result);
        }
    }
}
