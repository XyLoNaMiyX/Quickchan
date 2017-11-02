
namespace Quickchan
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button settingsB;
		private System.Windows.Forms.FlowLayoutPanel konImagesFLP;
		private System.Windows.Forms.Button nextPageB;
		private System.Windows.Forms.Button prevPageB;
		private System.Windows.Forms.Label filterL;
		private System.Windows.Forms.TextBox filterTB;
		private System.Windows.Forms.Label downloadingL;
		private System.Windows.Forms.Label pageL;
		private System.Windows.Forms.TextBox pageTB;
		private System.Windows.Forms.Label sizeL;
		private System.Windows.Forms.TrackBar sizeTB;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.konImagesFLP = new System.Windows.Forms.FlowLayoutPanel();
			this.nextPageB = new System.Windows.Forms.Button();
			this.prevPageB = new System.Windows.Forms.Button();
			this.settingsB = new System.Windows.Forms.Button();
			this.filterL = new System.Windows.Forms.Label();
			this.filterTB = new System.Windows.Forms.TextBox();
			this.downloadingL = new System.Windows.Forms.Label();
			this.pageL = new System.Windows.Forms.Label();
			this.pageTB = new System.Windows.Forms.TextBox();
			this.sizeL = new System.Windows.Forms.Label();
			this.sizeTB = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.sizeTB)).BeginInit();
			this.SuspendLayout();
			// 
			// konImagesFLP
			// 
			this.konImagesFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.konImagesFLP.AutoScroll = true;
			this.konImagesFLP.BackColor = System.Drawing.Color.White;
			this.konImagesFLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.konImagesFLP.Location = new System.Drawing.Point(0, 0);
			this.konImagesFLP.Name = "konImagesFLP";
			this.konImagesFLP.Size = new System.Drawing.Size(585, 308);
			this.konImagesFLP.TabIndex = 1;
			this.konImagesFLP.MouseEnter += new System.EventHandler(this.KonImagesFLPMouseEnter);
			// 
			// nextPageB
			// 
			this.nextPageB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextPageB.FlatAppearance.BorderSize = 0;
			this.nextPageB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nextPageB.Location = new System.Drawing.Point(552, 308);
			this.nextPageB.Name = "nextPageB";
			this.nextPageB.Size = new System.Drawing.Size(32, 53);
			this.nextPageB.TabIndex = 2;
			this.nextPageB.Text = ">";
			this.nextPageB.UseVisualStyleBackColor = true;
			this.nextPageB.Click += new System.EventHandler(this.NextPageBClick);
			// 
			// prevPageB
			// 
			this.prevPageB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.prevPageB.FlatAppearance.BorderSize = 0;
			this.prevPageB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.prevPageB.Location = new System.Drawing.Point(0, 308);
			this.prevPageB.Name = "prevPageB";
			this.prevPageB.Size = new System.Drawing.Size(32, 53);
			this.prevPageB.TabIndex = 3;
			this.prevPageB.Text = "<";
			this.prevPageB.UseVisualStyleBackColor = true;
			this.prevPageB.Click += new System.EventHandler(this.PrevPageBClick);
			// 
			// settingsB
			// 
			this.settingsB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.settingsB.FlatAppearance.BorderSize = 0;
			this.settingsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.settingsB.Location = new System.Drawing.Point(38, 314);
			this.settingsB.Name = "settingsB";
			this.settingsB.Size = new System.Drawing.Size(55, 23);
			this.settingsB.TabIndex = 0;
			this.settingsB.Text = "Settings";
			this.settingsB.UseVisualStyleBackColor = true;
			this.settingsB.Click += new System.EventHandler(this.SettingsBClick);
			// 
			// filterL
			// 
			this.filterL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.filterL.Location = new System.Drawing.Point(145, 319);
			this.filterL.Name = "filterL";
			this.filterL.Size = new System.Drawing.Size(38, 14);
			this.filterL.TabIndex = 4;
			this.filterL.Text = "Filters:";
			// 
			// filterTB
			// 
			this.filterTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.filterTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.filterTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterTB.Location = new System.Drawing.Point(189, 317);
			this.filterTB.Name = "filterTB";
			this.filterTB.Size = new System.Drawing.Size(357, 15);
			this.filterTB.TabIndex = 5;
			this.filterTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTBKeyDown);
			this.filterTB.MouseEnter += new System.EventHandler(this.FilterTBMouseEnter);
			// 
			// downloadingL
			// 
			this.downloadingL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.downloadingL.Location = new System.Drawing.Point(68, 343);
			this.downloadingL.Name = "downloadingL";
			this.downloadingL.Size = new System.Drawing.Size(108, 14);
			this.downloadingL.TabIndex = 6;
			this.downloadingL.Text = "0 downloading";
			// 
			// pageL
			// 
			this.pageL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.pageL.Location = new System.Drawing.Point(233, 343);
			this.pageL.Name = "pageL";
			this.pageL.Size = new System.Drawing.Size(36, 14);
			this.pageL.TabIndex = 7;
			this.pageL.Text = "Page:";
			// 
			// pageTB
			// 
			this.pageTB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.pageTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.pageTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pageTB.Location = new System.Drawing.Point(275, 341);
			this.pageTB.Name = "pageTB";
			this.pageTB.Size = new System.Drawing.Size(51, 15);
			this.pageTB.TabIndex = 8;
			this.pageTB.Text = "1";
			this.pageTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PageTBKeyDown);
			this.pageTB.MouseEnter += new System.EventHandler(this.PageTBMouseEnter);
			// 
			// sizeL
			// 
			this.sizeL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.sizeL.Location = new System.Drawing.Point(368, 343);
			this.sizeL.Name = "sizeL";
			this.sizeL.Size = new System.Drawing.Size(36, 14);
			this.sizeL.TabIndex = 9;
			this.sizeL.Text = "Size:";
			// 
			// sizeTB
			// 
			this.sizeTB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.sizeTB.AutoSize = false;
			this.sizeTB.Location = new System.Drawing.Point(410, 339);
			this.sizeTB.Maximum = 300;
			this.sizeTB.Minimum = 50;
			this.sizeTB.Name = "sizeTB";
			this.sizeTB.Size = new System.Drawing.Size(106, 18);
			this.sizeTB.SmallChange = 10;
			this.sizeTB.TabIndex = 10;
			this.sizeTB.TickStyle = System.Windows.Forms.TickStyle.None;
			this.sizeTB.Value = 100;
			this.sizeTB.Scroll += new System.EventHandler(this.SizeTBScroll);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.sizeTB);
			this.Controls.Add(this.sizeL);
			this.Controls.Add(this.pageTB);
			this.Controls.Add(this.pageL);
			this.Controls.Add(this.downloadingL);
			this.Controls.Add(this.filterTB);
			this.Controls.Add(this.filterL);
			this.Controls.Add(this.prevPageB);
			this.Controls.Add(this.nextPageB);
			this.Controls.Add(this.konImagesFLP);
			this.Controls.Add(this.settingsB);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(540, 300);
			this.Name = "MainForm";
			this.Text = "Quickchan";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
			((System.ComponentModel.ISupportInitialize)(this.sizeTB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
