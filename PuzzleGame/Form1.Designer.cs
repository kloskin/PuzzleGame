using System.Windows.Forms;

namespace PuzzleGame
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybierzZNaszychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjścieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsHard = new System.Windows.Forms.ToolStripMenuItem();
            this.picPuzzle = new System.Windows.Forms.PictureBox();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPuzzle)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.wybierzZNaszychToolStripMenuItem,
            this.wyjścieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.plikToolStripMenuItem.Text = "&Puzzle";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.otwórzToolStripMenuItem.Text = "&Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // wybierzZNaszychToolStripMenuItem
            // 
            this.wybierzZNaszychToolStripMenuItem.Name = "wybierzZNaszychToolStripMenuItem";
            this.wybierzZNaszychToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.wybierzZNaszychToolStripMenuItem.Text = "Wybierz z naszych";
            this.wybierzZNaszychToolStripMenuItem.Click += new System.EventHandler(this.wybierzZNaszychToolStripMenuItem_Click);
            // 
            // wyjścieToolStripMenuItem
            // 
            this.wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            this.wyjścieToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.wyjścieToolStripMenuItem.Text = "W&yjście";
            this.wyjścieToolStripMenuItem.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptionsEasy,
            this.mnuOptionsMedium,
            this.mnuOptionsHard});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.optionsToolStripMenuItem.Text = "&Opcje";
            // 
            // mnuOptionsEasy
            // 
            this.mnuOptionsEasy.Checked = true;
            this.mnuOptionsEasy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuOptionsEasy.Name = "mnuOptionsEasy";
            this.mnuOptionsEasy.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuOptionsEasy.Size = new System.Drawing.Size(138, 22);
            this.mnuOptionsEasy.Tag = "200";
            this.mnuOptionsEasy.Text = "&Łatwe";
            this.mnuOptionsEasy.Click += new System.EventHandler(this.mnuOptionsLevel_Click);
            // 
            // mnuOptionsMedium
            // 
            this.mnuOptionsMedium.Name = "mnuOptionsMedium";
            this.mnuOptionsMedium.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuOptionsMedium.Size = new System.Drawing.Size(138, 22);
            this.mnuOptionsMedium.Tag = "100";
            this.mnuOptionsMedium.Text = "&Średnie";
            this.mnuOptionsMedium.Click += new System.EventHandler(this.mnuOptionsLevel_Click);
            // 
            // mnuOptionsHard
            // 
            this.mnuOptionsHard.Name = "mnuOptionsHard";
            this.mnuOptionsHard.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuOptionsHard.Size = new System.Drawing.Size(138, 22);
            this.mnuOptionsHard.Tag = "50";
            this.mnuOptionsHard.Text = "&Trudne";
            this.mnuOptionsHard.Click += new System.EventHandler(this.mnuOptionsLevel_Click);
            // 
            // picPuzzle
            // 
            this.picPuzzle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picPuzzle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPuzzle.Location = new System.Drawing.Point(12, 27);
            this.picPuzzle.Name = "picPuzzle";
            this.picPuzzle.Size = new System.Drawing.Size(52, 52);
            this.picPuzzle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPuzzle.TabIndex = 1;
            this.picPuzzle.TabStop = false;
            this.picPuzzle.Visible = false;
            this.picPuzzle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPuzzle_MouseDown);
            this.picPuzzle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPuzzle_MouseMove);
            this.picPuzzle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPuzzle_MouseUp);
            // 
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Graphics Files|*.jpg;*.gif;*.png|All Files|*.*";
            this.ofdPicture.InitialDirectory = "\\\\?\\C:\\Users\\stalk\\AppData\\Local\\Microsoft\\VisualStudio\\17.0_d1965a1f\\WinFormsDes" +
    "igner\\fcwz1ni2.luj\\PrzykładoweZdjecia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picPuzzle);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(500, 200);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPuzzle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem otwórzToolStripMenuItem;
        private ToolStripMenuItem wyjścieToolStripMenuItem;
        private ToolStripMenuItem mnuOptionsEasy;
        private ToolStripMenuItem mnuOptionsMedium;
        private ToolStripMenuItem mnuOptionsHard;
        private PictureBox picPuzzle;
        private OpenFileDialog ofdPicture;
        private ToolStripMenuItem wybierzZNaszychToolStripMenuItem;
    }
}