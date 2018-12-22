using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoteApp.UnitTest
{
	/// <summary> Класс записи </summary>
	public class NoteTest
	{
		/// <summary>
		/// Название
		/// </summary>
		private string _title;
		/// <summary>
		/// Категории заметок
		/// </summary>
		private NoteCategoryTest _NoteCategory;
		/// <summary>
		/// Текст заметки
		/// </summary>
		private string _noteText;
		/// <summary>
		/// Время создания
		/// </summary>
		private DateTime _timeCreated { get; }

		/// <summary>
		/// Время последнего изменения
		/// </summary>
		private DateTime _timeModificated { get; }
		/// <summary>
		/// Заголовок не болжен быть длинее 50 символов
		/// </summary>
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if (value.Length > 50)
				{
					throw new ArgumentException("Заголовок должен содержать не более 50 символов, а содержал" + value.Length);
				}
				_title = value;
			}
		}

		public NoteCategoryTest Category
		{
			get { return _NoteCategory; }
			set { _NoteCategory = value; }
		}

		public string NoteText {
			get
			{
				return _noteText;
			}
			set
			{
				_noteText = value;
			}
		}

		public DateTime timeCreated { get; set; }

		public DateTime timeModificated { get; set; }

		public NoteTest()
		{
			timeCreated = DateTime.Now;
			_title = "Без названия";
			_noteText = "None";
		}

	    public override string ToString()
	    {
	        return Title;
	    }
	}
}