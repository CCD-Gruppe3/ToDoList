using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.BusinessLogic;
using ToDoList.Data;

namespace ToDoList
{
	public partial class Form1 : Form
	{
		private readonly ToDoListHandler handler;

		internal Form1(ToDoListHandler handler)
		{
			this.handler = handler;
			InitializeComponent();
		}

		public void Display()
		{
			listView1.Items.Clear();
			foreach (var item in handler.Get())
			{
				Tuple<Color, Color> c = GetColor(item);
				var lvItem = new ListViewItem {Checked = item.IsDone, ForeColor = c.Item1, BackColor = c.Item2};
				lvItem.SubItems.Add(item.Title);
				lvItem.SubItems.Add(item.DueDate != DateTime.MaxValue ? item.DueDate.ToShortDateString() : "---");

				listView1.Items.Add(lvItem);
			}
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
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			var title = textBoxNewItem.Text;
			if (string.IsNullOrEmpty(title)) return;

			handler.Add(title);
			textBoxNewItem.Clear();
			Display();
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
	}
}
