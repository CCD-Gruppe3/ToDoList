//using System.Windows.Forms;
using ToDoList.BusinessLogic;

namespace ToDoList.Controller
{
	public class Controller
	{
		private readonly ToDoListHandler handler;
		private readonly IToDoForm view;

		public Controller(ToDoListHandler handler, IToDoForm view)
		{
			this.handler = handler;
			this.view = view;

			view.SetController(this);
		}

		internal void UpdateView()
		{
			view.BeginUpdate();
			view.Clear();

			foreach (var item in handler.Get(view.ShowArchive))
			{
				view.Add(item);
			}

			view.EndUpdate();
		}
		
		public void AddNewItem(string newTitle)
		{
			if (string.IsNullOrEmpty(newTitle))
				return;

			var item = handler.Add(newTitle);
			view.Add(item);
		}

		public void UpdateItem(int index, bool isChecked)
		{
			if (handler.SetDone(index, isChecked))
				UpdateView();
		}
	}
}