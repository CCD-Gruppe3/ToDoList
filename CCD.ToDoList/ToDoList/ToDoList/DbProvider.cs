using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ToDoList.Data;

namespace ToDoList
{
	public class DbProvider
	{
		private readonly string path;

		public DbProvider()
		{
			this.path = Path.Combine(Environment.CurrentDirectory,"ToDoDB","active.txt" );
		}
		public DbProvider(string path)
		{
			this.path = path;
		}

		public IList<ToDoItem> Load()
		{
			var fileContent = File.ReadAllText(path);
			return JsonConvert.DeserializeObject<List<ToDoItem>>(fileContent) ??
				new List<ToDoItem>();
		}

		public void Save(IList<ToDoItem> todoItems)
		{
			var jsonContent = JsonConvert.SerializeObject(todoItems);
			File.WriteAllText(path, jsonContent);
		}

	}
}
