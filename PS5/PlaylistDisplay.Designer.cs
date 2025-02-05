namespace PS5
{
    partial class PlaylistDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            prev = new ColumnHeader();
            name = new ColumnHeader();
            path = new ColumnHeader();
            time = new ColumnHeader();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { prev, name, path, time });
            listView1.Location = new Point(12, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 495);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // prev
            // 
            prev.Text = "Preview";
            prev.Width = 129;
            // 
            // name
            // 
            name.Text = "Name";
            name.Width = 250;
            // 
            // path
            // 
            path.Text = "Path";
            path.Width = 250;
            // 
            // time
            // 
            time.Text = "Time";
            time.Width = 90;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 21);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 1;
            label1.Text = "Playlist time: 00:00:00 / x files";
            // 
            // button1
            // 
            button1.Image = Properties.Resources.arrow_bar_down;
            button1.Location = new Point(12, 16);
            button1.Name = "button1";
            button1.Size = new Size(31, 31);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.arrow_bar_up;
            button2.Location = new Point(49, 16);
            button2.Name = "button2";
            button2.Size = new Size(31, 31);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.trash;
            button3.Location = new Point(86, 16);
            button3.Name = "button3";
            button3.Size = new Size(31, 31);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // PlaylistDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 566);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "PlaylistDisplay";
            Text = "PlaylistDisplay";
            Load += PlaylistDisplay_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader prev;
        private ColumnHeader name;
        private ColumnHeader path;
        private ColumnHeader time;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}