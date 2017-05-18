namespace ToDoList
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.aufgabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.archivierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.archivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.colIsDone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDoneDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel3 = new System.Windows.Forms.Panel();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxNewItem = new System.Windows.Forms.TextBox();
			this.form1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.menuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aufgabeToolStripMenuItem,
            this.ansichtToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(354, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// aufgabeToolStripMenuItem
			// 
			this.aufgabeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.löschenToolStripMenuItem,
            this.archivierenToolStripMenuItem});
			this.aufgabeToolStripMenuItem.Name = "aufgabeToolStripMenuItem";
			this.aufgabeToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.aufgabeToolStripMenuItem.Text = "Aufgabe";
			// 
			// löschenToolStripMenuItem
			// 
			this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
			this.löschenToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.löschenToolStripMenuItem.Text = "Löschen";
			// 
			// archivierenToolStripMenuItem
			// 
			this.archivierenToolStripMenuItem.Name = "archivierenToolStripMenuItem";
			this.archivierenToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.archivierenToolStripMenuItem.Text = "Archivieren";
			// 
			// ansichtToolStripMenuItem
			// 
			this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivToolStripMenuItem,
            this.aToolStripMenuItem});
			this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
			this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.ansichtToolStripMenuItem.Text = "Ansicht";
			// 
			// archivToolStripMenuItem
			// 
			this.archivToolStripMenuItem.Name = "archivToolStripMenuItem";
			this.archivToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.archivToolStripMenuItem.Text = "Aktuell";
			this.archivToolStripMenuItem.Click += new System.EventHandler(this.archivToolStripMenuItem_Click);
			// 
			// aToolStripMenuItem
			// 
			this.aToolStripMenuItem.Name = "aToolStripMenuItem";
			this.aToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aToolStripMenuItem.Text = "Archiv";
			this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listView1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(354, 455);
			this.panel2.TabIndex = 2;
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIsDone,
            this.colTitle,
            this.colDoneDate});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(354, 404);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
			// 
			// colIsDone
			// 
			this.colIsDone.Text = "Erledigt";
			this.colIsDone.Width = 50;
			// 
			// colTitle
			// 
			this.colTitle.Text = "Aufgabe";
			this.colTitle.Width = 52;
			// 
			// colDoneDate
			// 
			this.colDoneDate.Text = "Datum";
			this.colDoneDate.Width = 50;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.buttonAdd);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.textBoxNewItem);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 404);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(354, 51);
			this.panel3.TabIndex = 0;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.Location = new System.Drawing.Point(269, 19);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 22);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Neue Aufgabe";
			// 
			// textBoxNewItem
			// 
			this.textBoxNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNewItem.Location = new System.Drawing.Point(13, 20);
			this.textBoxNewItem.Name = "textBoxNewItem";
			this.textBoxNewItem.Size = new System.Drawing.Size(250, 20);
			this.textBoxNewItem.TabIndex = 0;
			// 
			// form1BindingSource1
			// 
			this.form1BindingSource1.DataSource = typeof(ToDoList.Form1);
			// 
			// form1BindingSource
			// 
			this.form1BindingSource.DataSource = typeof(ToDoList.Form1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 479);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "ToDo-Liste";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.BindingSource form1BindingSource;
		private System.Windows.Forms.BindingSource form1BindingSource1;
		private System.Windows.Forms.ToolStripMenuItem aufgabeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archivierenToolStripMenuItem;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxNewItem;
		private System.Windows.Forms.ColumnHeader colIsDone;
		private System.Windows.Forms.ColumnHeader colTitle;
		private System.Windows.Forms.ColumnHeader colDoneDate;
		private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archivToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
	}
}

