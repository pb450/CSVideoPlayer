using LibVLCSharp.Shared;
using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;
using PS5.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace PS5
{
    public partial class Form1 : Form
    {

        Playlist playlist;
        public static LibVLC _libVLC;
        public static MediaPlayer _mp;

        static Random gl_random;

        PlayMode playMode = PlayMode.normal;
        bool stopped_manual = false;

        string EXT = "vplaylist";
        string[] extensions;

        public Form1()
        {
            InitializeComponent();

            Core.Initialize();
            playlist = new Playlist();

            playlist.OnPlaylistUpdated += PlaylistUpdate;

            extensions = new string[] { "mp4", "webm", "avi", "wmv", "mov", "flv", "mkv" };
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
            gl_random = new Random();
            _mp.EndReached += _mp_EndReached;
        }

        private void _mp_EndReached(object? sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((x) => JumpToNext());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Filter(extensions);
            openFileDialog1.Multiselect = true;

            openFileDialog2.Filter = Filter(new string[] { EXT });
            saveFileDialog1.Filter = Filter(new string[] { EXT });

            this.MaximumSize = this.Size;
        }

        void Play(Video v)
        {
            //_mp.Stop();
            var b = _mp.Play(v.media);
        }

        public class Playlist
        {
            List<Video> videos;
            int currentIndex = -1;
            Random rnd;
            public EventHandler OnPlaylistUpdated;

            public Playlist()
            {
                videos = new List<Video>();
                rnd = new Random();
            }

            public List<Video> GetPlaylistData()
            {
                return videos;
            }

            public Video? GetVideo()
            {
                return (currentIndex >= 0 && currentIndex < videos.Count) ? videos[currentIndex] : null;
            }

            public void AddVideo(Video v)
            {
                videos.Add(v);
                OnPlaylistUpdated.Invoke(this, EventArgs.Empty);
            }

            public void SetRandomIndex()
            {
                currentIndex = rnd.Next(videos.Count);
            }

            public bool IsCurrentVideoLast()
            {
                return currentIndex == videos.Count - 1;
            }

            public bool IsCurrentVideoFirst()
            {
                return currentIndex == 0;
            }

            public void ResetIndex()
            {
                currentIndex = -1;
            }

            public void DecrementVideo()
            {
                currentIndex--;
            }

            public void IncrementVideo()
            {
                currentIndex++;
            }

            public void SelectIndex(int index)
            {
                currentIndex = index;
            }

            public List<string> ListAllPaths()
            {
                return videos.Select(x => x.path).ToList();
            }

            public void MoveVideoUp(Video v)
            {
                var index = videos.IndexOf(v);

                if (index == -1 || index == 0)
                {
                    return;
                }

                var ps2 = videos[index - 1];

                videos[index] = ps2;
                videos[index - 1] = v;

                OnPlaylistUpdated.Invoke(this, EventArgs.Empty);
            }

            public void MoveVideDown(Video v)
            {
                var index = videos.IndexOf(v);

                if (index == videos.Count - 1 || index == -1)
                {
                    return;
                }

                var ps2 = videos[index + 1];

                videos[index] = ps2;
                videos[index + 1] = v;
                OnPlaylistUpdated.Invoke(this, EventArgs.Empty);

            }

            public void TrashVideo(Video v)
            {
                videos.Remove(v);
                OnPlaylistUpdated.Invoke(this, EventArgs.Empty);
            }
        }

        public class Video
        {
            public bool parsed = false;
            public string path;
            public Media media;
            public TimeSpan length;
            public Dictionary<string, string> tags;
            public Bitmap miniature;

            public Video(string path)
            {
                this.path = path;
                media = new Media(_libVLC, path);
                tags = new Dictionary<string, string>();
                media.ParsedChanged += Media_ParsedChanged;
                media.Parse(MediaParseOptions.ParseLocal);
                LoadThumb();
            }

            void LoadThumb()
            {
                ShellFile sf = ShellFile.FromFilePath(path);
                miniature = sf.Thumbnail.Bitmap;
            }

            private void Media_ParsedChanged(object? sender, MediaParsedChangedEventArgs e)
            {
                parsed = true;
                if (e.ParsedStatus == MediaParsedStatus.Done)
                {
                    length = TimeSpan.FromMilliseconds(media.Duration);

                    Debug.WriteLine(path);
                    foreach (var item in Enum.GetValues<MetadataType>())
                    {
                        tags.Add(item.ToString(), (media.Meta(item) ?? "?"));
                    }
                }
            }
        }

        private void dodajPlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = openFileDialog1.ShowDialog();

            if (a == DialogResult.OK)
            {
                var fns = openFileDialog1.FileNames;

                foreach (var item in fns)
                {
                    var vid = new Video(item);
                    playlist.AddVideo(vid);
                }
            }
        }

        string Filter(string[] ext)
        {
            var fn = "";

            foreach (var ext2 in ext)
            {
                fn += $"{ext2.ToUpper()} File|*.{ext2}|";
            };

            return fn.TrimEnd('|');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playlist.IncrementVideo();
            var a = playlist.GetVideo();

            if (_mp.State == VLCState.Paused)
            {
                _mp.Pause();
                return;
            }

            _mp.Play(new Media(_libVLC, a.path));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_mp.State != VLCState.Paused)
                _mp.Pause();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playlist.GetVideo() != null)
            {
                if (_mp.State == VLCState.Playing)
                {
                    var m = _mp.Length;
                    var ts = TimeSpan.FromMilliseconds(m);

                    var pos = _mp.Time;
                    var ts2 = TimeSpan.FromMilliseconds(pos);

                    label1.Text = $"{ts2:mm\\:ss}";
                    label2.Text = $"{ts:mm\\:ss}";

                    trackBar1.Value = (int)((pos / (float)m) * 1000);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var i = ((int)playMode + 1) % 4;
            playMode = (PlayMode)i;
            button9.Text = $"{LabelForMode(playMode)}";
        }

        string LabelForMode(PlayMode p)
        {
            switch (p)
            {
                case PlayMode.normal:
                    return "None";
                case PlayMode.repeat_song:
                    return "Repeat video";
                case PlayMode.repeat_playlist:
                    return "Repeat playlist";
                case PlayMode.random:
                    return "Random";
                default:
                    return "??";
            }
        }

        public PlaylistDisplay ps;

        private void button10_Click(object sender, EventArgs e)
        {
            if (ps != null)
            {
                MessageBox.Show("Playlist window is already open");
                return;
            }

            PlaylistDisplay ds = new(this);
            ds.UpdatePlaylist(playlist);
            ds.Show();

            ps = ds;
        }

        public void SelectedVideo(int i)
        {
            playlist.SelectIndex(i);
            var gv = playlist.GetVideo();
            Play(gv);
        }

        public void ClosedPlaylist()
        {
            ps = null;
        }
        private void PlaylistUpdate(object? sender, EventArgs e)
        {
            if (ps != null)
            {
                ps.UpdatePlaylist(playlist);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopped_manual = true;
            _mp.Stop();
            playlist.ResetIndex();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var a = playlist.IsCurrentVideoFirst();

            if (!a)
            {
                var v = GetNextVideo(true);
                Play(v);
            }
        }

        void JumpToNext()
        {
            var t = playlist.IsCurrentVideoLast() && (playMode != PlayMode.random);

            if (!t)
            {
                var v2 = GetNextVideo();
                Play(v2);
            }
        }

        public Video? GetNextVideo(bool reverse = false)
        {
            var gs = playlist.GetVideo();
            if (gs != null)
            {
                //gs.audioFile.CurrentTime = TimeSpan.Zero;
            }

            if (reverse)
            {
                playlist.DecrementVideo();
                return playlist.GetVideo();
            }

            if (playMode == PlayMode.repeat_song)
            {
                return playlist.GetVideo();
            }

            if (playMode == PlayMode.repeat_playlist)
            {
                if (playlist.IsCurrentVideoLast())
                {
                    playlist.ResetIndex();
                }
            }

            if (playMode == PlayMode.random)
            {
                playlist.SetRandomIndex();
                return playlist.GetVideo();
            }

            playlist.IncrementVideo();
            return playlist.GetVideo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JumpToNext();
        }

        private void eksportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var files = playlist.ListAllPaths();
            var json = JsonConvert.SerializeObject(files);
            var f1 = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var f2 = $"playlist_{f1}.{EXT}";

            saveFileDialog1.FileName = f2;
            var fd = saveFileDialog1.ShowDialog();

            if (fd == DialogResult.OK)
            {
                var fl = saveFileDialog1.FileName;

                File.WriteAllText(fl, json);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var i = openFileDialog2.ShowDialog();

            if (i == DialogResult.OK)
            {
                var f = openFileDialog2.FileName;
                var text = File.ReadAllText(f);
                var arr = JsonConvert.DeserializeObject<List<string>>(text);

                foreach (var item in arr)
                {
                    var ps = new Video(item);
                    playlist.AddVideo(ps);
                }

                //UpdateRuntime();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var prg = trackBar1.Value / 1000f;
            var t = prg * _mp.Length;
            var t_l = (long)t;

            _mp.Time = t_l;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JumpInTime(-5);
        }

        void JumpInTime(int am)
        {
            if (playlist.GetVideo() != null)
            {
                var tm = _mp.Time;
                var len = _mp.Length;

                var selTime = tm + (am * 1000);

                if (selTime > len || selTime < 0)
                {
                    return;
                }

                _mp.Time = selTime;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JumpInTime(5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var i = playlist.GetVideo();

            if (i != null)
            {
                InfoForm ifx = new InfoForm();
                ifx.LoadData(i);
                ifx.Show();
            }
        }

        internal void MoveVideoDown()
        {
            var ps = playlist.GetVideo();
            if (ps != null)
            {
                playlist.MoveVideDown(ps);
            }
        }

        internal void MoveVideoUp()
        {
            var ps = playlist.GetVideo();

            if (ps != null)
            {
                playlist.MoveVideoUp(ps);
            }
        }

        internal void TrashVideo()
        {
            var ps = playlist.GetVideo();

            if (ps != null)
            {
                _mp.Stop();

                playlist.TrashVideo(ps);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            _mp.Volume = trackBar2.Value;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dodajFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sh = folderBrowserDialog1.ShowDialog();

            if (sh == DialogResult.OK)
            {
                var folderPath = folderBrowserDialog1.SelectedPath;

                var msg = MessageBox.Show("Do you want to perform recursive search?", "?", MessageBoxButtons.YesNo);
                var so = msg != DialogResult.Yes ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories;

                var enFiles = Directory.GetFiles(folderPath, "*", so);

                List<string> correctNames = new List<string>();
                foreach (var item in enFiles)
                {
                    var ext = Path.GetExtension(item).ToLower().Replace(".", "");

                    if (extensions.Contains(ext))
                    {
                        correctNames.Add(item);
                    }
                }

                var msg2 = MessageBox.Show($"You will import {correctNames.Count} files. Continue?", "?", MessageBoxButtons.YesNo);

                if (msg2 == DialogResult.Yes)
                {
                    foreach (var item in correctNames)
                    {
                        Video ps = new(item);
                        playlist.AddVideo(ps);
                    }
                }
            }
        }

        enum PlayMode
        {
            normal = 0,
            repeat_song = 1,
            repeat_playlist = 2,
            random = 3
        }
    }
}
