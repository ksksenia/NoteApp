using System;
using System.Windows.Forms;
using NoteApp;


namespace NoteAppUI
{
    public partial class MainForm : Form
	{
		private Project _project = new Project();

		public MainForm()
		{
			InitializeComponent();
			this.Text = @"Главное окно программы";
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		   _project= ProjectManager.LoadFromFile("json.txt");
		    comboBox1.Items.AddRange(Enum.GetNames(typeof(NoteCategory)));
		    comboBox1.SelectedIndexChanged += ComboBox1OnSelectedIndexChanged;
		    comboBox1.SelectedIndex = 0;
		}

        /// <summary>
        /// Изменение типа отображаемых Note
        /// </summary>
	    private void ComboBox1OnSelectedIndexChanged(object sender, EventArgs eventArgs)
	    {
	        listbox1.Items.Clear();
	        foreach (Note note in _project.Notes)
	        {
	            NoteCategory type;
	            if (Enum.TryParse(comboBox1.SelectedItem.ToString(), out type))
	            {
	                if (type == note.Category)
	                    listbox1.Items.Add(note);
	            }
	        }

	        if (listbox1.Items.Count > 0) listbox1.SelectedIndex = 0;
	        else
	        {
	            label1.Text = label2.Text = textBox5.Text = @"";
	        }
	    }

        /// <summary>
        /// Редактирование Note
        /// </summary>
		private void Edit_Click(object sender, EventArgs e)
		{
		    var selectedIndex = listbox1.SelectedIndex;
		    Note edit = (Note)listbox1.SelectedItem;
		    var projectIndex = _project.Notes.IndexOf(edit);
		    EditForm EdForm = new EditForm(edit);
		    if (projectIndex>=0 && EdForm.ShowDialog() == DialogResult.OK)
		    {
		        edit = EdForm.Note;
		        if (edit == null) return;
		        _project.Notes[projectIndex] = edit;
                ProjectManager.SaveToFile(_project,"json.txt");
		        listbox1.Items[selectedIndex] = edit;
				textBox5.Text = edit.NoteText;
		        listbox1.Refresh();
		        dateTimePicker1.Value = edit.timeCreated > dateTimePicker1.MinDate ? edit.timeCreated : dateTimePicker1.MinDate;
		        dateTimePicker2.Value = edit.timeModificated > dateTimePicker2.MinDate ? edit.timeModificated : dateTimePicker2.MinDate;
		    }

        }

        /// <summary>
        /// Добавление нового Note
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
		{
		    EditForm EdForm = new EditForm(new Note { Title = $"Новая запись {listbox1.Items.Count+1}", Category = (NoteCategory)Enum.Parse(typeof(NoteCategory),comboBox1.SelectedItem.ToString()), NoteText = "...", timeCreated = DateTime.Now, timeModificated = DateTime.Now });
		    if (EdForm.ShowDialog() == DialogResult.OK)
		    {
		        Note edit = EdForm.Note;
		        if (edit == null) return;
		        _project.Notes.Add(edit);
		        ProjectManager.SaveToFile(_project, "json.txt");
		        listbox1.Items.Add(edit);
				textBox5.Text = edit.NoteText;
				listbox1.Refresh();
		        dateTimePicker1.Value = edit.timeCreated > dateTimePicker1.MinDate ? edit.timeCreated : dateTimePicker1.MinDate;
		        dateTimePicker2.Value = edit.timeModificated > dateTimePicker2.MinDate ? edit.timeModificated : dateTimePicker2.MinDate;
		    }
		}

        /// <summary>
        /// Удаление выделенного Note
        /// </summary>
        private void Remove_Click(object sender, EventArgs e)
		{
		    if (listbox1.SelectedIndex >= 0 && MessageBox.Show(@"Удалить выбранную запись?", @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
		    {
		        var selectedIndex = listbox1.SelectedIndex;
		        Note edit = (Note)listbox1.SelectedItem;
		        var projectIndex = _project.Notes.IndexOf(edit);
		        if (projectIndex >= 0 && selectedIndex >= 0)
		        {
		            _project.Notes.RemoveAt(projectIndex);
		            listbox1.Items.RemoveAt(selectedIndex);
		            if (selectedIndex < listbox1.Items.Count) listbox1.SelectedIndex = selectedIndex;
		            ProjectManager.SaveToFile(_project, "json.txt");
		        }

            }
		}

        /// <summary>
        /// Выбор Note в списке
        /// </summary>
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		    if (listbox1.SelectedItem != null)
		    {
		        Note note = (Note)listbox1.SelectedItem;
		        label1.Text = note.Title;
		        label2.Text = note.Category.ToString();
		        textBox5.Text = note.NoteText;
		    }
		}

        /// <summary>
        /// Отобразить окно About
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog();
		}

        /// <summary>
        /// Смена типа видимых Note
        /// </summary>
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			label2.Text = (sender as ComboBox).Text;
		}

        /// <summary>
        /// Закрытие приложения
        /// </summary>
        private void removeNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(_project, "json.txt");
            Close();
        }

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}
	}
}