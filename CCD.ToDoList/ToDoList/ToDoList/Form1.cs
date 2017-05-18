using System;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.Data;

namespace ToDoList
{
	public partial class Form1 : Form, IToDoForm
	{
		private Controller.Controller controller;
		private bool updating;

		internal Form1()
		{
			InitializeComponent();
		}

		public bool ShowArchive { get; set; }

		public void Add(ToDoItem item)
		{
			Tuple<Color, Color> c = GetColor(item);
			var lvItem = new ListViewItem { Checked = item.IsDone, ForeColor = c.Item1, BackColor = c.Item2 };
			lvItem.SubItems.Add(item.Title);
			lvItem.SubItems.Add(item.DueDate != DateTime.MaxValue ? item.DueDate.ToShortDateString() : "---");

			listView1.Items.Add(lvItem);
		}

		public void Clear()
		{
			textBoxNewItem.Clear();
			listView1.Items.Clear();
		}


		private void Form1_Resize(object sender, EventArgs e)
		{
			ResizeList();
		}

		private void ResizeList()
		{
			listView1.Columns[2].Width = -1;
			listView1.Columns[1].Width = listView1.Width
			                             - listView1.Columns[0].Width - listView1.Columns[2].Width - 10;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ResizeList();
			controller.UpdateView();
		}
		
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			controller.AddNewItem(textBoxNewItem.Text);
		}


		public void SetController(Controller.Controller controller)
		{
			this.controller = controller;
		}

		public void BeginUpdate()
		{
			updating = true;
		}

		public void EndUpdate()
		{
			updating = false;
		}

		private Tuple<Color, Color> GetColor(ToDoItem item)
		{
			if (item.IsDone)
				return Tuple.Create(Color.Black, Color.Transparent);
			if (item.DaysTillDueDate > 3)
				return Tuple.Create(Color.Black, Color.Transparent);

			if (item.DaysTillDueDate < 0)
				return Tuple.Create(Color.Red, Color.Transparent);

			return Tuple.Create(Color.Yellow, Color.Gray);

		}

		private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
		{

			if(updating) return;

			var isChecked = e.Item.Checked;
			var index = e.Item.Index;

			// Das funktioniert leider nicht, da beim erzeugen des Views eine
			// Rekursion entsteht. :-(
			controller.UpdateItem(index, isChecked);
		}

		private void aToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowArchive = true;
			controller.UpdateView();
		}

		private void archivToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowArchive = false;
			controller.UpdateView();
		}
	}
}
