using System;
using System.Collections.Generic;
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
			new ToDoItem(
				Guid.Parse("00000000-0000-0000-0000-000000000001"),
				"Titel",
				"Beschreibung",
				DateTime.Parse("2017-04-18"),
				DateTime.Parse("2017-07-18"),
				"http://www.google.de",
				false
			),
			new ToDoItem(
				Guid.Parse("00000000-0000-0000-0000-000000000002"),
				"Titel 2",
				"Beschreibung 2",
				DateTime.Parse("2017-04-18"),
				DateTime.Parse("2017-04-18"),
				"http://www.google.de",
				true
			),
			new ToDoItem(
				Guid.Parse("00000000-0000-0000-0000-000000000003"),
				"Titel 3",
				"Beschreibung 3",
				DateTime.Parse("2017-04-18"),
				DateTime.Parse("2017-04-20"),
				null,
				false
			)
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
			var todoListHandler = new ToDoListHandler(new DbProvider(Path));
			var c = new Controller.Controller(todoListHandler, mockView);

			c.AddNewToDoItem("Neues Item");

			var newItem = mockView.List.SingleOrDefault(item => item.Title == "Neues Item");
			Assert.NotNull(newItem);

			//cleanup;
			Assert.True(todoListHandler.Delete(newItem.Id));
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

			var t = new ToDoItem(Guid.NewGuid(), "Hinzugefügte Aufgabe", "diese Aufgabe wurde über den UnitTest hinzugefügt",
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

		public void AddToDoItem(ToDoItem lvItem)
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
