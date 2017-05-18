using ToDoList.Data;

namespace ToDoList
{
	public interface IToDoForm
	{
		bool ShowArchive { get; set; }

		void Add(ToDoItem lvItem);

		void Clear();

		void SetController(Controller.Controller controller);

		void BeginUpdate();

		void EndUpdate();
	}
}
