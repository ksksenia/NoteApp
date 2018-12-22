using System;
using System.Drawing;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
	public partial class EditForm : Form
	{
		private Note _note;
		public Note Note
		{
			get
			{
				return _note;
			}
			set
			{
				_note = value;
				if (_note != null)
				{
					textBox3.Text = _note.NoteText;
				}

			}
		}

		public EditForm(Note note = null)
		{
			InitializeComponent();
		    this.Text = (note != null ? "Edit" : "Add") + @" Note";
		    if (note != null) _note = note;
		    else _note = new Note { Title = "Новая запись", Category = NoteCategory.Work, NoteText = "...", timeCreated = DateTime.Now, timeModificated = DateTime.Now };

		    this.Size = new Size(400, 250);
		    comboBox2.Items.AddRange(Enum.GetNames(typeof(NoteCategory)));
		    dateTimePicker1.Enabled = false;
		    dateTimePicker2.Enabled = false;
		    textBox6.Text = _note.Title;
		    textBox5.Text = _note.NoteText;
		    comboBox2.SelectedIndex = comboBox2.Items.IndexOf(_note.Category.ToString());
		    dateTimePicker1.Value = _note.timeCreated > dateTimePicker1.MinDate ? _note.timeCreated : dateTimePicker1.MinDate;
		    dateTimePicker2.Value = _note.timeModificated > dateTimePicker2.MinDate ? _note.timeModificated : dateTimePicker2.MinDate;
		}

	    private void textBox3_TextChanged(object sender, EventArgs e)
		{
		    _note.NoteText = textBox3.Text;
		    dateTimePicker2.Value = _note.timeModificated = DateTime.Now;
		}

        private void button1_Click(object sender, EventArgs e)
		{
		    Note.NoteText = textBox5.Text;
		    Note.Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), comboBox2.SelectedItem.ToString());
		    Note.Title = textBox6.Text;
            DialogResult = DialogResult.OK;

			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
		    Note.NoteText = textBox5.Text;
		}

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
		    Note.Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), comboBox2.SelectedItem.ToString());
		}

    }
}
