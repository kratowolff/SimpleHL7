namespace SimpleHL7_GUI
{
	partial class Dashboard
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.RawHL7TextBox = new System.Windows.Forms.TextBox();
			this.HL7TreeView = new System.Windows.Forms.TreeView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(753, 610);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tabControl1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 50);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(753, 560);
			this.panel3.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(753, 560);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(745, 534);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Parser";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.RawHL7TextBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.HL7TreeView);
			this.splitContainer1.Size = new System.Drawing.Size(739, 528);
			this.splitContainer1.SplitterDistance = 328;
			this.splitContainer1.TabIndex = 0;
			// 
			// RawHL7TextBox
			// 
			this.RawHL7TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RawHL7TextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RawHL7TextBox.Location = new System.Drawing.Point(0, 0);
			this.RawHL7TextBox.Multiline = true;
			this.RawHL7TextBox.Name = "RawHL7TextBox";
			this.RawHL7TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.RawHL7TextBox.Size = new System.Drawing.Size(324, 524);
			this.RawHL7TextBox.TabIndex = 0;
			this.RawHL7TextBox.TextChanged += new System.EventHandler(this.RawHL7TextBox_TextChanged);
			// 
			// HL7TreeView
			// 
			this.HL7TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HL7TreeView.Location = new System.Drawing.Point(0, 0);
			this.HL7TreeView.Name = "HL7TreeView";
			this.HL7TreeView.Size = new System.Drawing.Size(403, 524);
			this.HL7TreeView.TabIndex = 0;
			this.HL7TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.HL7TreeView_AfterSelect);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(745, 534);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(753, 50);
			this.panel2.TabIndex = 0;
			// 
			// Dashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(753, 610);
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "Dashboard";
			this.Text = "Simple HL7";
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox RawHL7TextBox;
		private System.Windows.Forms.TreeView HL7TreeView;
	}
}

