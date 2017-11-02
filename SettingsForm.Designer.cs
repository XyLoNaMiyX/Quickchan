
namespace Quickchan
{
	partial class SettingsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button acceptB;
		private System.Windows.Forms.CheckBox safeModeCB;
		private System.Windows.Forms.GroupBox saveToGB;
		private System.Windows.Forms.RadioButton folderRB;
		private System.Windows.Forms.RadioButton chooseDynamicallyRB;
		private System.Windows.Forms.Button searchB;
		private System.Windows.Forms.TextBox folderTB;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.CheckBox viewedSmallerCB;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.acceptB = new System.Windows.Forms.Button();
			this.safeModeCB = new System.Windows.Forms.CheckBox();
			this.saveToGB = new System.Windows.Forms.GroupBox();
			this.searchB = new System.Windows.Forms.Button();
			this.folderTB = new System.Windows.Forms.TextBox();
			this.folderRB = new System.Windows.Forms.RadioButton();
			this.chooseDynamicallyRB = new System.Windows.Forms.RadioButton();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.viewedSmallerCB = new System.Windows.Forms.CheckBox();
			this.saveToGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// acceptB
			// 
			this.acceptB.Location = new System.Drawing.Point(312, 148);
			this.acceptB.Name = "acceptB";
			this.acceptB.Size = new System.Drawing.Size(54, 23);
			this.acceptB.TabIndex = 0;
			this.acceptB.Text = "Accept";
			this.acceptB.UseVisualStyleBackColor = true;
			this.acceptB.Click += new System.EventHandler(this.AcceptBClick);
			// 
			// safeModeCB
			// 
			this.safeModeCB.Location = new System.Drawing.Point(12, 151);
			this.safeModeCB.Name = "safeModeCB";
			this.safeModeCB.Size = new System.Drawing.Size(124, 19);
			this.safeModeCB.TabIndex = 1;
			this.safeModeCB.Text = "Safe mode enabled?";
			this.safeModeCB.UseVisualStyleBackColor = true;
			// 
			// saveToGB
			// 
			this.saveToGB.Controls.Add(this.searchB);
			this.saveToGB.Controls.Add(this.folderTB);
			this.saveToGB.Controls.Add(this.folderRB);
			this.saveToGB.Controls.Add(this.chooseDynamicallyRB);
			this.saveToGB.Location = new System.Drawing.Point(12, 12);
			this.saveToGB.Name = "saveToGB";
			this.saveToGB.Size = new System.Drawing.Size(354, 95);
			this.saveToGB.TabIndex = 2;
			this.saveToGB.TabStop = false;
			this.saveToGB.Text = "Save files to";
			// 
			// searchB
			// 
			this.searchB.Enabled = false;
			this.searchB.Location = new System.Drawing.Point(322, 65);
			this.searchB.Name = "searchB";
			this.searchB.Size = new System.Drawing.Size(26, 23);
			this.searchB.TabIndex = 3;
			this.searchB.Text = "...";
			this.searchB.UseVisualStyleBackColor = true;
			this.searchB.Click += new System.EventHandler(this.SearchBClick);
			// 
			// folderTB
			// 
			this.folderTB.Enabled = false;
			this.folderTB.Location = new System.Drawing.Point(6, 67);
			this.folderTB.Name = "folderTB";
			this.folderTB.Size = new System.Drawing.Size(310, 20);
			this.folderTB.TabIndex = 2;
			// 
			// folderRB
			// 
			this.folderRB.Location = new System.Drawing.Point(6, 43);
			this.folderRB.Name = "folderRB";
			this.folderRB.Size = new System.Drawing.Size(176, 18);
			this.folderRB.TabIndex = 1;
			this.folderRB.TabStop = true;
			this.folderRB.Text = "The following folder:";
			this.folderRB.UseVisualStyleBackColor = true;
			this.folderRB.CheckedChanged += new System.EventHandler(this.FolderRBCheckedChanged);
			// 
			// chooseDynamicallyRB
			// 
			this.chooseDynamicallyRB.Location = new System.Drawing.Point(6, 19);
			this.chooseDynamicallyRB.Name = "chooseDynamicallyRB";
			this.chooseDynamicallyRB.Size = new System.Drawing.Size(176, 18);
			this.chooseDynamicallyRB.TabIndex = 0;
			this.chooseDynamicallyRB.TabStop = true;
			this.chooseDynamicallyRB.Text = "Choose location dynamically";
			this.chooseDynamicallyRB.UseVisualStyleBackColor = true;
			// 
			// viewedSmallerCB
			// 
			this.viewedSmallerCB.Location = new System.Drawing.Point(12, 126);
			this.viewedSmallerCB.Name = "viewedSmallerCB";
			this.viewedSmallerCB.Size = new System.Drawing.Size(203, 19);
			this.viewedSmallerCB.TabIndex = 3;
			this.viewedSmallerCB.Text = "Make already viewed images smaller";
			this.viewedSmallerCB.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 182);
			this.Controls.Add(this.viewedSmallerCB);
			this.Controls.Add(this.saveToGB);
			this.Controls.Add(this.safeModeCB);
			this.Controls.Add(this.acceptB);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.TopMost = true;
			this.saveToGB.ResumeLayout(false);
			this.saveToGB.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
