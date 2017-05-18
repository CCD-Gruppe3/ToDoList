using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using ToDoList.BusinessLogic;
using ToDoList.Data;
using Xunit;

namespace ToDoList.Tests
{
	public class AcceptensTest
	{
		private static readonly string Path = System.IO.Path.Combine(Environment.CurrentDirectory, "TestData", "active.txt");
		
		private IList<ToDoItem> expectedToDoItems = new List<ToDoItem>
		{
			new ToDoItem()
			{
				Title = "Titel",
				Description = "Beschreibung",
				Url = "http://www.google.de",
				IsDone = false,
				DueDate = DateTime.Parse("2017-04-18").AddMonths(3),
				DoneDate = DateTime.Parse("2017-04-18")
			},
			new ToDoItem()
			{
				Title = "Titel 2",
				Description = "Beschreibung 2",
				Url = "http://www.google.de",
				IsDone = true,
				DueDate = DateTime.Parse("2017-04-18"),
				DoneDate = DateTime.Parse("2017-04-18")
			},
			new ToDoItem()
			{
				Title = "Titel 3",
				Description = "Beschreibung 3",
				IsDone = false,
				DueDate = DateTime.Parse("2017-04-18").AddDays(2),
				DoneDate = DateTime.Parse("2017-04-18")
			},
		};

		[Fact]
		public void LoadToDoItemsFromFileTest()
		{
			var dbProbider = new DbProvider(Path);
			var todoItems = dbProbider.Load();
			Assert.Equal(expectedToDoItems, todoItems);
		}


		[Fact(Skip = "explicit")]
		public void DisplayToDoListitemsTest()
		{
			var f = new Form1();
			f.SetController(new Controller.Controller(new ToDoListHandler(new DbProvider(Path)), f));
			f.ShowDialog();

		}

		[Fact]
		public void TestController()
		{
			ToDoMockView mockView = new ToDoMockView();

			var c = new Controller.Controller(new ToDoListHandler(new DbProvider(Path)), mockView);

			c.AddNewItem("Neues Item");

			Assert.True(mockView.List.Any(item => item.Title == "Neues Item"));

		}

		[Fact]
		public void DaysTillDueDateTest()
		{
			var today = DateTime.Today;
			var todo0= new ToDoItem() {DueDate = today.AddDays(7)};
			Assert.Equal(7,todo0.DaysTillDueDate);

			
			var todo1= new ToDoItem() {DueDate = today.AddDays(-7)};
			Assert.Equal(-7,todo1.DaysTillDueDate);
			
			var todo2= new ToDoItem() {DueDate = today};
			Assert.Equal(0,todo2.DaysTillDueDate);

			var todo3= new ToDoItem() ;
			Assert.True(todo3.DaysTillDueDate > 3);
		}

		[Fact]
		public void AddToDoItemTest()
		{
			var dbProvider = new DbProvider(Path);
			var toDos0 = dbProvider.Load();// OriginalListe
			var toDos1 = dbProvider.Load();

			var count0 = toDos0.Count;

			var t = new ToDoItem("Hinzugefügte Aufgabe", "diese Aufgabe wurde über den UnitTest hinzugefügt",
				new DateTime(2017, 04, 30), new DateTime(2017, 04, 30), "www.google.de", false);
			toDos1.Add(t);

			dbProvider.Save(toDos1);

			var toDos2 = dbProvider.Load();
			var count1 = toDos2.Count;

			Assert.Equal(count0 + 1, count1);
			Assert.True(toDos2.Contains(t));

			// Original Zustand herstellen
			dbProvider.Save(toDos0);
		}
	}

	public class ToDoMockView : IToDoForm
	{
		private Controller.Controller c;
		public List<ToDoItem> List;

		public ToDoMockView()
		{
			List = new List<ToDoItem>();
		}

		public bool ShowArchive { get; set; }

		public void Add(ToDoItem lvItem)
		{
			List.Add(lvItem);
		}

		public void Clear()
		{
			List.Clear();
		}

		public void SetController(Controller.Controller controller)
		{
			this.c = controller;
		}

		public void BeginUpdate()
		{
			
		}

		public void EndUpdate()
		{
			
		}
	}
}
