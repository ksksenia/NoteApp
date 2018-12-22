using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			this.Text = "About";
			this.Size = new Size(400, 250);
			
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			linkLabel2.LinkClicked += linkLabel2_LinkClicked;
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://lplans@icloud.com");
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/TVA777/NoteApp");
		}
	}
}
