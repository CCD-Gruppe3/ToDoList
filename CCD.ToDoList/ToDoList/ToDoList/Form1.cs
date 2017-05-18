using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.Data;

namespace ToDoList
{
	public partial class Form1 : Form, IToDoForm
	{
		private Controller.Controller controller;
		private bool updating;
		public bool ShowArchive { get; set; }

		#region ctor
		internal Form1()
		{
			InitializeComponent();
		}
		#endregion

		#region Public Methods
		public void AddToDoItem(ToDoItem item)
		{
			Tuple<Color, Color> c = GetColor(item);
			var lvItem = new ListViewItem { Checked = item.IsDone, ForeColor = c.Item1, BackColor = c.Item2, Tag = item.Id  };
			lvItem.SubItems.Add(item.Title);
			lvItem.SubItems.Add(item.DueDate != DateTime.MaxValue ? item.DueDate.ToShortDateString() : "---");

			listView1.Items.Add(lvItem);
		}

		public void Clear()
		{
			textBoxNewItem.Clear();
			listView1.Items.Clear();
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
		#endregion

		#region Private Helper
		private void ResizeList()
		{
			listView1.Columns[0].Width = 50;
			listView1.Columns[2].Width = 80;
			listView1.Columns[1].Width = listView1.Width
			                             - listView1.Columns[0].Width - listView1.Columns[2].Width - 1;
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
		
		private void ToggleViewMenuItems(bool showArchive)
		{
			archivToolStripMenuItem.Checked = showArchive;
			aktuellToolStripMenuItem.Checked = !showArchive;
		}

		private void InnerAddNewToDoItem()
		{
			controller.AddNewToDoItem(textBoxNewItem.Text);
			textBoxNewItem.Clear();
		}
		#endregion

		#region EventHandler

		private void Form1_Load(object sender, EventArgs e)
		{
			ResizeList();
			controller.UpdateView();
		}
		private void Form1_Resize(object sender, EventArgs e)
		{
			ResizeList();
		}
		
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			InnerAddNewToDoItem();
		}
		
		private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (updating) return;

			var isChecked = e.Item.Checked;
			var itemId = (Guid)e.Item.Tag;

			controller.UpdateItem(itemId, isChecked);
		}

		private void archivToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowArchive = true;
			ToggleViewMenuItems(ShowArchive);
			controller.UpdateView();
		}

		private void aktuellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowArchive = false;
			ToggleViewMenuItems(ShowArchive);
			controller.UpdateView();
		}

		private void textBoxNewItem_KeyPress(object sender, KeyPressEventArgs e)
		{
			// on "Enter" add the Item
			if (e.KeyChar == char.ConvertFromUtf32(13).ToCharArray()[0])
				InnerAddNewToDoItem();
		}
		#endregion
	}
}
