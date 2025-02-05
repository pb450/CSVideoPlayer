namespace PS5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            plikToolStripMenuItem = new ToolStripMenuItem();
            dodajPlikiToolStripMenuItem = new ToolStripMenuItem();
            dodajFolderToolStripMenuItem = new ToolStripMenuItem();
            playlistaToolStripMenuItem = new ToolStripMenuItem();
            plikToolStripMenuItem1 = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            eksportToolStripMenuItem = new ToolStripMenuItem();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button9 = new Button();
            button10 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog2 = new OpenFileDialog();
            panel1 = new Panel();
            trackBar2 = new TrackBar();
            pictureBox1 = new PictureBox();
            button11 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Image = Properties.Resources.player_play;
            button1.Location = new Point(12, 31);
            button1.Name = "button1";
            button1.Size = new Size(31, 31);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { plikToolStripMenuItem, playlistaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1391, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // plikToolStripMenuItem
            // 
            plikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajPlikiToolStripMenuItem, dodajFolderToolStripMenuItem });
            plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            plikToolStripMenuItem.Size = new Size(46, 24);
            plikToolStripMenuItem.Text = "File";
            // 
            // dodajPlikiToolStripMenuItem
            // 
            dodajPlikiToolStripMenuItem.Name = "dodajPlikiToolStripMenuItem";
            dodajPlikiToolStripMenuItem.Size = new Size(164, 26);
            dodajPlikiToolStripMenuItem.Text = "Add file";
            dodajPlikiToolStripMenuItem.Click += dodajPlikiToolStripMenuItem_Click;
            // 
            // dodajFolderToolStripMenuItem
            // 
            dodajFolderToolStripMenuItem.Name = "dodajFolderToolStripMenuItem";
            dodajFolderToolStripMenuItem.Size = new Size(164, 26);
            dodajFolderToolStripMenuItem.Text = "Add folder";
            dodajFolderToolStripMenuItem.Click += dodajFolderToolStripMenuItem_Click;
            // 
            // playlistaToolStripMenuItem
            // 
            playlistaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { plikToolStripMenuItem1 });
            playlistaToolStripMenuItem.Name = "playlistaToolStripMenuItem";
            playlistaToolStripMenuItem.Size = new Size(69, 24);
            playlistaToolStripMenuItem.Text = "Playlist";
            // 
            // plikToolStripMenuItem1
            // 
            plikToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, eksportToolStripMenuItem });
            plikToolStripMenuItem1.Name = "plikToolStripMenuItem1";
            plikToolStripMenuItem1.Size = new Size(115, 26);
            plikToolStripMenuItem1.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(137, 26);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // eksportToolStripMenuItem
            // 
            eksportToolStripMenuItem.Name = "eksportToolStripMenuItem";
            eksportToolStripMenuItem.Size = new Size(137, 26);
            eksportToolStripMenuItem.Text = "Export";
            eksportToolStripMenuItem.Click += eksportToolStripMenuItem_Click;
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(12, 105);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(1367, 712);
            videoView1.TabIndex = 3;
            videoView1.Text = "videoView1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Image = Properties.Resources.player_pause;
            button2.Location = new Point(49, 31);
            button2.Name = "button2";
            button2.Size = new Size(31, 31);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.player_stop;
            button3.Location = new Point(86, 31);
            button3.Name = "button3";
            button3.Size = new Size(31, 31);
            button3.TabIndex = 5;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.player_track_prev;
            button4.Location = new Point(123, 31);
            button4.Name = "button4";
            button4.Size = new Size(31, 31);
            button4.TabIndex = 6;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Image = Properties.Resources.player_track_next;
            button5.Location = new Point(160, 31);
            button5.Name = "button5";
            button5.Size = new Size(31, 31);
            button5.TabIndex = 7;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Image = Properties.Resources.player_skip_back;
            button6.Location = new Point(197, 31);
            button6.Name = "button6";
            button6.Size = new Size(31, 31);
            button6.TabIndex = 8;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Image = Properties.Resources.player_skip_forward;
            button7.Location = new Point(234, 31);
            button7.Name = "button7";
            button7.Size = new Size(31, 31);
            button7.TabIndex = 9;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Image = Properties.Resources.info_circle;
            button8.Location = new Point(271, 31);
            button8.Name = "button8";
            button8.Size = new Size(31, 31);
            button8.TabIndex = 10;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(526, 31);
            trackBar1.Maximum = 1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(853, 56);
            trackBar1.TabIndex = 11;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(455, 31);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 12;
            label1.Text = "00:00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(455, 59);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 13;
            label2.Text = "00:00";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // button9
            // 
            button9.Location = new Point(308, 33);
            button9.Name = "button9";
            button9.Size = new Size(141, 29);
            button9.TabIndex = 14;
            button9.Text = "None";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Image = Properties.Resources.list_numbers;
            button10.Location = new Point(12, 68);
            button10.Name = "button10";
            button10.Size = new Size(31, 31);
            button10.TabIndex = 15;
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // panel1
            // 
            panel1.Controls.Add(trackBar2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(526, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(853, 64);
            panel1.TabIndex = 16;
            panel1.Visible = false;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(49, 5);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(801, 56);
            trackBar2.TabIndex = 1;
            trackBar2.Value = 100;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.volume_2;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button11
            // 
            button11.Image = Properties.Resources.volume_2;
            button11.Location = new Point(49, 68);
            button11.Name = "button11";
            button11.Size = new Size(31, 31);
            button11.TabIndex = 17;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1391, 829);
            Controls.Add(button11);
            Controls.Add(panel1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(videoView1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenuItem;
        private ToolStripMenuItem dodajPlikiToolStripMenuItem;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button button9;
        private ToolStripMenuItem playlistaToolStripMenuItem;
        private ToolStripMenuItem plikToolStripMenuItem1;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem eksportToolStripMenuItem;
        private Button button10;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Panel panel1;
        private TrackBar trackBar2;
        private PictureBox pictureBox1;
        private Button button11;
        private ToolStripMenuItem dodajFolderToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
