using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class Form2 : Form
    {
        DataTable notes = new DataTable();
        bool editing;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Notes");
            previousNotes.DataSource = notes;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtBox.Text = "";
            editing = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtBox.Text != "")
            {
                if (editing)
                {
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = txtTitle.Text;
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Notes"] = txtBox.Text;
                }
                else
                {
                    notes.Rows.Add(txtTitle.Text, txtBox.Text);
                }
            }

            txtTitle.Text = "";
            txtBox.Text = "";
            editing = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (previousNotes.Rows.Count > 1)
            {
                try
                {
                    notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Not a valid note");
                }
            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            txtTitle.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            txtBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void previousNotes_DoubleClick(object sender, EventArgs e)
        {
            if (previousNotes.Rows.Count > 1)
            {
                txtTitle.Text = notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"].ToString();
                txtBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex]["Notes"].ToString();
                editing = true;
            }
        }
    }
}

