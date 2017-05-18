using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Data;

namespace ToDoList.BusinessLogic
{
	public class ToDoListHandler
	{
		private readonly DbProvider provider;
		private readonly IList<ToDoItem> items;


		public ToDoListHandler(DbProvider provider)
		{
			this.provider = provider;
			items = provider.Load();

			MoveDoneItemsToArchive();
		}

		public ToDoItem Add(string newTitle)
		{
			var newItem = new ToDoItem() {Title = newTitle};

			items.Add(newItem);

			provider.Save(items);

			return newItem;
		}

		public bool Delete(Guid itemId)
		{
			var itemToDelete = GetToDoItemById(itemId);
			if (itemToDelete == null)
				return false;

			items.Remove(itemToDelete);
			provider.Save(items);
			return true;
		}

		public IEnumerable<ToDoItem> Get(bool showArchive = false)
		{
			return items.Where(i => i.IsArchived == showArchive);
		}

		private void MoveDoneItemsToArchive()
		{
			var doneItems = items.Where(i => i.IsDone && i.IsArchived == false && DateTime.Today.Subtract(i.DoneDate).Days >= 1 );
			
			if(!doneItems.Any()) return;

			foreach (var toDoItem in doneItems)
			{
				toDoItem.IsArchived = true;
			}

			provider.Save(items);

		}

		public bool SetDone(Guid itemId, bool isChecked)
		{
			var item = GetToDoItemById(itemId);
			if (item == null || item.IsDone == isChecked) return false;
			
			item.DoneDate = isChecked ? DateTime.Today : DateTime.MaxValue;
			item.IsDone = isChecked;
			provider.Save(items);
			return true;
		}

		private ToDoItem GetToDoItemById(Guid itemId)
		{
			return items.SingleOrDefault(i => i.Id.Equals(itemId));
		}
	}
}
