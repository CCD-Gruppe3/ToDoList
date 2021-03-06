﻿using System;
using System.Windows.Forms;
using ToDoList.BusinessLogic;

namespace ToDoList
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var view = new Form1 {Visible = false};
			
			var dbProvider = new DbProvider();
			var handler = new ToDoListHandler(dbProvider);

			var controller = new Controller.Controller(handler, view);

			Application.Run(view);
		}
	}
}
