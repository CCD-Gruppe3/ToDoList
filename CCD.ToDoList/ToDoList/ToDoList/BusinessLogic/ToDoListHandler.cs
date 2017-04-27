using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;

namespace ToDoList.BusinessLogic
{
	internal class ToDoListHandler
	{
		private readonly DbProvider provider;
		private readonly IList<ToDoItem> items;


		public ToDoListHandler(DbProvider provider)
		{
			this.provider = provider;
			items = provider.Load();
		}

		public void Add(string newTitle)
		{
			var newItem = new ToDoItem() {Title = newTitle};

			items.Add(newItem);

			provider.Save(items);
		}

		public IEnumerable<ToDoItem> Get()
		{
			return items;
		}
	}
}
