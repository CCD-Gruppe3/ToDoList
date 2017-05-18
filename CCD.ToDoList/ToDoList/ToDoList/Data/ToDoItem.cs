using System;
using Newtonsoft.Json;

namespace ToDoList.Data
{
	public class ToDoItem
	{
		public ToDoItem()
		{
			Id = Guid.NewGuid();
			DueDate = DateTime.MaxValue;
		}

		[JsonConstructor]
		public ToDoItem(Guid id, string title, string description, DateTime doneDate, DateTime dueDate, string url, bool isDone)
		{
			Id = id;
			Title = title;
			Description = description;
			DoneDate = doneDate;
			DueDate = dueDate;
			Url = url;
			IsDone = isDone;
			IsArchived = false;
		}

		public Guid Id { get; set; }
		public string Title { get; set; }
		public override string ToString()
		{
			return $"{Id} - {Title} - {Description} - {IsDone} - {DueDate} - {DoneDate}";
		}

		public string Description { get; set;}
		public DateTime DoneDate { get; set;}
		public DateTime DueDate { get; set;}
		public string Url { get; set; }
		public bool IsDone { get; set; }
		public bool IsArchived { get; set; }


		[JsonIgnore]
		public int DaysTillDueDate => DueDate.Subtract(DateTime.Today).Days;


		#region Equals Methods
		protected bool Equals(ToDoItem other)
		{
			return 
				Id.Equals(other.Id) &&
				string.Equals(Title, other.Title) &&
				string.Equals(Description, other.Description) &&
				DoneDate.Equals(other.DoneDate) &&
				DueDate.Equals(other.DueDate) &&
				string.Equals(Url, other.Url) &&
				IsDone == other.IsDone;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ToDoItem) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Id != null) ? Id.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ DoneDate.GetHashCode();
				hashCode = (hashCode * 397) ^ DueDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ IsDone.GetHashCode();
				return hashCode;
			}
		}

		#endregion
	}
}
