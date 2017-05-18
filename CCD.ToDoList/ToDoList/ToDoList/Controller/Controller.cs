using System;
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
				view.AddToDoItem(item);
			}

			view.EndUpdate();
		}
		
		public void AddNewToDoItem(string newTitle)
		{
			if (string.IsNullOrEmpty(newTitle))
				return;

			handler.Add(newTitle);
			UpdateView();
		}

		public void UpdateItem(Guid itemId, bool isChecked)
		{
			if (handler.SetDone(itemId, isChecked))
				UpdateView();
		}
	}
}